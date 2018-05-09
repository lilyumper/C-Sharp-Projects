using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using Dojodachi;
using System.Collections.Generic;
namespace Dojodachi.Controllers
{
        
    public class HomeController : Controller
    {       
        public class Ninja{
            public string name;
            public int fullness = 100;
            public int happiness = 100;
            public int energy = 50;
            public int meals = 3;

            public Ninja(string val){
                name = val;
            }
            public void Eat(){
                Random chance = new Random();
                int test = chance.Next(0,4);
                if(test == 2){
                    meals -=1;
                }
                else{
                    Random full = new Random();
                    meals -=1;
                    fullness += full.Next(5,10);    
                }
                    


            }
            public void Playtime(){
                Random happy = new Random();
                energy -= 5;
                happiness += happy.Next(5,10);

            }
            public void Sleepy(){
                energy += 15;
                happiness -= 5;
                fullness -= 5;
            }

            public void Worky(){
                Random stuff = new Random();
                energy -=5;
                meals += stuff.Next(0,3);
            }


        }
        [HttpGetAttribute]
        [HttpGet]
        [Route("")]
        
        public IActionResult Index(){
            List<Ninja> NewList = new List<Ninja>();
            List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");

            if(Retrieve == null){

                Ninja someguy = new Ninja("Tomas");
                NewList.Add(someguy);
                HttpContext.Session.SetObjectAsJson("Ninjaman", NewList);
                Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");
                System.Console.WriteLine("NINJA GUYS IS HERE!!!!");
            }
            ViewBag.Guy = Retrieve;

            return View("Index");
        }
        [HttpPost]
        [Route("Feed")]
        
        public IActionResult Feed(){
            List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");

            if(Retrieve[0].meals >0){
                int fullness = Retrieve[0].fullness;
                Retrieve[0].Eat();
                int after = fullness- Retrieve[0].fullness;
                if(after !=fullness){
                     string complete = $"You ate losing 1 meal and your Fullness went up {after}"; 
                    TempData["Message"]= complete;
                    HttpContext.Session.SetObjectAsJson("Ninjaman", Retrieve);
                }
                else{
                    TempData["Message"] = "Your Ninja ate and threw up, you lost a meal and gained no happiness";
                    
                }
               
               
              

            }
            else{
                TempData["Message"] = "You dont have enough meals to eat";
            }
            if(Retrieve[0].fullness >= 100 && Retrieve[0].fullness >=100 && Retrieve[0].energy >=100){
                return View("win");
            }
            else{
                return RedirectToAction("Index", Retrieve[0]);

            }
           
        }

        [HttpPost]
        [Route("Play")]

        public IActionResult Play(){
            List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");
            Random chance = new Random();
            int test = chance.Next(0,4);
            if(test == 3){
                Retrieve[0].energy -=5;
                TempData["Message"] = "Your NIJNA DOES NOT WANT TO PLAY Energy Decrease by 5";
                HttpContext.Session.SetObjectAsJson("Ninjaman", Retrieve);
                return RedirectToAction("Index", Retrieve[0]);
            }
            else{
                int before = Retrieve[0].happiness;
                Retrieve[0].Playtime();
                int after = before - Retrieve[0].happiness;
                TempData["Message"] = $"You played some Poker with your NINJA, Energy decreased by 5 and happiness gained {after}";
                HttpContext.Session.SetObjectAsJson("Ninjaman", Retrieve);
                
            }
            if(Retrieve[0].fullness >= 100 && Retrieve[0].fullness >=100 && Retrieve[0].energy >=100){
                return View("win");
            }
            if(Retrieve[0].energy <=0){
                return View("loser");
            }
            else{
                return RedirectToAction("Index", Retrieve[0]);
            }
        }
        
        [HttpPost]
        [Route("Sleepy")]

        public IActionResult Snooze(){
            List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");
            Retrieve[0].Sleepy();
            TempData["Message"] = "Your energy has increased by 15 after a nap, however your Fullness and Happiness decreased by 5";
            HttpContext.Session.SetObjectAsJson("Ninjaman", Retrieve);

            if(Retrieve[0].fullness >= 100 && Retrieve[0].fullness >=100 && Retrieve[0].energy >=100){
                return View("win");
            }
            if(Retrieve[0].fullness <=0 || Retrieve[0].happiness <=0){
                return View("loser");

            }
            return RedirectToAction("Index", Retrieve[0]);

        }
        [HttpPost]
        [Route("Work")]

        public IActionResult Work(){
          List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");  
          int mealsBefore = Retrieve[0].meals;
          Retrieve[0].Worky();
          int mealsAfter = Retrieve[0].meals - mealsBefore;
          TempData["Message"] = $"Your Ninja put in some work! Enegry decreased by 5 and you earned {mealsAfter} meals";
          HttpContext.Session.SetObjectAsJson("Ninjaman", Retrieve);
          
          if(Retrieve[0].energy <=0){
                return View("loser");
            }
          else{
              return RedirectToAction("Index", Retrieve[0]);
          }
          



        }
        [HttpPost]
        [Route("Flush")]
        public IActionResult Flush(){
            List<Ninja> Retrieve = HttpContext.Session.GetObjectFromJson<List<Ninja>>("Ninjaman");
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

        

    }

        
}
