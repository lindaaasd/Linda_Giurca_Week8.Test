using System;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.Repositories;

namespace Week8Rubrica.Core.BusinessLayer
{
	public class MainBusinessLayer:IBusinessLayer
	{
        private readonly IRepositoryContatti repoContatti;
        private readonly IRepositoryIndirizzo repoIndirizzo;

        public MainBusinessLayer(IRepositoryContatti repoContact, IRepositoryIndirizzo repoAdress)
		{
            repoContatti = repoContact;
            repoIndirizzo = repoAdress;
		}

        public Esito AggiungiContatto(string nome, string cognome)
        {
            Contatto newContact = new Contatto();
            newContact.Nome = nome;
            newContact.Cognome = cognome;

            var added = repoContatti.Add(newContact);

            if (added)
            {
                return new Esito { Message = $"{nome} {cognome} inserito alla rubrica!", isOk = true };

            } else
            {
               return new Esito { Message = $"Il contatto non è stato inserito, riprova", isOk = false };
            }
        }

        public Esito AggiungiIndirizzo(Indirizzo indirizzo)
        {
            bool added = repoIndirizzo.Add(indirizzo);

            if (added)
                return new Esito { Message = "Indirizzo inserito in rubrica", isOk = true };
            else
                return new Esito { Message = "Errore nell'inserimento", isOk = false };
        }

        public Esito CancellaContatto(Contatto contatto)
        {
            List<Indirizzo> indirizziContatto = repoIndirizzo.GetByContactID(contatto.ID);

            if (indirizziContatto.Count == 0)
            {
                repoContatti.Delete(contatto);
                return new Esito { Message = "Contatto cancellato dalla rubrica", isOk = true };
            }
            else
                return new Esito { Message = "Contatto non cancellato, riprova", isOk = false };
        }

        public List<Contatto> GetAllContatti()
        {
            return repoContatti.GetAll();
        }

        public Contatto GetContattoById(int id)
        {
            return repoContatti.GetById(id);
        }
    }
}

