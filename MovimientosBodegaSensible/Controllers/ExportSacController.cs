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

        public IActionResult ExportToExcelTodo()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.Sacs.ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos transacciones SAC");

                worksheet.Cells.LoadFromCollection(data, true);

                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    worksheet.Cells[i, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Total de registros de SAC.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelCien()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.Sacs.Take(100).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos transacciones SAC");

                worksheet.Cells.LoadFromCollection(data, true);

                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    worksheet.Cells[i, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 100 de registros de SAC.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelMil()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.Sacs.Take(1000).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos transacciones SAC");

                worksheet.Cells.LoadFromCollection(data, true);

                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    worksheet.Cells[i, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 1000 de registros de SAC.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

    }
}
