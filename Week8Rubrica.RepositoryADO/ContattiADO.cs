using System.Data;
using System.Data.SqlClient;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.Repositories;

namespace Week8Rubrica.RepositoryADO;

public class ContattiADO : IRepositoryContatti
{
    string connectionString = @"Server=localhost; Database=Rubrica; User Id = sa; Password = popdocker356..9!";

    public bool Add(Contatto contatto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Contatto values (@nome, @cognome)", connection);
            command.Parameters.AddWithValue("@nome", contatto.Nome);
            command.Parameters.AddWithValue("@cognome", contatto.Cognome);

            int rows = command.ExecuteNonQuery();
            connection.Close();

            if (rows == 1)
                return true;
            else
                return false;
        }
    }

    public bool Delete(Contatto contatto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Contatto where IdContatto=@id", connection);
            command.Parameters.AddWithValue("@id", contatto.ID);

            int rows = command.ExecuteNonQuery();
            connection.Close();

            if (rows == 1)
                return true;
            else
                return false;
        }
    }

    public List<Contatto> GetAll()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Contatto", connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Contatto> contatti = new List<Contatto>();
            while (reader.Read())
            {
                Contatto contatto = new Contatto();
                contatto.ID = (int)reader["IdContatto"];
                contatto.Nome = (string)reader["Nome"];
                contatto.Cognome = (string)reader["Cognome"];

                contatti.Add(contatto);
            }
            connection.Close();

            return contatti;
        }
    }

    public Contatto GetById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Contatto where IdContatto=@id", connection);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            Contatto contatto = new Contatto();

            while (reader.Read())
            {
                contatto.ID = (int)reader["IdContatto"];
                contatto.Nome = (string)reader["Nome"];
                contatto.Cognome = (string)reader["Cognome"];

            }
            connection.Close();

            return contatto;
        }
    }
}

