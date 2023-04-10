using Microsoft.AspNetCore.Mvc;
using MovimientosBodegaSensible.Models;
using OfficeOpenXml;

namespace MovimientosBodegaSensible.Controllers
{
    public class ExportVentasController : Controller
    {
        private readonly MovimientosParisContext _dbContext;

        public ExportVentasController(MovimientosParisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.MovimientoVentas.ToList();

            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de ventas");

            worksheet.Cells.LoadFromCollection(data, true);

            var stream = new MemoryStream();
            excelPackage.SaveAs(stream);

            var fileName = "Datos de ventas.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream.ToArray(), contentType, fileName);
        }

    }
}
