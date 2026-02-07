using Microsoft.Data.SqlClient;

namespace examenDepEmpInsertRazor.Data
{
    public class ConnectionData
    {
        private readonly string _cadenaSQL="";
        public ConnectionData(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("cadenaSQL") ?? string.Empty;
        }
        #region
        public bool ProbarConexion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cadenaSQL))
                {
                    con.Open(); // Aquí es donde ocurre la "magia"
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("¡CONEXIÓN EXITOSA AL BANCO!");
                    Console.WriteLine("Servidor: " + con.DataSource);
                    Console.WriteLine("Base de Datos: " + con.Database);
                    Console.WriteLine("-------------------------------------------");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("ERROR DE CONEXIÓN: " + ex.Message);
                Console.WriteLine("-------------------------------------------");
                return false;
            }
        }
        #endregion
    }
}
