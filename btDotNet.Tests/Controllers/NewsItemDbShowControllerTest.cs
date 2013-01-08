using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using btDotNet.Controllers;

namespace btDotNet.Tests.Controllers
{
    [TestClass]
    public class NewsItemDbShowControllerTest
    {
        [TestMethod]
        public void TestNewsItemDbIndexPageLoad()
        {
            // Arrange
            var controller = new NewsItemDbShowController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("The NewsItemDb index has loaded.", result.ViewBag.Message);
        }
    }
}
