using Microsoft.AspNetCore.Mvc;
using MovimientosBodegaSensible.Models;
using OfficeOpenXml;

namespace MovimientosBodegaSensible.Controllers
{
    public class ExportServicioTecnicoController : Controller
    {
        private readonly MovimientosParisContext _dbContext;

        public ExportServicioTecnicoController(MovimientosParisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Obtener los datos desde la base de datos
            var data = _dbContext.ServicioTecnicoes.ToList();

            // Crear archivo Excel
            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de servicio técnico");

            // Agregar los datos
            worksheet.Cells.LoadFromCollection(data, true);

            // Guardar el archivo Excel
            var stream = new MemoryStream();
            excelPackage.SaveAs(stream);

            // Devolver el archivo Excel como una respuesta HTTP
            var fileName = "Datos de servicio técnico.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream.ToArray(), contentType, fileName);
        }

    }
}
