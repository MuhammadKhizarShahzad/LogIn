using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogIn.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LogIn.Controllers
{
    public class UserController : Controller
    {
        private LogInContext DB = null;
        public UserController(LogInContext _Db)
        {
            DB = _Db;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(User MKS)
        {
            User DB_User = DB.User.Where(m => m.Username==MKS.Username && m.Pasword==MKS.Pasword).FirstOrDefault<User>();
            if (DB == null)
            {
                ViewBag.msg = "Invaild Usernaem/Pasword";
                return View();
            }
            HttpContext.Session.SetString("LoggedInUser", JsonConvert.SerializeObject(DB_User));
            return RedirectToAction("Profile");
        }
        public IActionResult Profile()
        {
            User LoggedIn_User = null;
            try
            {
                LoggedIn_User = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("LoggedInUser"));
            }
            catch
            {

            }
                if (LoggedIn_User == null)
            {
                return RedirectToAction("login");
            }
                
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}