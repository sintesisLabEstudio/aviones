
using System; 
using System.Data; 
using Microsoft.Data.SqlClient;
using StarOne.Datos;

namespace StarOne.Core;
public class ConexionDB
{
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alumnos\Downloads\JVV\BaseDatos\StarOneDB.mdf;Integrated Security=True;Connect Timeout=30
    private static readonly string cadenaConexion = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alumnos\Downloads\JVV\BaseDatos\StarOneDB.mdf;Integrated Security=True;
TrustServerCertificate=True;";
    public static string CadenaConexion => cadenaConexion;
    public static SqlConnection ObtenerConexion()
    {
        SqlConnection conexion = new SqlConnection(cadenaConexion);
        try
        {
            conexion.Open();
            return conexion;
        }
        catch
        {
            conexion.Dispose();
            throw;
        }
    }
    public static bool ProbarConexion()
    {
        try
        {
            using (SqlConnection conexion = ObtenerConexion())
            return conexion.State == ConnectionState.Open;
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"[Error de Conexión SQL]: {ex.Message}");
            return false;
        }
    }
}