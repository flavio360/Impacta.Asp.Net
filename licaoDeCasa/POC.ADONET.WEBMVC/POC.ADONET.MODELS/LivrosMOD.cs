using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace POC.ADONET.MODELS
{
    public class LivrosMOD
    { 
       // [Display(name = "código")]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Tipo { get; set; }

        // o ? marca que esta propiedade aceita nulo;
        public float? Preco { get; set; }
        public string Resenha { get; set; }
    }
}
