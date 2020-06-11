using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using opg_201910_interview.Controllers;
using System;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestHome()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);

            var controller = new HomeController(configuration.Object);
            var result = controller.Index();
            Assert.IsAssignableFrom<ViewResult>(result);

        }
    }
}
