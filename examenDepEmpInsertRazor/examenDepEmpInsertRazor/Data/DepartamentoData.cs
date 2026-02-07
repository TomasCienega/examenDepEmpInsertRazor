using examenDepEmpInsertRazor.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace examenDepEmpInsertRazor.Data
{
    public class DepartamentoData
    {
        private readonly string _cadenaSQL="";
        public DepartamentoData(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("cadenaSQL") ?? string.Empty;
        }

        #region
        public async Task<List<Departamento>> ListarDeptos()
        {
            var _listaDeptos = new List<Departamento>();

            using (var conn = new SqlConnection(_cadenaSQL))
            {
                await conn.OpenAsync();
                var cmd= new SqlCommand("sp_ListarDepartamentos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _listaDeptos.Add(new Departamento
                        {
                            IdDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                            NombreDepartamento = dr["nombreDepartamento"].ToString()
                        });
                    }
                }

            }
            return _listaDeptos;
        }
        #endregion
    }
}
