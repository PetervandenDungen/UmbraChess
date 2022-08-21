using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UmbraChess.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("umbracoDbDSN"));
        }

        //public DbSet<object> Obj { get; set; }
    }
}
