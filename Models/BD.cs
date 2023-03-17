using Dapper;
using System.Data.SqlClient;
namespace PizzaApi.Models;


public static class BD
{
    private static string connectionStr = "Server=A-PHZ2-AMI-020;Database=PizzaDB;Trusted_Connection=True;";

    public static List<Pizza> GetAll()
    {
        List<Pizza> l = new List<Pizza>();
        string query;

        using(SqlConnection db = new SqlConnection(connectionStr)){
            query = "SELECT * FROM Pizzas";
            l = db.Query<Pizza>(query).ToList();
        }
        return l;
    }
    public static Pizza GetById(int id)
    {
        string query;
        Pizza p;

        using(SqlConnection db = new SqlConnection(connectionStr)){
            query = "SELECT * FROM Pizzas WHERE Id=@pId";
            p = db.QueryFirstOrDefault<Pizza>(query,new{pId = id});
        }
        return p;
    }

    public static int Create(Pizza p)
    {
        string query;
        int n;

        using(SqlConnection db = new SqlConnection(connectionStr)){
            query = "INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)";
            n = db.Execute(query, new{pNombre = p.Nombre, pLibreGluten = p.LibreGluten, pImporte = p.Importe, pDescripcion = p.Descripcion});
        }
        return n;
    }

    public static int Update(Pizza p)
    {
        string query;
        int n;

        using(SqlConnection db = new SqlConnection(connectionStr)){
            query = "UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripcion = @pDescripcion WHERE Id = @pId";
            n = db.Execute(query, new{pNombre = p.Nombre, pLibreGluten = p.LibreGluten, pImporte = p.Importe, pDescripcion = p.Descripcion, pId = p.Id});
        }
        return n;
    }

    public static int DeleteByID(int id)
    {
        string query;
        int n;

        using(SqlConnection db = new SqlConnection(connectionStr)){
            query = "DELETE FROM Pizzas WHERE Id = @pId";
            n = db.Execute(query, new{pId = id});
        }
        return n;
    }
}