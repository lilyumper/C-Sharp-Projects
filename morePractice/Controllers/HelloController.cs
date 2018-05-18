using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace morePractice.Controllers
{
    public class HelloController : Controller
    {
        [HttpGetAttribute]
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

    
    }
}
