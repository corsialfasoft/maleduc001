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

        [HttpGet]
        public ActionResult Product(int id) {
            ViewBag.prodotto = dm.SearchByCode(id);
            return View("ProductDetail");
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
        public ActionResult AddToOrder(string codice, string qta) {
            Prodotto product = dm.SearchByCode(int.Parse(codice));
            product.Quantita = int.Parse(qta);
            List<Prodotto> products = Session["products"] as List<Prodotto>;
            if(products == null){
                products = new List<Prodotto>();
            }
            products.Add(product);
            Session["products"] = products;
            ViewBag.Message="Richiesta d'ordine inserita nel carrello";
            return View("OrderRequest");
        }
    }
}