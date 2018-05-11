using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using From_submission.Models;
using System;
using System.Collections.Generic;


namespace From_submission.Controllers{
	
    public class From_submissionController:Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            
            ViewBag.errors = "";
            return View("Index");
        }


        [HttpPost]
        [Route("/Success")]

        public IActionResult Success(string fname, string lname, int age, string email, string password){
            User NewUser = new User{
                fname= fname,
                lname= lname,
                age = age,
                email= email,
                password= password
            };
           TryValidateModel(NewUser);
           ViewBag.errors = ModelState.Values;

           if(ModelState.IsValid){
               return View("success");
           }
           return View("Index");
           

        }
    }
}
