using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreSandbox.Data;

namespace CoreSandbox.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public IActionResult Index()
        {
            var widgets = db.Widgets;
            ViewData["widgets"] = widgets;
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
