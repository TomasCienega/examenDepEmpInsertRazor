namespace examenDepEmpInsertRazor.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; } 
        public int IdDepartamento { get; set; }
        public Departamento? ReferenciaDepartamento { get; set; }
    }
}
