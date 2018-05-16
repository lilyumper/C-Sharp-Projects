using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LostinWoods.Models;
using System;
using LostinWoods.Factory;
using System.Collections.Generic;


namespace LostinWoods.Controllers{

    public class LostinWoodsController:Controller{
        private readonly TrailFactory trailFactory;
        public LostinWoodsController(){
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.stuff = trailFactory.FindaAll();
            return View("Index");
        }

        [HttpGet]
        [Route("/addtrail")]

        public IActionResult add(){
            return View("addtrail");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                Trails NewTrail = new Trails{
                    name = model.name,
                    description = model.description,
                    traillength = model.traillength,
                    elevation = model.elevation,
                    log = model.log,
                    lat = model.lat
                };
                trailFactory.Create(NewTrail);
                return RedirectToAction("Index");
            }
            return View("addtrail",model);
        }

        [HttpGet]
        [Route("/show/{id}")]

        public IActionResult Show(int id){
            int trips = id;
            ViewBag.Trip = trailFactory.FindByID(trips);
            System.Console.WriteLine(ViewBag.Trip.id);
            return View("show");
        }
    }
    
}
