﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.Infrastructure;
using Users.Models;

namespace Users
{



	public class Startup
	{
		public Startup(IConfiguration configuration) =>
			Configuration = configuration;

		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();

			services.AddDbContext<AppIdentityDbContext>(options =>
				options.UseSqlServer(
					Configuration["Data:SportStoreIdentity:ConnectionString"]));

			services.AddIdentity<AppUser, IdentityRole>(opts =>
				{
					opts.User.RequireUniqueEmail = true;
					//opts.User.AllowedUserNameCharacters = "qwertyuioplkjhgfdsazxcvbnm";
					opts.Password.RequiredLength = 6;
					opts.Password.RequireNonAlphanumeric = false;
					opts.Password.RequireLowercase = false;
					opts.Password.RequireUppercase = false;
					opts.Password.RequireDigit = false;
				}).AddEntityFrameworkStores<AppIdentityDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStatusCodePages();
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();
		}
	}
}
