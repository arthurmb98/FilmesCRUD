using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet.Data;
using testedotnet.Models;

namespace testedotnet.Controllers
{
    [ApiController]
    [Route("teste/generos")]
    public class GenerosController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Generos>>> Get([FromServices] DataContext context){
            return await context.Generos.ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Generos>> Post([FromServices] DataContext context, [FromBody] Generos model){
            if(ModelState.IsValid){
                context.Generos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else{
                return BadRequest(ModelState);
            }
        }
    }
}