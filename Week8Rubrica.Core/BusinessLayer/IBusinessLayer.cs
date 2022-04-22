using System;
using Week8Rubrica.Core.Entities;

namespace Week8Rubrica.Core.BusinessLayer
{
	public interface IBusinessLayer
	{
        List<Contatto> GetAllContatti();
        Esito AggiungiContatto(string nome, string cognome);
        Contatto GetContattoById(int id);
        Esito AggiungiIndirizzo(Indirizzo indirizzo);
        Esito CancellaContatto(Contatto contatto);
    }
}

