namespace StarOne.Core;

public class Vuelo
{
    public int IdVuelo { get; set; }  
    public string Codigo { get ; set ; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Hora { get; set; }
    public decimal PrecioBase { get; set; }
    
    public Vuelo(int IdVuelo, string codigo, string origen, string destino, DateTime fecha,DateTime hora, decimal precioBase)
    {
        this.Codigo = codigo;
        this.Origen = origen;
        //this.Destino = destino;
        this.Fecha = fecha;
        this.Hora = hora;
        this.PrecioBase = precioBase;
     }

    internal static string obtenerOrigenporId(int idVuelo)
    {
        throw new NotImplementedException();
    }

    internal static string obtenerDestinoporId(int idVuelo)
    {
        throw new NotImplementedException();
    }

}

