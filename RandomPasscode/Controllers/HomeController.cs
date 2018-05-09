using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGetAttribute]
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
           if(HttpContext.Session.GetInt32("count")==null){
               HttpContext.Session.SetInt32("count", -1);
           }
           int? count = HttpContext.Session.GetInt32("count");
           count++;
           HttpContext.Session.SetInt32("count", (int)count);
           ViewBag.Count = count;
           string Rand = "";
           
           
            return View("Index");
        }

        [HttpGetAttribute]
        [HttpPost]
        [Route("Random")]
        public IActionResult Random(){
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[13];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            TempData["Rand"] = new String(stringChars);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Flush")]
        public IActionResult Flush(){
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

    
    }
}
