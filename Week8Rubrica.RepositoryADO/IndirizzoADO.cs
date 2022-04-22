using System;
using System.Data;
using System.Data.SqlClient;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.Repositories;

namespace Week8Rubrica.RepositoryADO
{
	public class IndirizzoADO:IRepositoryIndirizzo
	{
		string connectionString = @"Server=localhost; Database=Rubrica; User Id = sa; Password = popdocker356..9!";

        public bool Add(Indirizzo item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Indirizzo values (@tipologia," +
                    " @via, @citta, @cap, @provincia, @nazione, @IDContatto)", connection);
                command.Parameters.AddWithValue("@tipologia", item.Tipologia);
                command.Parameters.AddWithValue("@via", item.Via);
                command.Parameters.AddWithValue("@citta", item.Citta);
                command.Parameters.AddWithValue("@cap", item.CAP);
                command.Parameters.AddWithValue("@provincia", item.Provincia);
                command.Parameters.AddWithValue("@nazione", item.Nazione);
                command.Parameters.AddWithValue("@IDContatto", item.ID);

                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 1)
                    return true;
                else
                    return false;
            }
        }

        public List<Indirizzo> GetByContactID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Indirizzo where ID=@id", connection);
                command.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = command.ExecuteReader();

                List<Indirizzo> indirizzi = new List<Indirizzo>();
                while (reader.Read())
                {
                    Indirizzo indirizzo = new Indirizzo();
                    indirizzo.ID = (int)reader["ID"];

                    indirizzi.Add(indirizzo);
                }
                connection.Close();

                return indirizzi;
            }
        }
    }
}

