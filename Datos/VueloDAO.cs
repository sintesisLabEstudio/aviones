using Microsoft.Data.SqlClient;
using StarOne.Core;
using System;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StarOne.Datos
{
    public class VueloDAO
    {
        internal static decimal ObtenerPrecioBaseVuelo(int idVuelo)
        {
            string query ="SELECT PrecioBase FROM dbo.Vuelos WHERE IdVuelo = @idVuelo";
            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@IdVuelo", idVuelo);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    return r.Read() ? r.GetDecimal(0) : 0;
                }
            }

        }
        internal static DataTable obtenerVuelos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT idVuelo, Codigo, Destino, PrecioBase FROM dbo.Vuelos ORDER BY Destino DESC";
            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
