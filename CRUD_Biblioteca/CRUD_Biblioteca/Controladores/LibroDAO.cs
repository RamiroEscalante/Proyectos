 using CRUD_Biblioteca.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CRUD_Biblioteca.Controladores
{
    internal class LibroDAO
    {
        public static void Add(Libro libro)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();

            SqlCommand insert = new SqlCommand
                (
                "INSERT INTO dbo.Libro(Titulo,Autor,ID_Genero) values(@titulo,@autor,@idgenero)",
                bd
                );

            insert.Parameters.AddWithValue("@titulo", libro.Titulo);
            insert.Parameters.AddWithValue("@autor", libro.Autor);
            insert.Parameters.AddWithValue("@idgenero", libro.ID_Genero);

            insert.ExecuteNonQuery();

            bd.Close();
        }

        public static void Delete(Libro libro)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();

            SqlCommand delete = new SqlCommand
                (
                "DELETE from dbo.Libro where ID_Libro = @id",
                bd
                );

            delete.Parameters.AddWithValue("@id", libro.ID_Libro);

            delete.ExecuteNonQuery ();
            bd.Close();
        }

        public static void Update(int idlibro, string titulo, string autor, int idgenero)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open ();

            SqlCommand update = new SqlCommand
                (
                "UPDATE dbo.Libro SET Titulo = @titulo, Autor = @autor, ID_Genero = @idgenero where ID_Libro = @idlibro",
                bd
                );

            update.Parameters.AddWithValue("@idlibro", idlibro);
            update.Parameters.AddWithValue("@titulo", titulo);
            update.Parameters.AddWithValue("@autor", autor);
            update.Parameters.AddWithValue("@idgenero", idgenero);

            update.ExecuteNonQuery ();

            bd.Close ();
        }

        public static List<Libro> GetItems()
        {
            List<Libro> libros = new List<Libro>();

            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");

            bd.Open();
            SqlCommand select = bd.CreateCommand();
            select.CommandText = "select * from dbo.Libro";
            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                Libro libro = new Libro();
                libro.ID_Libro = reader.GetInt32(0);
                libro.Titulo = reader.GetString(1);
                libro.Autor = reader.GetString(2);
                libro.ID_Genero = reader.GetInt32(3);
                libros.Add(libro);
            }

            reader.Close ();

            select.ExecuteReader();
            bd.Close();

            return libros;
        }

       
    }
}
