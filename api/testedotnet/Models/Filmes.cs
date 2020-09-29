using System.ComponentModel.DataAnnotations;

namespace testedotnet.Models
{
    public class Filmes{
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="Este campo é obrigatório")]
        public string Titulo {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório")]
        public string Diretor {get; set;}
        public Generos Genero {get; set;}
        public string Ano {get; set;}
    }
}