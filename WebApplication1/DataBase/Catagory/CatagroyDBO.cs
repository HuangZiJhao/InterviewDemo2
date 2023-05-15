using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.DataBase.Catagory
{
    public class CatagroyDBO
    {
        //public List<string> Query()
        //{
        //    List<string> categorys;
        //    using (var cn = new SqlConnection(_connectString))
        //    {
        //        cn.Open();
        //        categorys = cn.Query<string>("SELECT CategoryCode FROM Category").ToList();
        //    }

        //    return categorys;
        //}
        public void InsertCategory(SqlConnection conn, string categoryCode,SqlTransaction sqlTransaction = null)
        {
            string sql = @"  insert into Category(
                                  CategoryCode
                                  )values(
                                  @CategoryCode
                                  )";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CategoryCode", categoryCode);
            conn.Execute(sql, dynamicParameters, sqlTransaction);
        }

    }
}
