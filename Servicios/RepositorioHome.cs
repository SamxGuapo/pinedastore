using Dapper;
using PinedaStore.Models;
using System.Data;
using System.Data.SqlClient;

namespace PinedaStore.Servicios
{
    public interface IRepositorioHome
    {
        AdministradorModel DetalleProducto(int Codigo);
        IEnumerable<AdministradorModel> ListarProductos();

    }
    public class RepositorioHome:IRepositorioHome
    {
        private readonly string cnx;
        public RepositorioHome(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<AdministradorModel> ListarProductos()
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM IngresarProducto";
                var  productos = db.Query<AdministradorModel>(sqlQuery).ToList();
                return productos;
            }
        }

        public AdministradorModel DetalleProducto(int Codigo)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT Codigo,Nombre,Descripcion,precio,urlimagen FROM IngresarProducto WHERE Codigo =@Codigo";
                AdministradorModel producto =
                    db.QuerySingleOrDefault<AdministradorModel>(sqlQuery, new { Codigo });
                return producto;
            }
        }



       
    }
}
