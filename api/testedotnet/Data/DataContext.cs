using Microsoft.EntityFrameworkCore;
using testedotnet.Models;

namespace testedotnet.Data
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Filmes>()
            .HasOne<Generos>()
            .WithMany()
            .HasForeignKey(p => p.GeneroId);
            

        }

        // public DataContext(DbContextOptions<DataContext> options) :  base(options){

        // }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase(databaseName: "Database");
            //"Data Source=banco.db"
//
        public DbSet<Filmes> Filmes {get; set;}
        public DbSet<Generos> Generos {get; set;}
    }
}