using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers{
	[Route("/Test")]
    public class TestController:Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }
    }
}
