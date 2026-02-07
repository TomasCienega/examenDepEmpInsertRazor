using examenDepEmpInsertRazor.Data;
using examenDepEmpInsertRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace examenDepEmpInsertRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DepartamentoData _departamentoData;
        private readonly EmpleadoData _empleadoData;

        public List<Departamento> ListaDeptos { get; set; } = new();
        public List<Empleado> ListaEmpleados { get; set; } = new();

        [BindProperty]
        public Empleado NuevoEmpleado { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int IdDeptoFiltro { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DepartamentoData departamentoData, EmpleadoData empleadoData)
        {
            _logger = logger;
            _departamentoData = departamentoData;
            _empleadoData = empleadoData;
        }

        public async Task OnGet()
        {
            ListaDeptos = await _departamentoData.ListarDeptos();

            if (IdDeptoFiltro>0)
            {
                ListaEmpleados = await _empleadoData.LisEmpxDep(IdDeptoFiltro);
            }
            else
            {
                ListaEmpleados = await _empleadoData.ListarEmp();
            }

                
        }
        public async Task<IActionResult> OnPostGuardar()
        {
            if (!ModelState.IsValid) return Page();
            {
                bool guardado =await _empleadoData.GuardarEmpledo(NuevoEmpleado);
                return RedirectToPage();
            }
        }
    }
}
