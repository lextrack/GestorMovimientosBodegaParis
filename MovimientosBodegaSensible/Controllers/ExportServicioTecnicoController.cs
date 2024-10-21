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

        public IActionResult ExportToExcelTodo()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var data = _dbContext.ServicioTecnicoes.ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de servicio técnico");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Caso Siebel";
                worksheet.Cells[1, 5].Value = "N° Guía";
                worksheet.Cells[1, 6].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].CasoSiebel;
                    worksheet.Cells[i + 2, 5].Value = data[i].Nguia;
                    worksheet.Cells[i + 2, 6].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Total de registros de servicio técnico.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelCien()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var data = _dbContext.ServicioTecnicoes.Take(100).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de servicio técnico");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Caso Siebel";
                worksheet.Cells[1, 5].Value = "N° Guía";
                worksheet.Cells[1, 6].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].CasoSiebel;
                    worksheet.Cells[i + 2, 5].Value = data[i].Nguia;
                    worksheet.Cells[i + 2, 6].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 100 registros de servicio técnico.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

        public IActionResult ExportToExcelMil()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var data = _dbContext.ServicioTecnicoes.Take(1000).ToList();

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Datos de servicio técnico");

                // Encabezados
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Fecha";
                worksheet.Cells[1, 3].Value = "Producto";
                worksheet.Cells[1, 4].Value = "Caso Siebel";
                worksheet.Cells[1, 5].Value = "N° Guía";
                worksheet.Cells[1, 6].Value = "Responsable";

                // Datos
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Id;
                    worksheet.Cells[i + 2, 2].Value = data[i].Fecha;
                    worksheet.Cells[i + 2, 3].Value = data[i].Producto;
                    worksheet.Cells[i + 2, 4].Value = data[i].CasoSiebel;
                    worksheet.Cells[i + 2, 5].Value = data[i].Nguia;
                    worksheet.Cells[i + 2, 6].Value = data[i].Responsable;

                    // Formato de fecha
                    if (data[i].Fecha.HasValue)
                    {
                        worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                    }
                }

                var stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Últimos 1000 registros de servicio técnico.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream.ToArray(), contentType, fileName);
            }
        }

    }
}
