using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Cap04_Lab01_Pagina_392.Db;
using Cap04_Lab01_Pagina_392.Models;
using System.Security.Claims;

namespace Cap04_Lab01_Pagina_392.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private const string ActionDestinoListagem = "DestinoListagem";
        private const string ActionDestinoNovo = "DestinoNovo";
        private const string ActionInicio = "Inicio";
        // GET: Admin
        public ActionResult Inicio()
        {
            return View();
            
        }

        public ActionResult DestinoNovo()
        {
            return View("DestinoNovo");
        }

        //
        // Gravar Foto
        //
        private string GravarFoto(HttpRequestBase Request)
        {
            string nome = Path.GetFileName(Request.Files[0].FileName);
            string pastaVirtual = "~/imagens";
            string pathVirtual = pastaVirtual + "/" + nome;
            string pathFisico = Request.MapPath(pathVirtual);
            Request.Files[0].SaveAs(pathFisico);
            return nome;
        }


        //
        // Retorna uma Instância de DbContext
        //
        private ViagensOnLineDb ObterDbContext()
        {
            return new ViagensOnLineDb();
        }


        //
        // Gravar Novo Destino
        //
       
        [HttpPost]
        public ActionResult DestinoNovo(Destino destino)
        {
            //Se alguma validação falhou...
            if (!ModelState.IsValid)
            {
                return View(destino);
            }
            // Foto é obrigatória
            if (Request.Files.Count == 0 ||
            Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("",
                "É necessário enviar uma Foto»");
                return View(destino);
            }
            //Grava
            try
            {
                //Grava a foto e retorna o nome
                destino.Foto = GravarFoto(Request);
                using (var db = ObterDbContext())
                {
                    db.Destinos.Add(destino);
                    db.SaveChanges();
                    return RedirectToAction(ActionDestinoListagem);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(destino);
            }


        }
       
        public ActionResult MinhaView()
        {
            return View();


        }

       // [Authorize]
        public ActionResult DestinoListagem()
        {
            List<Destino> lista = null;
            using (var db = ObterDbContext())
            {
                lista = db.Destinos.ToList();
            }

            return View(lista);
        }

        //alterar a imagem        
        [HttpGet]
        public ActionResult DestinoAlterar(int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null) 
                { 
                    return View(destino);
                }
            }
            return RedirectToAction(ActionDestinoListagem);
        }


        //
        // Confirmar antes de excluir
        //
        [HttpGet]
        public ActionResult DestinoExcluir(int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null)
                {
                    return View(destino);
                }
            }
            return RedirectToAction(ActionDestinoListagem);
        }
        //
        // Excluir
        //
        [HttpPost]
        public ActionResult DestinoExcluir(int id,
        FormCollection form)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null)
                {
                    db.Destinos.Remove(destino);
                    db.SaveChanges();
                }
            }
            return RedirectToAction(ActionDestinoListagem);
        }


        //Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string nome, string senha)
        {
            if (string.IsNullOrEmpty(nome))
            {
                ViewBag.Mensagem = "Digite o nome";
                return View();
            }
            if (string.IsNullOrEmpty(senha))
            {
                ViewBag.Mensagem = "Digite o senha";
                return View();
            }
            if (nome != "admin" && senha != "admin")
            {
                @ViewBag.Mensagem = "Usuário ou senha inválida";
                return View();
            }


            Claim[] claims = new Claim[3];
            claims[0] = new Claim(ClaimTypes.Name, "Administrador");
            claims[1] = new Claim(ClaimTypes.Role, "admin");
            claims[2] = new Claim(ClaimTypes.NameIdentifier, "admin");

            //Nome para identificar
            string nomeAutenticacao = "AppViagensOnlineCookie";

     
            ClaimsIdentity identity = new ClaimsIdentity(claims, nomeAutenticacao);

            Request.GetOwinContext().Authentication.SignIn(identity);

            //Redireciona para a pasta destinos
           // return RedirectToAction("DestinoNovo");
            return RedirectToAction(ActionInicio);
            //return View("DestinoListagem");
        }


        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }

}