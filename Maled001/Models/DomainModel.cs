﻿using System;
using System.Collections.Generic;

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