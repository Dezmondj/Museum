using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MuseumDomain;

namespace MuseumData
{
    public class MuseumDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Ticket> Tickects { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Person> Persons { get; set; }

        private readonly StreamWriter streamWriter = new StreamWriter("InfoLogs.log", append: false);
        public MuseumDBContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string? connectionString = config.GetConnectionString("MyConnection");

            optionsBuilder.UseSqlServer(connectionString!).
                LogTo(streamWriter.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information).
                EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuseumDBContext).Assembly);
        }
        public override void Dispose()
        {
            streamWriter.Dispose();
            base.Dispose();
        }
    }
}
