using Microsoft.Data.SqlClient;

namespace AIRBNB_XXX.Data
{
    public class ConexionDB
    {
        SqlConnection conexion = new SqlConnection(@"server = (localdb)\MSSQLLocalDB; database = Airbnb;Trusted_Connection=True");

        public SqlConnection GetConexion
        {
            get { return conexion; }
        }
    }
}
