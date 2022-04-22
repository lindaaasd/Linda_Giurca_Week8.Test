using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.Repositories;

namespace Week8Rubrica.AccessData;
public class RepoContatti : IRepositoryContatti
{
    public static List<Contatto> ListaContatti = new List<Contatto>()
        {
            new Contatto{ID = 1, Nome = "Linda", Cognome = "Giurca"},
            new Contatto{ID = 2, Nome = "Riccardo", Cognome = "Moschetti"},
            new Contatto{ID = 3, Nome = "Eva", Cognome = "Moschetti"},

        };

    public bool Add(Contatto item)
    {
        item.ID = GenerateID();
        ListaContatti.Add(item);

        return true;
    }

    private int GenerateID()
    {
        if (ListaContatti.Count == 0)
        {
            return 1;
        }

        else
        {
            int max = 0;
            foreach(var contatto in ListaContatti)
            {
                max = contatto.ID > max ? contatto.ID : max++;
            }

            return max;
        }
    }

    public bool Delete(Contatto contatto)
    {
        ListaContatti.Remove(contatto);
        return true;
    }

    public List<Contatto> GetAll()
    {
        return ListaContatti;
    }

    public Contatto GetById(int id)
    {
        foreach ( var contatto in ListaContatti)
        {
           if(id == contatto.ID)
            {
                return contatto;
            }
        }

        return null;
    }
}

