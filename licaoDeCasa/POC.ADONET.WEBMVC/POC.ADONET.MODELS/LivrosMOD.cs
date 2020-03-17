using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace POC.ADONET.MODELS
{
    public class LivrosMOD
    { 
       // [Display(name = "código")]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        // o ? marca que esta propiedade aceita nulo;
        //public float? Preco { get; set; }
        public double? Preco { get; set; }
        public string Resenha { get; set; }  
        public int Title_id { get; set; }
        public string Pub_id { get; set; }
        public int Royalty { get; set; }
        public string PubDate { get; set; }
        public int Advance { get; set; }
        public int Ytd_Sales { get; set; }
    }
}
