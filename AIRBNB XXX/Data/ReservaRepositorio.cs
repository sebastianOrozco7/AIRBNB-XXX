using AIRBNB_XXX.Globals;
using AIRBNB_XXX.Models;
using Microsoft.Data.SqlClient;

namespace AIRBNB_XXX.Data
{
    public class ReservaRepositorio
    {
        public int FilasAfectadas = 0;
        public bool ReservarHabitacion(Reserva reserva)
        {
            reserva.CedulaCliente = DatoGlobal.CedulaCliente;
            using (SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "INSERT INTO RESERVA (CedulaCliente,IdHabitacion,FechaInicio,FechaFin)" +
                    "VALUES (@cedulacliente,@idhabitacion,@fechainicio,@fechafin)";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@cedulacliente", reserva.CedulaCliente);
                    comando.Parameters.AddWithValue("@idhabitacion", reserva.IDHabitacion);
                    comando.Parameters.AddWithValue("@fechainicio", reserva.FechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", reserva.FechaFin);

                    bool Verificacion = VerificarDisponibilidad(reserva.IDHabitacion);

                    if (Verificacion)
                    {
                        FilasAfectadas = comando.ExecuteNonQuery();
                        CambiarDisponibilidadTrue(reserva.IDHabitacion);
                        return FilasAfectadas > 0;
                    }
                    else
                        return false;
                }
            }
        }

        public bool VerificarDisponibilidad(int IdHabitacion)
        {
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "SELECT Disponibilidad FROM HABITACION WHERE Id = @idhabitacion";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@idhabitacion", IdHabitacion);

                    object resultado = comando.ExecuteScalar();

                    return Convert.ToBoolean(resultado);
                }
            }
        }

        public void CambiarDisponibilidadTrue(int IdHabitacion)
        {
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "UPDATE HABITACION SET Disponibilidad = @disponibilidad WHERE Id = @idhabitacion";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@disponibilidad", false);
                    comando.Parameters.AddWithValue("@idhabitacion", IdHabitacion);
                    comando.ExecuteNonQuery();
                }
            }
        }



        public bool EliminarReserva(int IdReserva)
        {
            using(SqlConnection conexion = new ConexionDB().GetConexion)
            {
                conexion.Open();
                string Query = "DELETE FROM RESERVA WHERE IdReserva = @idreserva";

                using(SqlCommand comando = new(Query, conexion))
                {
                    comando.Parameters.AddWithValue("@idreserva", IdReserva);

                    FilasAfectadas = comando.ExecuteNonQuery();

                    return FilasAfectadas > 0;
                }
            }
        }
    }
}
