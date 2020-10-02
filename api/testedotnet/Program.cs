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
                db.Add(new Generos { Nome = "Terror" });
                db.Add(new Generos { Nome = "Comédia" });
                db.Add(new Generos { Nome = "Drama" });
                db.Add(new Generos { Nome = "Terror" });
                db.Add(new Generos { Nome = "Ficção científica" });
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
                db.Add(
                    new Filmes
                    {
                        Titulo= "Midsommar",
                        Diretor= "Ari Aster",
                        GeneroId = 2,
                        Sinopse = "Após vivenciar uma tragédia pessoal, Dani vai com o namorado Christian e um grupo de amigos até a Suécia para participar de um festival local de verão. Mas, ao invés das férias tranquilas com a qual todos sonhavam, o grupo se depara com rituais bizarros de uma adoração pagã.",
                        Ano = 2019
                    });
                db.Add(
                    new Filmes
                    {
                        Titulo= "O Jogo da Imitação",
                        Diretor= "Morten Tyldum",
                        GeneroId = 4,
                        Sinopse = "Em 1939, a recém-criada agência de inteligência britânica MI6 recruta Alan Turing, um aluno da Universidade de Cambridge, para entender códigos nazistas, incluindo o Enigma, que criptógrafos acreditavam ser inquebrável. A equipe de Turing, incluindo Joan Clarke, analisa as mensagens de Enigma, enquanto ele constrói uma máquina para decifrá-las. Após desvendar as codificações, Turing se torna herói. Porém, em 1952, autoridades revelam sua homossexualidade, e a vida dele vira um pesadelo.",
                        Ano = 2015
                    });
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
