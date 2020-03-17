using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.DestinoMundo.Models
{
    public class Destino
    {
        [Required]
        public int DestinoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Foto { get; set; }
    }
}