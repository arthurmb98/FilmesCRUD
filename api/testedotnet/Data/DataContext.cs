using Microsoft.EntityFrameworkCore;
using testedotnet.Models;

namespace testedotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :  base(options){

        }

        public DbSet<Filmes> Filmes {get; set;}
        public DbSet<Generos> Generos {get; set;}
    }
}