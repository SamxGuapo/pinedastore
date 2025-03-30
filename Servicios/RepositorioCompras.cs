using Dapper;
using Microsoft.Extensions.Configuration;
using PinedaStore.Models;
using System.Data;
using System.Data.SqlClient;
using static PinedaStore.Models.carroitem;



namespace PinedaStore.Servicios
{
    public interface IRepositorioCompras
    {
        Task BorrarProducto(int id);
        Task<AdministradorModel> compras(string Codigo);
    }

    public class RepositorioCompras:IRepositorioCompras
    {

        //private readonly IConfiguration configuration;
        private readonly string cnx;

        public RepositorioCompras(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
            //configuration = configuration;

        }

        public async Task BorrarProducto(int id)
        {
            //string connectionString = configuration.GetConnectionString("DefaultConnection");
            using var connection=new SqlConnection(cnx);
            var query = "DELETE FROM IngresarProducto WHERE Codigo=@Codigo";
            await connection.ExecuteAsync(query, new {Codigo=id});
        }
        public async Task<AdministradorModel> compras(string Codigo)
        {
            try
            {
                using var connection = new SqlConnection(cnx);
                var query = "SELECT Codigo, Nombre, Unidades, precio FROM IngresarProducto WHERE Codigo = @Codigo";
                return await connection.QueryFirstOrDefaultAsync<AdministradorModel>(query, new {Codigo=Codigo});
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
            
        }

        
    }
}

