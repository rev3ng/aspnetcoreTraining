using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cities3.Components
{
	public class TimeViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(DateTime.Now);
		}
	}
}
