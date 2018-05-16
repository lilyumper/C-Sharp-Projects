using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restauranter.Controllers{
	
    public class RestauranterController:Controller{
        private RestauranterContext _context;
        public RestauranterController(RestauranterContext context){
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                Reviews NewReview = new Reviews{
                    Name = model.Name,
                    Resturant = model.Resturant,
                    Review = model.Review,
                    Stars = model.Stars,
                    Attended = model.Attended


                };
                _context.Add(NewReview);
                _context.SaveChanges();
               
                return RedirectToAction("Success");
            }
            return View("Index",model);
        }

        [HttpGet]
        [Route("success")]

        public IActionResult Success(){
            ViewBag.Stuff = _context.Reviews.OrderByDescending(r => r.Attended).ToList();

            return View("success");

        }
    }
}
