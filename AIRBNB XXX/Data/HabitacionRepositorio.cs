using AIRBNB_XXX.Models;
using Microsoft.Data.SqlClient;

namespace AIRBNB_XXX.Data
{
    public class HabitacionRepositorio
    {
        public int FilasAfectadas = 0;
        public bool AñadirHabitacion(Habitacion habitacion)
        {
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "INSERT INTO HABITACION (Id,Tipo,Precio,Disponibilidad) VALUES (@id,@tipo,@precio,@disponibilidad)";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", habitacion.IDHabitacion);
                    comando.Parameters.AddWithValue("@tipo", habitacion.Tipo);
                    comando.Parameters.AddWithValue("@precio", habitacion.Precio);
                    comando.Parameters.AddWithValue("@disponibilidad", habitacion.Diponibilidad);

                    FilasAfectadas = comando.ExecuteNonQuery();
                    return FilasAfectadas > 0;
                }
            }
        }

        public bool ElimarHabitacion(int IDhabitacion)
        {
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "DELETE FROM HABITACION WHERE Id = @idhabitacion";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@idhabitacion", IDhabitacion);

                    FilasAfectadas = comando.ExecuteNonQuery();
                    return FilasAfectadas > 0;
                }
            }
        }
    }
}
