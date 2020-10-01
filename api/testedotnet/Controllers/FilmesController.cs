using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet.Data;
using testedotnet.Models;

namespace testedotnet.Controllers
{
    
    [Route("teste/filmes")]
    [ApiController]
    public class FilmesController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get([FromServices] DataContext context){
            var lista = await context.Filmes.ToListAsync();
            foreach(var item in lista){
                var gen = await context.Generos.FirstOrDefaultAsync(g => g.Id == item.GeneroId);
                item.Genero = gen.Nome;
            }
            return Ok(lista);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromServices] DataContext context, [FromBody] Filmes model){
            if(ModelState.IsValid){
                context.Filmes.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Editar([FromServices] DataContext context, [FromBody] Filmes model){
            if(ModelState.IsValid){
                context.Filmes.Update(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        [Route("")]
        public async Task<ActionResult> Remover([FromServices] DataContext context, int id){
            if(ModelState.IsValid){
                var filme = context.Filmes.Find(id);
                context.Filmes.Remove(filme);
                await context.SaveChangesAsync();
                return Ok(filme);
            }else{
                return BadRequest(ModelState);
            }
        }
    }
}