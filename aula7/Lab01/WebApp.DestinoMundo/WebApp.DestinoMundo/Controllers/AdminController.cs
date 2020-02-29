using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApp.DestinoMundo.Db;
using WebApp.DestinoMundo.Models;

namespace WebApp.DestinoMundo.Controllers
{
    public class AdminController : Controller
    {
        private const string ActionDestionListagem = "DestinoListagem";
        // GET: Admin
        public ActionResult DestinoNovo()
        {
            return View();
        }

        //grava a foto
        private string GravarFotos(HttpRequestBase Request)
        {
            string nome = Path.GetFileName(Request.Files[0].FileName);

            string pastaVirtual = "~/Imagens";

            string pathVirtual = pastaVirtual + "/" + nome;

            string pathFisico = Request.MapPath(pathVirtual);

            Request.Files[0].SaveAs(pathFisico);

            return nome;
        }

        private ViangesOnlineDb ObterDbContext()
        {
            return new ViangesOnlineDb();
        }

        [HttpPost]
        public ActionResult DestinoNovo(Destino destino)
        {
            if (!ModelState.IsValid)
            {
                return View(destino);
            }

            if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("", "E necessário enviar uma foto");
                return View(destino);
            }

            try
            {
                destino.Foto = GravarFotos(Request);

                using (var db = ObterDbContext())
                {
                    db.Destinos.Add(destino);
                    db.SaveChanges();
                    return RedirectToAction(ActionDestionListagem);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",ex.Message);
                return View(destino);
            }
        }

        public ActionResult DestinoListagem()
        {
            List<Destino> lista = null;

            using (var db = ObterDbContext())
            {
                lista = db.Destinos.ToList();
            }

            return View(lista);
        }


        [HttpGet]
        public ActionResult DestinoAlterar (int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);

                if (destino != null)
                {
                    return View(destino);
                }

                return RedirectToAction(ActionDestionListagem);
            }
        }

        [HttpPost]
        public ActionResult DestinoAlterar (Destino destino)
        {
            if (ModelState.IsValid)
            {
                using (var db = ObterDbContext())
                {
                    //OBtem o original
                    var destinoOriginal = db.Destinos.Find(destino.DestinoId);

                    if (destinoOriginal != null)
                    {
                        destinoOriginal.Nome = destino.Nome;
                        destinoOriginal.Cidade = destino.Cidade;
                        destinoOriginal.Pais = destino.Pais;

                        if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                        {
                            destinoOriginal.Foto = GravarFotos(Request);
                        }

                        db.SaveChanges();
                        return RedirectToAction(ActionDestionListagem);
                    }
                }
            }
            return View(destino);
            
        }

    }
}