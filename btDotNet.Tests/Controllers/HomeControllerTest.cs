using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using btDotNet;
using btDotNet.Controllers;

namespace btDotNet.Tests.Controllers
{
    
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestIndexPageLoad()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("The index has loaded.", result.ViewBag.Message);
        }
    }
}
