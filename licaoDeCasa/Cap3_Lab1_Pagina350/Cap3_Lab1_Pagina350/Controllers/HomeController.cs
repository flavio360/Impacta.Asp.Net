using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Cap3_Lab1_Pagina350.Models;

namespace Cap3_Lab1_Pagina350.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portifolio()
        {
            string pathVirtual = "~/Imagens/MinhaVida/";

            string pathFisico = Server.MapPath(pathVirtual);

            string[] arquivos = Directory.GetFiles(pathFisico);

            List<string> imageUrlList = new List<string>();

            foreach (string arquivo in arquivos)
            {
                string nomeArquivo = Path.GetFileName(arquivo);

                string imgUrl = Url.Content(pathVirtual + nomeArquivo);

                imageUrlList.Add(imgUrl);
            }

            ViewBag.imageUrlList = imageUrlList;

            return View();
        }

        public ActionResult Contato()
        {
            
            ViewBag.Concluido = false;
            return View();

        }

        [HttpPost]
        public ActionResult Contato(ContatoViewModel contato)
        {
            string pathVirtual = "~/contatos.txt";
            string pathLocal = Server.MapPath(pathVirtual);

            using (var sw = new StreamWriter(pathLocal, true))
            {
                sw.WriteLine(contato.Nome);
                sw.WriteLine(contato.Menssagem);
                sw.WriteLine(contato.Email);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine();
            }

            ViewBag.Concluido = true;

                return View();
        }

        public ActionResult Mensagem()
        {
            string line = string.Empty;
            string pathVirtual = "~/contatos.txt";
            string pathLocal = Server.MapPath(pathVirtual);
         

            StreamReader sw = new StreamReader(pathLocal);

            while ((line = sw.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                List<string> msgRecebidas = new List<string>();
                
            }

             sw.Close();

              
            return View();
        }
    }
}