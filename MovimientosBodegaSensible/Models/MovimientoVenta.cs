using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class MovimientoVenta
{
    public long Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Producto { get; set; }

    public long? Boleta { get; set; }

    [Display(Name = "SKU")]
    public long? Sku { get; set; }

    public int? Cantidad { get; set; }

    public string? Responsable { get; set; }
}
