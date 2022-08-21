using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantWebApp.Data;

namespace MultiTenantWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ProductDatabaseContext _appDbCtx;
        public TestController(ProductDatabaseContext appDbCtx)
        {
            _appDbCtx = appDbCtx;
        }
        [HttpGet]
        public ActionResult TestProdDb()
        {
            return Ok(_appDbCtx.Database.CanConnect());
        }
        [HttpGet]
        public ActionResult TestMainDb()
        {
            using var mainCtx = new MainContext();
            return Ok(mainCtx.Database.CanConnect());
        }
    }
}
