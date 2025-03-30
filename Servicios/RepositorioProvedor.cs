using Dapper;
using PinedaStore.Models;
using System.Data;
using System.Data.SqlClient;

namespace PinedaStore.Servicios
{
    public interface IRepositorioProvedor
    {
        Task<bool> provedor(provedorModel provedor);

    }

    public class RepositorioProvedor : IRepositorioProvedor
    {
        private readonly string cnx;

        public RepositorioProvedor(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> provedor(provedorModel provedor)
        {
            bool IsInserted = false;
            try
            {
                 var connection = new SqlConnection(cnx);
                 IsInserted = await connection.ExecuteAsync
                      (@"INSERT INTO provedor(Id,empresa,nombre,telefono,correo) VALUES (@Id,@empresa,@nombre,@telefono,@correo)", provedor) > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return IsInserted;
        }

        //public provedorModel DetalleProvedor(int idprovedor)
        //{
        //    using (IDbConnection db = new SqlConnection(cnx))
        //    {
        //        string sqlQuery = "SELECT Idproveedor, Empresa FROM Proveedor WHERE Idproveedor= @Idproveedor";

        //        ingresarcompra model = db.QuerySingleOrDefault<ingresarcompra>(sqlQuery, new { Idproveedor });

        //        return model;
        //    }
        //}
    }
}
