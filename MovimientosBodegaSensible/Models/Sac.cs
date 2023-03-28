using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class Sac
{
    public long Id { get; set; }

    public DateTime? Fecha { get; set; }

    [Display(Name = "Movimiento")]
    public string? TipoMovimiento { get; set; }

    public string? Descripcion { get; set; }

    [Display(Name = "SKU")]
    public long? Sku { get; set; }

    public int? Cantidad { get; set; }

    [Display(Name = "Número Orden")]
    public long? NumeroOrden { get; set; }

    public string? Responsable { get; set; }
}
