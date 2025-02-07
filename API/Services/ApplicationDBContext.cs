using API.Models;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class ApplicationDBContext:DbContext
    {
        

        public  ApplicationDBContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}
