//For reading, modifying and creating database
using Microsoft.EntityFrameworkCore;
using NotesAppAPI.Models;

namespace NotesAppAPI.Data
{
    public class ApiContext: DbContext{
        public DbSet<Notes> Notes {get; set;}
        public class ApiContext(DbContextOptions<ApiContextOptions> options): base(options)
        {
            
        }
    }
}
