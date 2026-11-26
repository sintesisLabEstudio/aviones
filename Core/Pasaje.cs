using vuelo = StarOne.Datos.VueloDAO;

namespace StarOne.Core;

public class Pasaje
{
    // [IdPasaje] INT IDENTITY(1, 1) NOT NULL
    public int IdPasaje { get; private set; }
    //[Rut] NVARCHAR(20)   NOT NULL
    public string Rut { get; set; }
    //[NombreCompleto] NVARCHAR(100)  NOT NULL
    public string NombreCompleto { get; set; }= string.Empty;
    //[Edad] INT NOT NULL,
    public int Edad { get; set; }
    //[CodigoVuelo] INT NOT NULL
    public int CodigoVuelo { get; set; }
    //[NumeroAsiento] INT NOT NULL
    public int NumeroAsiento { get; set; }
    //[Origen] NVARCHAR(100)  NOT NULL
    public string Origen { get; set; } = string.Empty;
    
    //[Destino] NVARCHAR(100)  NOT NULL
    public string Destino { get; set; } = string.Empty;
    
    //[ValorPasaje] DECIMAL(12, 2) NOT NULL
    public decimal ValorPasaje { get; set; }

    //[PorcentajeDescuento] INT NOT NULL
    public decimal PorcentajeDescuento { get; set; }
    //[MontoDescuento] DECIMAL(12, 2) NOT NULL
    public decimal MontoDescuento { get; set; }

    //[ValorFinalConDescuento] DECIMAL(12, 2) NOT NULL
    public decimal ValorFinalConDescuento { get; set; }
    

    /// <summary>
    /// Calcula el monto de descuento correspondiente al pasaje.
    /// </summary>
    /// <returns>El monto de descuento calculado.</returns>
    public decimal CalcularMontoDescuento()
    {
        decimal montoDescuento = ValorPasaje * PorcentajeDescuento / 100;
        return montoDescuento;
    }
    public decimal CalcularValorFinal()
    {
        
        ValorFinalConDescuento = ValorPasaje - MontoDescuento;
        return ValorFinalConDescuento;
    }

    public int CalcularPorcentajeDescuento()
    {
       if (string.IsNullOrEmpty(Rut) || Rut.Length < 1)
        {
            return 10; // Retorna 0 si el RUT es nulo o vacío
        }
        else
        {
            string ultimoDigito = Rut.TakeLast(1).FirstOrDefault().ToString();
            return 10 + int.Parse(ultimoDigito);
        }
        
    }
    public Pasaje(string rut,string nombreCompleto, int edad, 
        int codVuelo, int numAsiento,string origen,string destino)
    {
        this.Rut = rut;
        this.NombreCompleto = nombreCompleto;
        this.Edad = edad;
        this.CodigoVuelo = codVuelo;
        this.NumeroAsiento = numAsiento;
        this.Origen = origen;
        this.Destino = destino;
        ValorPasaje = vuelo.ObtenerPrecioBaseVuelo(codVuelo);
        PorcentajeDescuento = CalcularPorcentajeDescuento();
        MontoDescuento = CalcularMontoDescuento();
        ValorFinalConDescuento = CalcularValorFinal();
    }
}
