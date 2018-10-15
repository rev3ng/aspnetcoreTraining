using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
	    private IRepository repository;
	    private ProductTotalizer totalizer;

	    public HomeController(IRepository repo, ProductTotalizer total)
	    {
		    repository = repo;
		    totalizer = total;
	    }

	    public ViewResult Index()
	    {
		    ViewBag.HomeController = repository.ToString();
		    ViewBag.Totalizer = totalizer.Repository.ToString();
		    ViewBag.Total = totalizer.Total;
		    return View(repository.Products);
	    }
    }
}