using System;
namespace Week8Rubrica.Core.Entities
{
	public class Contatto
	{

            public int ID { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }

            public List<Indirizzo> Indirizzi { get; set; } = new List<Indirizzo>();


            public override string ToString()
            {
                return $"{ID} \t Nome: {Nome} {Cognome}";
            }


        public Contatto()
		{
		}
	}
}

