using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testedotnet.Models
{
    public class Generos
    {
        [Key]
        public int Id {get; set;}

        public string Nome {get; set;}
    }
}