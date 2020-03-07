using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cap05_Lab1_Pag470.Models;
using System.IO;
using System.Text;

namespace Cap05_Lab1_Pag470.Classes
{
    public class RotinasWeb
    {
        public static void ContatoGravar(ContatoViewModel contato)
        {
            string arquivo = HttpContext.Current.Server.MapPath("~/App_Data/Contatos.txt");

            using (var sw = new StreamWriter(arquivo, true, Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(contato.Nome);
                sw.WriteLine(contato.Email);
                sw.WriteLine(contato.Assunto);
                sw.WriteLine(contato.Mensagem);
                sw.WriteLine(new string('-', 30));
            }
        }
    }
}