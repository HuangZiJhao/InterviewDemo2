using System;
using System.Data.SqlClient;
using WebApplication1.DataBase.Catagory;

namespace WebApplication1.Services
{
    public class OdService
    {
        private static readonly string _connectString = @"Persist Security Info=False;Integrated Security=true;Initial Catalog=InterViewDemo;Server=DESKTOP-4F14LKK;User ID=sa;Password=sa20230515;";
        public string[] GetGroup()
        {
            CatagroyDBO catagroyDBO = new CatagroyDBO();
            HttpClient httpClient = new HttpClient();
            string[] response = httpClient.GetFromJsonAsync<string[]>("https://apiservice.mol.gov.tw/OdService/rest/group?limit=60&offset=0").Result;
            using (var cn = new SqlConnection(_connectString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        foreach (string code in response)
                        {
                            catagroyDBO.InsertCategory(cn, code, tran);
                            if (code == "100")
                                throw new Exception();
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {

                        tran.Rollback();
                    }
                    finally
                    {

                        tran.Dispose();
                    }

                }
                cn.Dispose();
            }

            return response;
        }
    }
}
