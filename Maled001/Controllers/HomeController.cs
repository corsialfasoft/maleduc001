using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maled001.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult OrderRequest() {
            return View();
        }
        public ActionResult PreviewOrder() {
            return View();
        }
        public ActionResult ProductDetail() {
            return View();
        }
        public ActionResult ProductList() {
            return View();
        }

        //Da implementare
        public ActionResult SendRequest() {
            return View();
        }

        //Da implementare
        [HttpGet]
        public ActionResult Product() {
            return View();
        }
        //Da implementare
        public ActionResult Pulisci() {
            return View();
        }

        [HttpPost]
        //Da implementare
        public ActionResult OrderRequest(string codice, string descrizione) {
            return View();
        }
        [HttpPost]
        //Da implementare
        public ActionResult AddToOrder(int id) {
            return View();
        }
    }
}