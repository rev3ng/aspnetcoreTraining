using System;
using DependencyInjection.Controllers;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace DITests
{
	public class DITests
	{
		[Fact]
		public void ControllerTest()
		{
			var data = new[] {new Product {Name = "Test", Price = 100M}};
			var mock = new Mock<IRepository>();
			mock.SetupGet(m => m.Products).Returns(data);

			HomeController controller = new HomeController(mock.Object);

			ViewResult result = controller.Index();

			Assert.Equal(data, result.ViewData.Model);
		}
	}
}
