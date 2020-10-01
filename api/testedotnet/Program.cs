using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using testedotnet.Data;
using testedotnet.Models;

namespace testedotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new DataContext())
            {
                // Create
                Console.WriteLine("Inserting a new Gênero");
                db.Add(new Generos { Nome = "Ação" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a Gênero");
                var genero = db.Generos
                    .OrderBy(b => b.Id)
                    .First();
                
                // Create Filme
                db.Add(
                    new Filmes
                    {
                        Titulo= "007",
                        Diretor= "Terence Young",
                        GeneroId = genero.Id,
                        Sinopse = "No filme que lançou a saga de James Bond, o agente 007 enfrenta o misterioso Dr. No, um gênio cientista determinado a destruir o programa espacial dos Estados Unidos. A contagem regressiva para o desastre se inicia e Bond vai para a Jamaica, onde conhece uma linda mulher, e confronta o vilão megalomaníaco em sua ilha.",
                        Ano = 1962
                    });
                db.SaveChanges();

                // Create
                db.Add(new Generos { Nome = "Terror" });
                db.Add(new Generos { Nome = "Comédia" });
                db.Add(new Generos { Nome = "Drama" });
                db.Add(new Generos { Nome = "Terror" });
                db.Add(new Generos { Nome = "Ficção científica" });
                db.SaveChanges();
            }
        
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
