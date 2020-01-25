using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABPatients.Models;

namespace ABPatients.Controllers
{
    public class HomeController : Controller
    {
        //Arshdeep Brar September 2019

        // Index is default action for this controller
        //this will display home page
        public IActionResult Index()
        {
            return View();
        }

        //this will display privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
