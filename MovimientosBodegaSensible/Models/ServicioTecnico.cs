using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class ServicioTecnico
{
    [Display(Order = 1)]
    public long Id { get; set; }

    [Display(Order = 2)]
    public DateTime? Fecha { get; set; }

    [Display(Order = 3)]
    public string? Producto { get; set; }

    [Display(Name = "Caso Siebel", Order = 4)]
    public long? CasoSiebel { get; set; }

    [Display(Name = "N° Guía", Order = 5)]
    public long? Nguia { get; set; }

    [Display(Order = 6)]
    public string? Responsable { get; set; }
}