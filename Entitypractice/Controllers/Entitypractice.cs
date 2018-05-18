using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entitypractice.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Entitypractice.Controllers{
	    public class EntitypracticeController:Controller{
            private EntitypracticeContext _context;

        

            public EntitypracticeController(EntitypracticeContext context)
            {
                _context = context;
            }
            [HttpGet]
            [Route("")]
            public IActionResult Index(){
                return View("Index");
        }

        // [HttpPost]
        // [Route("")]
        //     public IActionResult Create()
        // {
        //         Person NewPerson = new Person
        //         {
        //             Name = "Name",
        //             Email = "email@example.com",
        //             Password = "HashThisFirst",
        //             Age = 24
        //         };
            
        //         _context.Users.Add(NewPerson);
        //         // OR _context.Users.Add(NewPerson);
        //         _context.SaveChanges();
        //         return View();
        // }
    }
}
