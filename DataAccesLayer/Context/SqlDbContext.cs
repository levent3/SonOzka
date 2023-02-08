using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccesLayer.Context
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }

        public SqlDbContext()
        {

        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        private static string ConnectionString = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                if (ConnectionString == null)
                {
                    string configFileName = "appsettings.json";
                    var configuration = new ConfigurationBuilder()
                        //.SetBasePath(Directory.GetCurrentDirectory())
                        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ApiLayer"))
                        //
                        .AddJsonFile(configFileName, false)

                       .Build();
                    ConnectionString = configuration.GetConnectionString("OzkaKeys");
                }
                optionsBuilder.UseSqlServer(ConnectionString);


            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
