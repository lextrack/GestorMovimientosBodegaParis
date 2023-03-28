namespace MovimientosBodegaSensible.Models;

public partial class Recepcion
{
    public long Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Dpto { get; set; }

    public int? Cantidad { get; set; }

    public string? Responsable { get; set; }
}
