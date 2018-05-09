using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace TimeDisplay.Controllers
{
    public class TimeController : Controller
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
