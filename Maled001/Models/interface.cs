using System.Collections.Generic;

namespace Maled001 {
    public interface IMaled {
        Prodotto SearchByCode (int codice);
        List<Prodotto> SearchByDescrizione (string descrizione);
        void AddRequest (List<Prodotto> list);
    }
}