using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace UsingViewComponents.Components
{
	public class PageSize : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("https://www.apress.com/gp");
			return View(response.Content.Headers.ContentLength);
		}
	}
}
