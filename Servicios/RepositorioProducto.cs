using Dapper;
using PinedaStore.Models;
using System.Data;
using System.Data.SqlClient;

namespace PinedaStore.Servicios
{
    public interface IRepositorioProducto
    {
        Task<bool> AdministradorModel(AdministradorModel model);
        Producto agregar(int productoId,int cantidad);
    }

    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly string cnx;
        public RepositorioProducto(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> AdministradorModel(AdministradorModel model)
        {
            bool IsInserted = false;
            try

            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync
                    (@"INSERT INTO IngresarProducto(Codigo,Nombre,Descripcion,precio,Unidades,Estado,urlimagen) VALUES (@Codigo,@Nombre,@Descripcion,@precio,@Unidades,@Estado,@urlimagen)", model) > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return IsInserted;
        }
        public Producto agregar(int productoId, int cantidad)
        {
            using (IDbConnection db= new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM IngresarProducto WHERE Codigo=@productoId";
                Producto ccc = 
                    db.QuerySingleOrDefault<Producto>(sqlQuery, new {productoId,cantidad});
                return ccc;
            }
        }

        public Producto productomodel(int Codigo)
        {
            using(IDbConnection db= new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM IngresarProducto WHERE Codigo=@Codigo";
                Producto ccc=db.QuerySingleOrDefault< Producto>(sqlQuery, new {Codigo});
                return ccc;
            }
            
                

            
        }
       
    }

    

    
}
