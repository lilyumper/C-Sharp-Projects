using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller{
        [HttpGetAttribute]
        [HttpGet]
        [Route("/contact")]

        public IActionResult contact(){
            return View("contact");
        }

    
    }
}