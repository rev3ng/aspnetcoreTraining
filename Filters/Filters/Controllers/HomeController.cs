using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
	[Message("To jest filtr o zasięgu kontrolera.")]
    public class HomeController : Controller
    {
		[Message("To jest pierwszy filtr o zasięgu akcji.")]
		[Message("To jest drugi filtr o zasięgu akcji.")]
	    public ViewResult Index()
	    {
		    return View("Message",
			    "To jest metoda akcji Index() kontrolera HomeController");
	    }

    }
}