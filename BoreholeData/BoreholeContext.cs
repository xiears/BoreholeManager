using BoreholeData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoreholeData
{
    public class BoreholeContext : DbContext
    {
        public BoreholeContext(DbContextOptions<BoreholeContext> options) : base(options)
        {
                
        }

        public DbSet<Borehole> Boreholes { get; set; }
        public DbSet<DrillBorehole> DrillBoreholes { get; set; }
        public DbSet<CableBorehole> CableBoreholes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("BoreholeConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
