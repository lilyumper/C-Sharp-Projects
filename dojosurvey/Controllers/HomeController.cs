using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojosurvey.Controllers{
     public class HomeController : Controller{
        [HttpGetAttribute]
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("index");
        }

        [HttpPost]
        [Route("/success")]
        public IActionResult Success(string name, string location, string language, string comment){
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;
            return View("success"); 

        } 
     }   
}