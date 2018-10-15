﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
	public class DerivedController : Controller
	{
		public ViewResult Index() => View("Result", $"To jest kontroler derivedController.");

		public ViewResult Headers() => View("DictionaryResult",
			Request.Headers.ToDictionary(kvp => kvp.Key,
				kvp => kvp.Value.First()));
	}
}
