using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojosurvey.Controllers{
        
        public class SuccessController : Controller{
            
            [HttpGetAttribute]
            [HttpGet]
            [Route("/success")]
            public IActionResult Success(){
                return View("success");
            }
        }
}