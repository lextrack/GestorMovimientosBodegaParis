using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class MovimientoVenta
{
    [Display(Order = 1)]
    public long Id { get; set; }

    [Display(Order = 2)]
    public DateTime? Fecha { get; set; }

    [Display(Order = 3)]
    public string? Producto { get; set; }

    [Display(Order = 4)]
    public long? Boleta { get; set; }

    [Display(Name = "SKU", Order = 5)]
    public long? Sku { get; set; }

    [Display(Order = 6)]
    public int? Cantidad { get; set; }

    [Display(Order = 7)]
    public string? Responsable { get; set; }
}
