using System;
using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActionsTests
{
	public class ActionTests
	{
		/*
		[Fact]
		public void ViewSelected()
		{
			HomeController controller = new HomeController();

			ViewResult result = controller.ReceiveForm("Tester", "Testerowo");

			Assert.Equal("Result", result.ViewName);
		}
		*/

		[Fact]
		public void ModelObjectType()
		{
			ExampleController controller = new ExampleController();

			ViewResult result = controller.Result();

			Assert.IsType<DateTime>(result.ViewData.Model);
		}

		[Fact]
		public void ModelObjectTypeViewBag()
		{
			ExampleController controller = new ExampleController();

			ViewResult result = controller.Index();

			Assert.IsType<string>(result.ViewData["Message"]);
			Assert.IsType<DateTime>(result.ViewData["Data"]);
			Assert.Equal("Witaj", result.ViewData["Message"]);
		}

		[Fact]
		public void Redirect()
		{
			ExampleController controller = new ExampleController();

			RedirectResult result = controller.Redirect();

			Assert.Equal("/Example/Index", result.Url);
			Assert.False(result.Permanent);
		}

		[Fact]
		public void Redirection()
		{
			ExampleController controller = new ExampleController();

			RedirectToRouteResult result = controller.RedirectToRoute();
			
			Assert.False(result.Permanent);
			Assert.Equal("Example", result.RouteValues["controller"]);
			Assert.Equal("Index", result.RouteValues["action"]);
			Assert.Equal("MyID", result.RouteValues["id"]);
		}

		[Fact]
		public void RedirectionToAction()
		{
			ExampleController controller = new ExampleController();

			RedirectToActionResult result = controller.RedirToAct();

			Assert.Equal("Index", result.ActionName);
			Assert.False(result.Permanent);
			Assert.Equal("HomeController", result.ControllerName);
		}

		[Fact]
		public void JsonRes()
		{
			ExampleController controller = new ExampleController();

			JsonResult result = controller.Index2();

			Assert.Equal(new[] {"Alicja", "Bartek", "Janek"}, result.Value);
		}

		[Fact]
		public void StatusCodes()
		{
			ExampleController controller = new ExampleController();

			StatusCodeResult result = controller.Index6();

			Assert.Equal(404, result.StatusCode);
		}
	}
}
