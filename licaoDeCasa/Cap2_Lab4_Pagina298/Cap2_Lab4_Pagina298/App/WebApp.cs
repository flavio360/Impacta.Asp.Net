using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Cap2_Lab4_Pagina298.APP
{
    public static class WebApp
    {
        public static void ComentarioIncluir(string nome, string comentario,string email)
        {
            using (var escreverComentario = new StreamWriter(comentarioArquivo, true, Encoding.UTF8))
            {
                //#TODO
                escreverComentario.WriteLine("-------------------------------------------------------------------------------");
                escreverComentario.WriteLine("{0:dd/mm/yyyy} - {1:HH:mm:ss}", DateTime.Now, DateTime.Now);
                escreverComentario.WriteLine("{0}:{1}\r\n", nome, email);
                escreverComentario.WriteLine("{0}\r\n", comentario);
                escreverComentario.WriteLine("-------------------------------------------------------------------------------");

            }
        }

        public static string ComentarioObter()
        {
            string texto = string.Empty;
            if (!File.Exists(comentarioArquivo))
            {
                return texto;
            }
            using (var reader = new StreamReader(comentarioArquivo))
            {
                texto = reader.ReadToEnd();
            }
            return texto;
        }
    

        private static string comentarioArquivo
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/comentario.txt");
            }
        }

    }
}