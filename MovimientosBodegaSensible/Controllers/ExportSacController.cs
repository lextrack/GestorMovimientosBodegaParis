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

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Movimiento";
                worksheet.Cells[1, 4].Value = "Descripción";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Número Orden";
                worksheet.Cells[1, 8].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].TipoMovimiento;
                    worksheet.Cells[i + 2, 4].Value = data[i].Descripcion;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].NumeroOrden;
                    worksheet.Cells[i + 2, 8].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
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

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Movimiento";
                worksheet.Cells[1, 4].Value = "Descripción";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Número Orden";
                worksheet.Cells[1, 8].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].TipoMovimiento;
                    worksheet.Cells[i + 2, 4].Value = data[i].Descripcion;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].NumeroOrden;
                    worksheet.Cells[i + 2, 8].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
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

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Movimiento";
                worksheet.Cells[1, 4].Value = "Descripción";
                worksheet.Cells[1, 5].Value = "SKU";
                worksheet.Cells[1, 6].Value = "Cantidad";
                worksheet.Cells[1, 7].Value = "Número Orden";
                worksheet.Cells[1, 8].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].TipoMovimiento;
                    worksheet.Cells[i + 2, 4].Value = data[i].Descripcion;
                    worksheet.Cells[i + 2, 5].Value = data[i].Sku;
                    worksheet.Cells[i + 2, 6].Value = data[i].Cantidad;
                    worksheet.Cells[i + 2, 7].Value = data[i].NumeroOrden;
                    worksheet.Cells[i + 2, 8].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
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
