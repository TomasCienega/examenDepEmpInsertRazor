using examenDepEmpInsertRazor.Models;
using Microsoft.Data.SqlClient;
using System.Data;
namespace examenDepEmpInsertRazor.Data
{
    public class EmpleadoData
    {
        private readonly string _cadenasSQL="";
        public EmpleadoData(IConfiguration configuration)
        {
            _cadenasSQL = configuration.GetConnectionString("cadenaSQL") ?? string.Empty;
        }

        #region
        public async Task<List<Empleado>> ListarEmp()
        {
            var _listaEmp = new List<Empleado>();
            using (var conn = new SqlConnection(_cadenasSQL))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("sp_ListarEmpleados", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _listaEmp.Add(new Empleado
                        {
                            IdEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            NombreEmpleado = dr["nombreEmpleado"].ToString(),
                            ReferenciaDepartamento = new Departamento()
                            {
                                IdDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                NombreDepartamento = dr["nombreDepartamento"].ToString()
                            }
                        });
                    }
                }
            }
            return _listaEmp;
        }
        #endregion

        #region
        public async Task<List<Empleado>> LisEmpxDep(int idDep)
        {
            var _listaxDep = new List<Empleado>();

            using (var conn = new SqlConnection(_cadenasSQL))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("sp_ListarEmpleadoxDep", conn);
                cmd.Parameters.AddWithValue("@idDepartamento",idDep);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _listaxDep.Add(new Empleado
                        {
                            IdEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            NombreEmpleado = dr["nombreEmpleado"].ToString(),
                            ReferenciaDepartamento = new Departamento() 
                            { 
                                NombreDepartamento = dr["nombreDepartamento"].ToString()                           
                            }
                        });
                    }
                }
            }
            return _listaxDep;
        }
        #endregion

        #region
        public async Task<bool> GuardarEmpledo(Empleado empleado)
        {
            using (var conn = new SqlConnection(_cadenasSQL))
            {
                conn.Open();
                var cmd = new SqlCommand("sp_InsertarEmpleado", conn);
                cmd.Parameters.AddWithValue("@nombreEmpleado", empleado.NombreEmpleado);
                cmd.Parameters.AddWithValue("@idDepartamento", empleado.IdDepartamento);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();
                if (filas_afectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

    }
}
