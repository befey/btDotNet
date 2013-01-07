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
        [ClassInitialize]
        public void InitializetestDb()
        {
            
        }

        [TestMethod]
        public void TestIndexPageLoad()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("The index has loaded.", result.ViewBag.Message);
        }
    }
}
