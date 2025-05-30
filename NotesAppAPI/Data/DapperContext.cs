using System.Data;
using MySql.Data.MySqlClient;

namespace NotesAppAPI.Data{
    public class DapperContext{
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
    public IDbConnection CreateConnection(){
            return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}