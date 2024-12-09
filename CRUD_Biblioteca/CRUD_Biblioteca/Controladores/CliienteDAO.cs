using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Biblioteca.Modelos;
using Microsoft.Data.SqlClient;

namespace CRUD_Biblioteca.Controladores
{
    internal class CliienteDAO
    {
        public static void Add(ClienteClass clienteClass)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();
            SqlCommand insert = new SqlCommand
                (
                "Insert into dbo.Cliente(Nombre,Apellido) values(@nombre,@apellido)",
                bd
                );

            insert.Parameters.AddWithValue("@nombre", clienteClass.Nombre);
            insert.Parameters.AddWithValue("@apellido", clienteClass.Apellido);

            insert.ExecuteNonQuery();
            bd.Close();

        }

        public static void Delete(ClienteClass clienteID)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();

            SqlCommand delete = new SqlCommand
                (
                "Delete from dbo.Cliente where ID_Cliente = @id",
                bd
                );

            delete.Parameters.AddWithValue("@id", clienteID.ID_Cliente);

            delete.ExecuteNonQuery();

            bd.Close();
        }

        public static void Update(int id_cliente, string nombre, string apellido)
        {
            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            bd.Open();

            SqlCommand update = new SqlCommand
                (
                "UPDATE dbo.Cliente SET Nombre = @nombre, Apellido = @apellido where ID_Cliente = @id ",
                bd
                );

            update.Parameters.AddWithValue("@id", id_cliente);
            update.Parameters.AddWithValue("@nombre", nombre);
            update.Parameters.AddWithValue("@apellido", apellido);
            

            update.ExecuteNonQuery ();
            bd.Close() ;
        }

        public static List<ClienteClass> GetItems()
        {
            List<ClienteClass> Clientes = new List<ClienteClass>();

            SqlConnection bd;
            bd = new SqlConnection("Encrypt=False;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=biblioteca;Data Source=MSI\\SQLEXPRESS\r\n");
            
            bd.Open();

            SqlCommand select = bd.CreateCommand ();
            select.CommandText = "Select * from dbo.Cliente";
            SqlDataReader reader = select.ExecuteReader ();

            while (reader.Read())
            {
                ClienteClass Cliente = new ClienteClass();
                Cliente.ID_Cliente = reader.GetInt32(0);
                Cliente.Nombre = reader.GetString(1);
                Cliente.Apellido = reader.GetString(2);
                Clientes.Add(Cliente);
            }
            reader.Close ();

            select.ExecuteReader();

            bd.Close();
            return Clientes;
        }
    }
}
