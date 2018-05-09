using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller{
        [HttpGetAttribute]
        [HttpGet]
        [Route("/projects")]


        public IActionResult projects(){
            return View("projects");
        }
        
    }
}