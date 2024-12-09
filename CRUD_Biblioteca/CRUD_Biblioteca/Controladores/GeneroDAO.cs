using CRUD_Biblioteca.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Biblioteca.Controladores
{
    internal class GeneroDAO
    {
        public static void Add(Genero genero)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();
            SqlCommand insert = new SqlCommand
                (
                "INSERT into dbo.Genero(Nombre) values(@nombre)",
                bd
                );

            insert.Parameters.AddWithValue("@nombre", genero.Nombre);

            insert.ExecuteNonQuery();
            bd.Close();
        }

        public static void Delete(Genero genero)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
           bd.Open ();

            SqlCommand delete = new SqlCommand
                (
                "DELETE from dbo.Genero where ID_Genero = @id",
                bd
                );

            delete.Parameters.AddWithValue("@id", genero.ID_Genero);
            delete.ExecuteNonQuery();

            bd.Close ();
        }

        public static void Update(int idgenero, string nombre)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");

            bd.Open();

            SqlCommand update = new SqlCommand
                (
                "UPDATE dbo.Genero SET Nombre = @nombre where ID_Genero = @id",
                bd
                );

            update.Parameters.AddWithValue("@nombre", nombre);
            update.Parameters.AddWithValue("id", idgenero);

            update.ExecuteNonQuery();
            bd.Close() ;
        }

        public static List<Genero> GetItems()
        {

            List<Genero> generos = new List<Genero>();
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open ();

            SqlCommand select = bd.CreateCommand ();

            select.CommandText = "selet from * dbo.Genero";

            SqlDataReader reader = select.ExecuteReader ();

            while (reader.Read())
            {
                Genero genero = new Genero();

                genero.ID_Genero = reader.GetInt32 (0);
                genero.Nombre = reader.GetString (1);
                generos.Add(genero);
            }
            reader.Close ();
            select.ExecuteReader();
            bd.Close () ;
            return generos ;
        }
    }
}
