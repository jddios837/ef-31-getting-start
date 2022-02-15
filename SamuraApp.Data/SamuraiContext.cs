using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraApp.Data
{
    public class SamuraiContext: DbContext
    {
        // EF Core understand the relation between these classes
         public DbSet<Samurai> Samurais { get; set; }
         public DbSet<Quote> Quotes { get; set; }
         public DbSet<Clan> Clans { get; set; }

         public static readonly ILoggerFactory ConsoleLoguerFactory
             = LoggerFactory.Create(builder =>
             {
                 builder
                     .AddFilter((category, level) => 
                         category == DbLoggerCategory.Database.Command.Name
                         && level == LogLevel.Information)
                     .AddConsole();
             });

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.
                 UseLoggerFactory(ConsoleLoguerFactory).EnableSensitiveDataLogging()
                 .UseSqlServer(
                 "Server=YUXMED0007L\\SQLEXPRESS;Database=SamuraiAppData;Trusted_Connection=True"
             ); 
             // base.OnConfiguring(optionsBuilder);
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
             modelBuilder.Entity<Horse>().ToTable("Horses_TEST"); // Define a Name for the table on the DB
         }
    }
}