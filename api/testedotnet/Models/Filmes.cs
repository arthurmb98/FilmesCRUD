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
        
        public int GeneroId { get; set; }

        public string Genero {get; set;}

        public string Sinopse {get; set;}

        public int? Ano {get; set;}
    }
}