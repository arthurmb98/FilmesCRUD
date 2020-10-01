using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using testedotnet.Data;
using testedotnet.Models;

namespace testedotnet
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:4200",
                                                      "https://localhost:4200")
                                                      .AllowAnyHeader()
                                                        .AllowAnyMethod()
                                                        .AllowCredentials();
                              });
            });

          //  services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Database"));

            services.AddScoped<DataContext, DataContext>();
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // var context = app.ApplicationServices.GetService<DataContext>();
            // AddTestData(context);
        }

        // private static void AddTestData(DataContext context)
        // {
 
        //     context.Add(new Generos{
        //         Nome = "Ação"
        //     });

        //     context.SaveChanges();

 
        //     context.Filmes.Add(new Filmes{
        //         Titulo = "Crepúsculo",
        //         Diretor = "Catherine ",
        //         Sinopse = "Só besteia",
        //         GeneroId = context.Generos.FirstOrDefault()?.Id ?? 0,
        //         Ano = 2008,
        //     });
 
        //     context.SaveChanges();

        //     context.Add(new Generos{
        //         Nome = "Terror"
        //     });
        //     context.Add(new Generos{
        //         Nome = "Comédia"
        //     });
        //     context.Add(new Generos{
        //         Nome = "Romance"
        //     });


        //     context.SaveChanges();
        // }
    }
}
