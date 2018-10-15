using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Areas.Admin.Models;

namespace UrlsAndRoutes.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class HomeController : Controller
	{
		private Person[] data = new Person[]
		{
			new Person {City = "Londyn", Name = "Alicja"},
			new Person {City = "Nowy Jork", Name = "Bartek"},
			new Person {City = "Warszawa", Name = "Janek"}
		};

        public IActionResult Index()
        {
            return View(data);
        }
    }
}