using Microsoft.AspNetCore.Mvc;
using MovimientosBodegaSensible.Models;
using OfficeOpenXml;

namespace MovimientosBodegaSensible.Controllers
{
    public class ExportSacController : Controller
    {
        private readonly MovimientosParisContext _dbContext;

        public ExportSacController(MovimientosParisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.Sacs.ToList();

            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Datos transacciones SAC");

            worksheet.Cells.LoadFromCollection(data, true);

            var stream = new MemoryStream();
            excelPackage.SaveAs(stream);

            var fileName = "Datos transacciones SAC.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream.ToArray(), contentType, fileName);
        }

    }
}
