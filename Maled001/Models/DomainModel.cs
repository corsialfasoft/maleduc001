using System;
using System.Collections.Generic;
using System.Linq;

namespace Maled001{
    public class Maled : IMaled {
        RICHIESTEEntities DB;
	    public void AddRequest(List<Prodotto> list) {
            try{
                if(list != null){
                    using(DB = new RICHIESTEEntities()){
                        RichiesteSet ordinisettati = new RichiesteSet();
                        ordinisettati.data = DateTime.Now;
                        DB.RichiesteSet.Add(ordinisettati);
                        DB.SaveChanges();
                        foreach(Prodotto p in list){
                            RichiesteProdotti rp = new RichiesteProdotti();
                            rp.ProdottiSet = DB.ProdottiSet.Find(p.Codice);
                            rp.RichiesteSet = ordinisettati;
                            rp.quantita = p.Quantita;
                            DB.RichiesteProdotti.Add(rp);
                            DB.SaveChanges();
                        }
                    }
                }
            }catch(Exception e) {
                throw e;
            }
	    }

	    public Prodotto SearchByCode(int codice) {
		    Prodotto trovato = new Prodotto();
            using (var db = new RICHIESTEEntities()) {
                var query = from prod in db.ProdottiSet
                            where prod.Id == codice
                            select prod;
                List<ProdottiSet> prodottiTrovati = query.ToList<ProdottiSet>();
                if (prodottiTrovati.Count>0) {
                    trovato.Codice = prodottiTrovati[0].Id;
                    trovato.Descrizione = prodottiTrovati[0].descrizione;
                    trovato.Quantita = prodottiTrovati[0].quantita;
                }
            }
            return trovato;
	    }

		public List<Prodotto> SearchByDescrizione(string descrizione) {
			List<Prodotto> output = new List<Prodotto>();
			using(DB = new RICHIESTEEntities()){
				IEnumerable<ProdottiSet> query = from p in DB.ProdottiSet where p.descrizione.Contains(descrizione) select p;
				foreach(ProdottiSet prod in  query){
					Prodotto tmp = new Prodotto();
					tmp.Codice = prod.Id;
					tmp.Descrizione = prod.descrizione;
					output.Add(tmp);
				}
			}
			return output; 
		}
	}
}