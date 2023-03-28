using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models;

public partial class ServicioTecnico
{
    public long Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Producto { get; set; }

    [Display(Name = "Caso Siebel")]
    public long? CasoSiebel { get; set; }

    [Display(Name = "N° Guía")]
    public long? Nguia { get; set; }

    public string? Responsable { get; set; }
}
