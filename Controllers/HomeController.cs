using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using random_pass.Models;
using Microsoft.AspNetCore.Http;

namespace random_pass.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("attempt") == null)
            {
                HttpContext.Session.SetInt32("attempt", 1); 
            }
            else
            {
                int count = HttpContext.Session.GetInt32("attempt").GetValueOrDefault(); 
                HttpContext.Session.SetInt32("attempt", count + 1);
            }
            ViewBag.count=HttpContext.Session.GetInt32("attempt");
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newstring = new char[14];
            for(int i = 0; i< newstring.Length;i++){
                newstring[i]=chars[rand.Next(0,36)];
            }
            string newString = new String(newstring);
            ViewBag.password=newString;
            return View("index");
        }

    }
}
