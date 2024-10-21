using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class Sac
{
    [Display(Order = 1)]
    public long Id { get; set; }

    [Display(Order = 2)]
    public DateTime? Fecha { get; set; }

    [Display(Name = "Movimiento", Order = 3)]
    public string? TipoMovimiento { get; set; }

    [Display(Order = 4)]
    public string? Descripcion { get; set; }

    [Display(Name = "SKU", Order = 5)]
    public long? Sku { get; set; }

    [Display(Order = 6)]
    public int? Cantidad { get; set; }

    [Display(Name = "Número Orden", Order = 7)]
    public long? NumeroOrden { get; set; }

    [Display(Order = 8)]
    public string? Responsable { get; set; }
}
