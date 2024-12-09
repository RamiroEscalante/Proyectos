using CRUD_Biblioteca.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace CRUD_Biblioteca.Controladores
{
    internal class PrestamoDAO
    {
        public static void Add(Prestamo prestamo)
        {

            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();

            SqlCommand insert = new SqlCommand
                (
                "Insert into dbo.Prestamo(ID_Cliente,ID_Libro,Fecha) values(@idcliente,@idlibro,@fecha)",
                bd
                );

            insert.Parameters.AddWithValue("@idcliente", prestamo.ID_Cliente);
            insert.Parameters.AddWithValue("@idlibro", prestamo.ID_Libro);
            insert.Parameters.AddWithValue("@fecha", prestamo.Fecha);

            insert.ExecuteNonQuery();

            bd.Close();

        }

        public static void Delete(Prestamo prestamo)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");

            bd.Open();

            SqlCommand delete = new SqlCommand
                (
                "DELETE from dbo.Prestamo where ID_Prestamo = @id",
                bd
                );

            delete.Parameters.AddWithValue("@id", prestamo.ID_Prestamo);

            delete.ExecuteNonQuery ();
            bd.Close();
        }

        public static void Update(int idprestamo, int idcliente, int idlibro, DateTime fecha)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");

            bd.Open();

            SqlCommand update = new SqlCommand
                (
                "UPDATE dbo.Prestamo SET ID_Cliente = @idcliente, ID_Libro = @idlibro, Fecha = @fecha where ID_Prestamo = @idprestamo ",
                bd
                );

            update.Parameters.AddWithValue("@idprestamo", idprestamo);
            update.Parameters.AddWithValue("@idcliente", idcliente);
            update.Parameters.AddWithValue("@idlibro", idlibro);
            update.Parameters.AddWithValue("@fecha", fecha);

            update.ExecuteNonQuery ();
            bd.Close ();
        }

        public static List<Prestamo> GetItems()
        {
            List<Prestamo> prestamos = new List<Prestamo> ();

            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");

            bd.Open ();

            SqlCommand select = bd.CreateCommand ();
            select.CommandText = "select * from dbo.Prestamo";
            SqlDataReader reader = select.ExecuteReader ();

            while ( reader.Read ())
            {
                Prestamo prestamo = new Prestamo ();
                prestamo.ID_Prestamo = reader.GetInt32 (0);
                prestamo.ID_Cliente = reader.GetInt32 (1);
                prestamo.ID_Libro = reader.GetInt32 (2);
                prestamo.Fecha = reader.GetDateTime (3);
                prestamos.Add ( prestamo );
            }

            reader.Close ();
            select.ExecuteReader();
            bd.Close();

            return prestamos;

        }
    }
}
