using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Banker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Banker.Controllers{
    public class BankerController:Controller{
        private BankerContext _context;

        public BankerController(BankerContext context){
            _context = context;
        }
        [HttpGet]
        [Route("")]

        public IActionResult Create(){
            return View("register");
        }

        [HttpPost]
        [Route("RegisterNew")]
        public IActionResult RegisterNew(RegisterViewModel model){
            int? Id = HttpContext.Session.GetInt32("Id");
            if(Id !=null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid){
                User ExistingUser = _context.Users.SingleOrDefault(u => u.email == model.email);
                if(ExistingUser !=null){
                    ModelState.AddModelError("email","This Email already exist! Please enter another email");
                    return View("register", model);
                    
                }
                PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
                model.password = Hasher.HashPassword(model, model.password);
                User user = new User{
                    fname = model.fname,
                    lname= model.lname,
                    email = model.email,
                    password = model.password,
                    balance = 0
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("Index");
            }
            return View("register", model);
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(){
            int? Id = HttpContext.Session.GetInt32("Id");
            if(Id !=null){
                return RedirectToAction("Index");
            }
            return View("login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel model){
            int? Id = HttpContext.Session.GetInt32("Id");
            if(Id !=null){
                return RedirectToAction("Index");

            }
            if(ModelState.IsValid){
                if(!_context.Users.Any(u => u.email == model.email)){
                    ModelState.AddModelError("email", "Email is not found! Please login with the correct email or register.");
                    return View("login");
                }
                var user = _context.Users.SingleOrDefault(u => u.email == model.email);
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.password, model.password)){
                    HttpContext.Session.SetInt32("Id", user.Id);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("email", "Email/Password are wrong.");
                return View("login");
            }
            return View("login");
        }


        [HttpGet]
        [Route("Home")]
        public IActionResult Index(){
            if(HttpContext.Session.GetInt32("Id") == null){
                return RedirectToAction("Index");
            }
            var user = _context.Users.Include( u => u.transactions).SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
            user.transactions = user.transactions.OrderByDescending(t=>t.created_at).ToList();

            ViewBag.user = user;

            
            return View("Index");
        }

        [HttpPost]
        [Route("Moneyact")]
        public IActionResult Moneyact(BalanceViewModel act)
        {
            if(HttpContext.Session.GetInt32("Id") == null){
                return RedirectToAction("login");
            }
            var user = _context.Users.Include(u => u.transactions).SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
            if(ModelState.IsValid){
                System.Console.WriteLine("PLEASE");
                if(act.amount < 0){
                    if(user.balance + act.amount < 0){
                        ModelState.AddModelError("amount", "You don't  have enough money to withdraw that amount!");
                        user = _context.Users.Include( u => u.transactions).SingleOrDefault(u => u.Id == HttpContext.Session.GetInt32("Id"));
                        user.transactions = user.transactions.OrderByDescending(t => t.created_at).ToList();
                        ViewBag.user = user;
                        return View("Index");
                    }
                }
                Transaction newtransaction = new Transaction{
                    amount = act.amount,
                    userid = user.Id,
                    user = user
                };
                _context.Transactions.Add(newtransaction);
                user.balance += act.amount;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            user.transactions = user.transactions.OrderByDescending(t => t.created_at).ToList();
            ViewBag.user = user;
            return View("Index");
        }

        [HttpPost]
        [Route("Logout")]

        public IActionResult logout(){
            HttpContext.Session.Remove("Id");
            return RedirectToAction("login");
        }



    }
}
