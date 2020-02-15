using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Web.App.Perfil.Models;

namespace Web.App.Perfil.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContatoViewModel contact)
        {
            string pathVirtual = "~/contatos.txt";

            string pathFisico = Server.MapPath(pathVirtual);

            using (var sw = new StreamWriter(pathFisico, true))
            {
                sw.WriteLine(contact.Nome);

                sw.WriteLine(contact.Email);

                sw.WriteLine(contact.Mensagem);

                sw.WriteLine(DateTime.Now);

                sw.WriteLine();

                ViewBag.Concluido = true;
            }
                return View();
        }


        public ActionResult Portifolio()
        {
            string pathVirtual = "~/imagens/Portifolio/" ;

            string pathFisico = Server.MapPath(pathVirtual);

            string[] arquivos = Directory.GetFiles(pathFisico);

            List<string> imageUrlList = new List<string>();

            foreach (string arquivo in arquivos)
            {
                string nomeArquivo = Path.GetFileName(arquivo);
                string imageUrl = Url.Content(pathVirtual + nomeArquivo);

                imageUrlList.Add(imageUrl);
            }

            ViewBag.ImageUrlList = imageUrlList;


            return View();
        }



    }
}