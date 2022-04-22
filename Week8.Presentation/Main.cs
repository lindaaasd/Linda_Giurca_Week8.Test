using System;
using Week8Rubrica.AccessData;
using Week8Rubrica.Core.BusinessLayer;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.RepositoryADO;

namespace Week8Rubrica.Presentation
{
    public class Main
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepoContatti(), new RepoIndirizzo());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepoContatti(), new RepoIndirizzo());

        public static void Start()
        {
            bool continua = true;
            int scelta;

            do
            {
                scelta = PrintMenu();

                switch (scelta)
                {
                    case 1:
                        VisualizzaContatti();
                        break;
                    case 2:
                        AggiungiContatti();
                        break;
                    case 3:
                        AggiungiIndirizzoContatto();
                        break;
                    case 4:
                        EliminaContatto();
                        break;
                    default:
                        continua = false;
                        Console.WriteLine("Byeeeeeee");
                        break;
                }

            } while (continua);
        }

        private static void EliminaContatto()
        {
            Console.WriteLine("Quale contatto vuoi eliminare? Inserisci il suo ID ");
            VisualizzaContatti();

            int id = GetInt();

            Contatto contatto = bl.GetContattoById(id);

            if(contatto.Nome != null && contatto.Cognome != null)
            {
                Esito esito = bl.CancellaContatto(contatto);
                Console.WriteLine(esito.Message);
            } else
            {
                Console.WriteLine("Nessun contatto trovato con questo ID");
            }
        }

        private static int GetInt()
        {
            bool continua;
            int scelta;
            do
            {
                continua = int.TryParse(Console.ReadLine(), out scelta);

            } while (!continua);

            return scelta;
        }

        private static void AggiungiIndirizzoContatto()
        {
            Console.WriteLine("\nA quale contatto vuoi associare l'indirizzo? Inserisci suo ID");
            VisualizzaContatti();
            int id = GetInt();

            Contatto contatto = bl.GetContattoById(id);

            if (contatto != null)
            {
                Indirizzo indirizzo = new Indirizzo();
                indirizzo.Contatto = contatto;
                indirizzo.ID = contatto.ID;


                Console.Write("Tipologia indirizzo ( residenza / domicilio ) ");
                indirizzo.Tipologia = Console.ReadLine();
                Console.Write("Via: ");
                indirizzo.Via = Console.ReadLine();
                Console.Write("Città: ");
                indirizzo.Citta = Console.ReadLine();
                Console.Write("CAP: ");
                indirizzo.CAP = Console.ReadLine();
                Console.Write("Provincia: ");
                indirizzo.Provincia = Console.ReadLine();
                Console.Write("Nazione: ");
                indirizzo.Nazione = Console.ReadLine();

                Esito aggiunta = bl.AggiungiIndirizzo(indirizzo);
                Console.WriteLine(aggiunta.Message);

            }
            else
                Console.WriteLine("Errore! Nessun contatto trovato con questo ID");
        }

        private static void AggiungiContatti()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Esito esito = bl.AggiungiContatto(nome, cognome);
            Console.WriteLine(esito.Message);
        }

        private static void VisualizzaContatti()
        {
            List<Contatto> ListaContatti = bl.GetAllContatti();

            foreach(var contatto in ListaContatti)
            {
                Console.WriteLine(contatto);
            }
        }

        static int PrintMenu()
        {
            Console.WriteLine(" ** RUBRICA **");
            Console.WriteLine("1. Visualizza tutti contatti ");
            Console.WriteLine("2. Aggiungi un nuovo contatto ");
            Console.WriteLine("3. Aggiungi un indirizzo ad un utente");
            Console.WriteLine("4. Elimina un contatto ");
            Console.WriteLine("0. Esci");
            Console.WriteLine("Scelta > ");

            Int32.TryParse(Console.ReadLine(), out int scelta);
            return scelta;

        }
    }
}

