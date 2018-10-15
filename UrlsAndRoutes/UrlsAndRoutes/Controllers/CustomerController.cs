using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
	public class CustomerController : Controller
	{
		[Route("app/[controller]/actions/[action]/{id?}")]
		public ViewResult Index() => View("Result",
			new Result
			{
				Controller = nameof(CustomerController),
				Action = nameof(Index)
			});

		//[Route("[controller]/MyAction")]
		public ViewResult List(string id)
		{
			Result r = new Result
			{
				Action = nameof(List),
				Controller = nameof(CustomerController)
			};

			r.Data["id"] = id;
			r.Data["catchall"] = RouteData.Values["catchall"];

			return View("Result", r);
		}
	}
}