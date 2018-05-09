using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller{
        [HttpGetAttribute]
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("index");
        }

        public IActionResult contact(){
            return View("contact");
        }

        public IActionResult projects(){
            return View("projects");
        }
        
    }
}