using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditoraFechaRocombole.Web.MVC.Utils;

namespace EditoraFechaRocombole.Web.MVC.Controllers
{
    public class InicioController : Controller
    {
        #region
        //variaveis


        #endregion

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]//defini que só vai responder pelo metodo get
        public ActionResult Contato()
        {
            //retorna a view correspondente com a actionresultcontato
            return View();
        }

        [HttpPost]
        public ActionResult Contato(FormCollection form)
        {
            try
            {
                var emailRemetente = form["Email"];
                var nomeRemetente = form["Nome"];
                var emailDestino = form["Email"];
                var assunto = form["Assunto"];
                var menssage = form["Mensagem"];
                //classe enviar email
                EnviarEmail enviaEstaBudega = new EnviarEmail(emailRemetente, emailDestino, nomeRemetente, menssage, assunto);

                //TODO : remover comentadrio
                //enviaEstaBudega.Send();
                ViewBag.MensagemEnviada = "Enviado com sucesso";
                ViewData["MensagemEnviada"] = "Enviado com sucesso";

                
            }
            catch (Exception)
            {

                throw;
            }
            
            finally
            {
                
            }

            return View();

        }
    }
}