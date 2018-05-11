using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quoting_Dojo.Models;
using DbConnection;
using System.Collections.Generic;

namespace Quoting_Dojo.Controllers{
    public class Quoting_DojoController:Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
          
            return View("Index");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string name, string quote){
            string Name = name;
            string Quote = quote;
            string creation = $"INSERT INTO users (name,quote,created_at) VALUES ('{Name}', '{Quote}', NOW())";
            DbConnector.Query(creation);
            TempData["Message"] = "Your Qoute has been Created";
            return RedirectToAction("Index", TempData["Message"]);
            
           
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult Showme(){
           var stuff = DbConnector.Query("SELECT * FROM users ORDER BY created_at DESC");
            ViewBag.AllQuotes = stuff;
           return View("quotes");
        }
    }

}
