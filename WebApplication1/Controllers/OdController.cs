using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdController : ControllerBase
    {
        [HttpGet(Name = "OdGroup")]
        public string[] GetOdGroup()
        {
            OdService odService = new OdService();
            var resp = odService.GetGroup();
            return resp;
        }
    }
}
