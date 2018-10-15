using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Infrastructure;


namespace ControllersAndActions.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index() => View("SimpleForm");

		/* public void ReceiveForm(string name, string city)
		 {

			 Response.StatusCode = 200;
			 Response.ContentType = "text/html";
			 byte[] content = Encoding.ASCII
				 .GetBytes($"<html><body>{name} mieszka w mieście {city}. </body>");

			 Response.Body.WriteAsync(content, 0, content.Length);
			 //return View("Result", $"{name} mieszka w mieście {city}");
		 }

		 public void ReceiveForm(string name, string city) => new CustomHttpResult
		 {
			 Content = $"{name} mieszka w mieście {city}"
		 };

	 */

		[HttpPost]
		public RedirectToActionResult ReceiveForm(string name, string city)
		{
			TempData["name"] = name;
			TempData["city"] = city;
			return RedirectToAction(nameof(Data));
		}

		public ViewResult Data()
		{
			string name = TempData["name"] as string;
			string city = TempData["city"] as string;
			string status = TempData["city"] as string ?? "0";
			return View("Result", $"{name} mieszka w mieście {city}. {status}");
		}

		
	}
}