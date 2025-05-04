using AIRBNB_XXX.Globals;
using AIRBNB_XXX.Models;
using Microsoft.Data.SqlClient;

namespace AIRBNB_XXX.Data
{
    public class ClienteRepositorio
    {
        public int FilasAfectadas = 0;
        public bool RegistrarCliente(Cliente cliente)
        {
           
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "INSERT INTO CLIENTE (Cedula,Nombre,Telefono,Correo) VALUES (@cedula,@nombre,@telefono,@correo)";
                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@cedula", cliente.Cedula); 
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@correo", cliente.Correo);
                    DatoGlobal.CedulaCliente = cliente.Cedula;
                    FilasAfectadas = comando.ExecuteNonQuery();

                    return FilasAfectadas > 0;
                }
            }
        }
    }
}
