using examenDepEmpInsertRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace examenDepEmpInsertRazor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly ConnectionData _connectionData;

        public PrivacyModel(ILogger<PrivacyModel> logger, ConnectionData connectionData)
        {
            _logger = logger;
            _connectionData = connectionData;
        }

        public void OnGet()
        {
            bool resultado = _connectionData.ProbarConexion();
            if (resultado)
            {
                ViewData["Mensaje"] = "Conexion Lista";
            }
        }
    }

}
