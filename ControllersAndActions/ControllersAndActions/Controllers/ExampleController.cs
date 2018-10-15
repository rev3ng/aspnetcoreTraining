using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Http;


namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
	    public StatusCodeResult Index6() => NotFound();

	    public ContentResult Index3() => Content("[\"Alicja\",\"Bartek\",\"Janek\"]", "application/json");
	    public VirtualFileResult Index5() => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
	    public ObjectResult Index4() => Ok(new[] { "Alicja", "Bartek", "Janek" });
	    public JsonResult Index2() => Json(new[] { "Alicja", "Bartek", "Janek" });
		public ViewResult Index()
	    {
		    ViewBag.Message = "Witaj";
		    ViewBag.Data = DateTime.Now;
		    return View();
	    }

	    public ViewResult Result() => View("Index", DateTime.Now);

	    public RedirectResult Redirect() => Redirect("/Example/Index");

	    public RedirectToRouteResult RedirectToRoute() =>
		    RedirectToRoute(new
		    {
			    controller = "Example",
			    action = "Index",
			    ID = "MyID"
		    });


	    [SuppressMessage("ReSharper", "Mvc.ActionNotResolved")]
	    [SuppressMessage("ReSharper", "Mvc.ControllerNotResolved")]
	    public RedirectToActionResult RedirToAct() => RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
    }
}