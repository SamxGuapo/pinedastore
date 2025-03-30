using Dapper;
using PinedaStore.Models;
using System.Data.SqlClient;


namespace PinedaStore.Servicios
{
    public interface IRepositorioUsuario
    {
        Task<bool> contactanosModel(contactanosModel contacto);
        Task<bool> validarusuario(inicioModel Index);
        Task<bool> registrarusuario(registromodel Usuario);
      
    }
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly string cnx;
        public RepositorioUsuario(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> registrarusuario(registromodel Usuario)
        {
            
            try
            {
                using var connetion = new SqlConnection(cnx);
                bool isInserted = await connetion.ExecuteAsync(
                    @"INSERT INTO Registro (id,nombre,apellido,fecha,sexo,correo,usuario,contraseña,confirmarC)VALUES (@id,@nombre,@apellido,@fecha,@sexo,@correo,@usuario,@contraseña,@confirmarC)", Usuario) > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return true;
               

    
            
        }
        
        public async Task<bool> contactanosModel(contactanosModel contacto)
        {
            
            {
                using var connetion = new SqlConnection(cnx);
                bool isInserted = await connetion.ExecuteAsync(
                    @"INSERT INTO Contactanos (nombre,correo,mensaje)
                    VALUES  (@nombre,@correo,@mensaje)",contacto) > 0;
            }
            return true;
        }
        
        public async Task<bool> validarusuario(inicioModel Index)
        {
           using var connection=new SqlConnection(cnx);
            string query = @"SELECT COUNT(1) FROM Registro WHERE usuario=@Usuario AND contraseña=@Contraseña";
            bool usuarioExiste=await connection.ExecuteScalarAsync<int>(query,new {Index.Usuario,Index.Contraseña})> 0;
            return usuarioExiste;
        }
        

       
    }
}
