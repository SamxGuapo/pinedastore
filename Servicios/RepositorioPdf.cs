using PinedaStore.Models;
using Dapper;
using iText.Kernel.Pdf;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace PinedaStore.Servicios
{
  
        public interface IRepositorioPdf
        {
            List<AdministradorModel> generarpdf(AdministradorModel generar);
            List<registromodel> generar(registromodel registro);

             List<provedorModel> provedor(provedorModel pdfprovedor);
              List<contactanosModel> contactar(contactanosModel pdfcontactanos);
        }

        public class Repositoriopdf : IRepositorioPdf
        {
            private readonly string cnx;
            private readonly IConfiguration configuration;
            
           
            public Repositoriopdf (IConfiguration configuration)
            {
                cnx = configuration.GetConnectionString("DefaultConnection");
            }

            public List<AdministradorModel> generarpdf(AdministradorModel generar)
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT * FROM IngresarProducto";
                using var generarpdf = new SqlConnection(connectionString);
                var pdf=connection.Query<AdministradorModel>(query).ToList();

                return pdf;
            }

            public List<registromodel>generar(registromodel registro)
            {
             string connectionString = configuration.GetConnectionString("DefaultConnection");
             using var connection = new SqlConnection(cnx);
             var query = "SELECT * FROM Registro";
             using var generar = new SqlConnection(connectionString);
             var pdf = connection.Query<registromodel>(query).ToList();

             return pdf;

            }

            public List<provedorModel> provedor(provedorModel pdfprovedor)
            {
             string connectionString = configuration.GetConnectionString("DefaultConnection");
             using var connection = new SqlConnection(cnx);
             var query = "SELECT * FROM provedor";
             using var generar = new SqlConnection(connectionString);
             var pdf = connection.Query<provedorModel>(query).ToList();

             return pdf;

            }

            public List<contactanosModel> contactar(contactanosModel pdfcontactanos)
            {
             string connectionString = configuration.GetConnectionString("DefaultConnection");
             using var connection = new SqlConnection(cnx);
             var query = "SELECT * FROM contactanos";
             using var generar = new SqlConnection(connectionString);
             var pdf = connection.Query<contactanosModel>(query).ToList();

              return pdf;

            }

           



        }


    
}
