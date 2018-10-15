using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes.Infrastructure
{
	public class WeekDayConstraint : IRouteConstraint
	{
		private static string[] days = new[]
		{
			"pon", "wt", "sr",
			"czw", "pt", "sob", "nie"
		};

		public bool Match(HttpContext httpContext, IRouter route, 
			string routeKey, RouteValueDictionary values,
			RouteDirection routeDirection)
		{
			return days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
		}
	}
}
