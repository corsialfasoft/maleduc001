using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maled001.Controllers {
    public class HomeController : Controller {
        Maled dm = new Maled();
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
        public ActionResult OrderRequest(string codice, string descrizione) {
            if (String.IsNullOrEmpty(codice) && int.TryParse(codice, out int codiceint)) {
                ViewBag.prodotto = dm.SearchByCode(codiceint);
            } else if (String.IsNullOrEmpty(descrizione)) {
                ViewBag.prodotti = dm.SearchByDescrizione(descrizione);
            }
            if (ViewBag.prodotto!=null) {
                return View("ProductDetail");
            } else if (ViewBag.prodotti!=null) {
                return View("ProductList");
            } else {
                ViewBag.Message = "Nessun prodotto trovato...!";
                return View();
            }
        }

        [HttpPost]
        //Da implementare
        public ActionResult AddToOrder(int id) {
            return View();
        }
    }
}