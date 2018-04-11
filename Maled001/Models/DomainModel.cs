using System;
using System.Collections.Generic;
using Maled001;
using System.Linq;

namespace Maled001 {
    public class Maled : IMaled {
	    public void AddRequest(List<Prodotto> list) {
		    throw new System.NotImplementedException();
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
		    throw new System.NotImplementedException();
	    }
    }
}