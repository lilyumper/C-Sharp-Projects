using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers{
    public class WeddingPlannerController:Controller{

        private WeddingPlannerContext _context;

        public WeddingPlannerController(WeddingPlannerContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index(){
            ViewBag.WrongPassword = null;
            ViewBag.WrongEmail = null;
            return View("Index");
        }

        // Create User
        [Route("register")]
        public IActionResult Register(RegisterViewUser user)
        {
            User ExistingUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            if(ExistingUser != null)
            {
                ModelState.AddModelError("Email","This Email already exists");
                return View("Index", user);
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterViewUser> Hasher = new PasswordHasher<RegisterViewUser>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User newuser = new User
                {
                    fName = user.fName,
                    lName = user.lName,
                    Email = user.Email,
                    Password = user.Password
                };
                _context.Users.Add(newuser);
                _context.SaveChanges();
                User ReturnedUser = _context.Users.SingleOrDefault(userID => userID.Email == user.Email);
                HttpContext.Session.SetInt32("Id", ReturnedUser.Id);
                return RedirectToAction("Dashboard");
            }
            return View("Index", user);
        }

        // Login User
        [Route("login")]
        public IActionResult Login(LoginValidate user)
        {
            if(ModelState.IsValid)
            {
                if(!_context.Users.Any(u => u.Email == user.lEmail))
                {
                    ViewBag.WrongEmail = "Email does not exist";
                    return View("Index");
                }
                var lUser = _context.Users.SingleOrDefault(u => u.Email == user.lEmail);
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(lUser, lUser.Password, user.lPassword))
                {
                    HttpContext.Session.SetInt32("Id", lUser.Id);
                    return RedirectToAction("Dashboard");
                }
                ViewBag.WrongPassword = "Password is incorrect";
                return View("Index");
            }
            ViewBag.WrongEmail = "Email invalid";
            ViewBag.WrongPassword = "Password invalid";
            return View("Index");
        }

        // Show all wedding plans
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Plans = _context.Plans.Include(p => p.creator).Include(u => u.users);
            ViewBag.CurrentUser = _context.Users.SingleOrDefault(cu => cu.Id == HttpContext.Session.GetInt32("Id"));
            var test = _context.Users.SingleOrDefault(cu => cu.Id == HttpContext.Session.GetInt32("Id"));
            var test2 = _context.Plans.Include(p => p.creator).Include(u => u.users);
            return View();
        }

        [Route("rsvp/{planId}")]
        public IActionResult Attend(int planId)
        {
            Wedding weddingplans = _context.Weddings.SingleOrDefault(wp => wp.PlanId == planId && wp.UserId == HttpContext.Session.GetInt32("Id"));
            if(weddingplans != null)
            {
                return RedirectToAction("Dashboard");
            }
            Wedding Attending = new Wedding
            {
                PlanId = planId,
                UserId = (int)HttpContext.Session.GetInt32("Id")
            };
            _context.Weddings.Add(Attending);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // IF the planId is equal to the planID in the ManyToMany table & the userId is also equal to your session, then this will pull the plan with both values.
        [Route("unrsvp/{planId}")]
        public IActionResult UnAttend(int planId)
        {
            Wedding Attending = _context.Weddings.SingleOrDefault(at => at.PlanId == planId && at.UserId == HttpContext.Session.GetInt32("Id"));
            _context.Weddings.Remove(Attending);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Route("cancel/{planId}")]
        public IActionResult Delete(int planId)
        {
            Plan cancellation = _context.Plans.SingleOrDefault(pl => pl.Id == planId);
            _context.Plans.Remove(cancellation);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // Create Wedding plan page
        [Route("planning")]
        public IActionResult Planning()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            return View("Planning");
        }

        // Create Wedding plan
        [Route("create_plan")]
        public IActionResult CreatePlan(RegisterViewPlan plan)
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                Plan newPlan = new Plan
                {
                    PersonOne = plan.PersonOne,
                    PersonTwo = plan.PersonTwo,
                    Date = plan.Date,
                    Address = plan.Address,
                    userid = HttpContext.Session.GetInt32("Id")
                };
                _context.Plans.Add(newPlan);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Planning", plan);
        }

        [Route("wedding/{planId}")]
        public IActionResult SingleWedding(int planId)
        {
            ViewBag.Wedding = _context.Plans.Where(p => p.Id == planId).Include(up => up.users).ThenInclude(u => u.user);
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
