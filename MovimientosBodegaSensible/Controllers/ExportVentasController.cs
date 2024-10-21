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

        public IActionResult ExportToExcelTodo()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.MovimientoVentas.ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de ventas");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Boleta";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].Boleta;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Total de registros de ventas.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelCien()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.MovimientoVentas.Take(100).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de ventas");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Boleta";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].Boleta;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 100 registros de ventas.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelMil()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var data = _dbContext.MovimientoVentas.Take(1000).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de ventas");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Boleta";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].Boleta;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 1000 registros de ventas.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }
    }
}
