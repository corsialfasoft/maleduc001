using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maled001;
using Maled001.Controllers;

namespace Maled001.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void Index() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void OrderRequest() {
            HomeController controller = new HomeController();
            ViewResult result = controller.OrderRequest() as ViewResult;
            Assert.IsNull(result.ViewBag.Message);
        }
        [TestMethod]
        public void PreviewOrder() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNull(result.ViewBag.prodotti);
        }
        [TestMethod]
        public void ProductDetail() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
             Assert.IsNull(result.ViewBag.Message);
        }
        [TestMethod]
        public void ProductList() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
             Assert.IsNull(result.ViewBag.Message);
        }
    }
}
