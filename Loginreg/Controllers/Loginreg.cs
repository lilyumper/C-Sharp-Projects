using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Loginreg.Models;
using System.Collections.Generic;
using DbConnection;
using System;

namespace Loginreg.Controllers{
    public class LoginregController:Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.errors ="";
            TempData["Message"] = "";
            return View("Index");
        }
    
    
    
        [HttpPost]
        [Route("/Success")]

        public IActionResult Success(string first_name, string last_name, string email, string password, string cpassword ){
            User NewUser = new User{
                first_name = first_name,
                last_name = last_name,
                email = email,
                password = password

            };

            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;

            if(ModelState.IsValid && password == cpassword){
                string check = $"SELECT * FROM user WHERE (email = '{email}')";
                System.Console.WriteLine(check);
                var checkingEmail= DbConnector.Query(check);
                System.Console.WriteLine(checkingEmail);
                if(checkingEmail.Count < 1){
                    string creation = $"INSERT INTO user (first_name,last_name,email,password) VALUES ('{first_name}', '{last_name}', '{email}','{password}')";
                    DbConnector.Query(creation);
                    return View("success");

                }
                else{
                    TempData["Message"]= "Email Already in use. Please log in or register with new email!";
                    return View("Index");
                }
            }
            else{
               TempData["Message"] = "Passwords must Match!";
               return View("Index");
            }

        }

        [HttpPost]
        [Route("/Login")]

        public IActionResult Login(string loginemail, string loginpassword){
            string check = $"SELECT * FROM user WHERE  (email = '{loginemail}' and password = '{loginpassword}')";
            var checklogin = DbConnector.Query(check);
            ViewBag.errors = ModelState.Values;
            if(checklogin.Count >=1){
                return View("success");


            }
            else{
                TempData["Message"] = "Invalid Username or Password";
                return View("Index");
            }
        } 



    }
}
