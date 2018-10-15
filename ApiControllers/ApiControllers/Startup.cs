﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ApiControllers
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IRepository, MemoryRepository>();
			services.AddMvc().AddXmlDataContractSerializerFormatters()
				.AddMvcOptions(options =>
				{
					options.FormatterMappings.SetMediaTypeMappingForFormat("xml",
						new MediaTypeHeaderValue("application/xml"));
					options.RespectBrowserAcceptHeader = true;
					options.ReturnHttpNotAcceptable = true;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStatusCodePages();
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	}
}
