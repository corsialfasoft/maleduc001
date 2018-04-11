using System.Collections.Generic;
using Maled001;
using System.Linq;
namespace Maled001{
	public class Maled : IMaled {
		RICHIESTEEntities DB;
		public void AddRequest(List<Prodotto> list) {
			throw new System.NotImplementedException();
		}

		public Prodotto SearchByCode(int codice) {
			throw new System.NotImplementedException();
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