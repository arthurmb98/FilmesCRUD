using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet.Data;
using testedotnet.Models;

namespace testedotnet.Controllers
{
    [ApiController]
    [Route("teste/filmes")]
    public class FilmesController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Filmes>>> Get([FromServices] DataContext context){
            var lista = await context.Filmes.ToListAsync();
            foreach(var item in lista){
                var gen = await context.Generos.FirstOrDefaultAsync(g => g.Id == item.GeneroId);
                item.Genero = gen?.Nome;
            }
            return lista;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Filmes>> Post([FromServices] DataContext context, [FromBody] Filmes model){
            if(ModelState.IsValid){
                context.Filmes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else{
                return BadRequest(ModelState);
            }
        }
    }
}