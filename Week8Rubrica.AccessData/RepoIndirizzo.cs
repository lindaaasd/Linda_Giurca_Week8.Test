using System;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.Repositories;

namespace Week8Rubrica.RepositoryADO
{
    public class RepoIndirizzo : IRepositoryIndirizzo
    {
        public static List<Indirizzo> ListaIndirizzi = new();

        public bool Add(Indirizzo indirizzo)
        {
            ListaIndirizzi.Add(indirizzo);
            return true;
        }

        public List<Indirizzo> GetByContactID(int id)
        {
            List<Indirizzo> IndirizziContatto = new List<Indirizzo>();

            foreach (var indirizzo in ListaIndirizzi)
            {
                if (id == indirizzo.ID)
                {
                    IndirizziContatto.Add(indirizzo);
                }
            }

            return IndirizziContatto;
        }
    }
}

