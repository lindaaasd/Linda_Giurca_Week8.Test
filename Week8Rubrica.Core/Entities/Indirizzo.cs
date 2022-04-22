using System;
namespace Week8Rubrica.Core.Entities
{
	public class Indirizzo
	{
        public int ID { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }


        public int IDContatto { get; set; }
        public Contatto Contatto { get; set; }

        public Indirizzo()
		{
		}
	}
}

