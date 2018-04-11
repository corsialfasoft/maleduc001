using System.Collections.Generic;
using Maled001;
public class Maled : IMaled {
	void IMaled.AddRequest(List<Prodotto> list) {
		throw new System.NotImplementedException();
	}

	Prodotto IMaled.SearchByCode(int codice) {
		throw new System.NotImplementedException();
	}

	List<Prodotto> IMaled.SearchByDescrizione(string descrizione) {
		throw new System.NotImplementedException();
	}
}