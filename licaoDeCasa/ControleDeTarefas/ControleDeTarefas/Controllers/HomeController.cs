using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleDeTarefas.Model;
using ControleDeTarefas.Business;

namespace ControleDeTarefas.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NovaTarefa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovaTarefa(Tarefas obejtoTarefas)
        {
            try
            {
                TarefasBUS tarefasBUS = null;
                //verificacao do model state
                if (ModelState.IsValid)
                {
                    //
                    tarefasBUS = new TarefasBUS();
                    var result = tarefasBUS.SalvarTarefa(obejtoTarefas);

                    if (!result)
                    {
                        ModelState.AddModelError("", "Ocorreu uma falha ao tentar adicionar a tarefa, contate o adm do sistema");

                        return View();
                    }
                    else
                    {
                        TempData["MensagemDeRetorno"] = "Tarefa foi adicionada com sucesso";
                        return RedirectToAction("NovaTarefa");
                    }
                }
                else
                {
                    //se formulario invalido ou campo vázio
                    ModelState.AddModelError("", "Por favor preencher todos os formulario");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("Nome"))
                {
                    ModelState.AddModelError("Nome", ex.Message);
                }
                else if (ex.Message.ToLower().Contains("prioridade"))
                {
                    ModelState.AddModelError("prioridade", ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Ocorreu uma falha ao adicioanra a tarefa!");
                }
            }
            return View();
        }

        public ActionResult ListaDeTarefa()
        {
            TarefasBUS tarefasBUS = new TarefasBUS();
            List<Tarefas> listaDeTarefasView = null;

            try
            {
                listaDeTarefasView = tarefasBUS.SelecionarTodasTarefas();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }


            return View(listaDeTarefasView);
        }

        [HttpGet]
        public ActionResult EditarTarefa(int id)
        {
            TarefasBUS tarefasBUS = null;
            Tarefas tarefa = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefasBUS = new TarefasBUS();
                    tarefa = tarefasBUS.SelecionarTarefa(id);
                }
                tarefa = tarefasBUS.SelecionarTarefa(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro na pesquisa do ID informado");
            }

            return View(tarefa);
        }

        [HttpPost]
        public ActionResult EditarTarefa(Tarefas tarefa)
        {
            TarefasBUS tarefasBUS = null;

            try
            {
                if (ModelState.IsValid)
                {
                    tarefasBUS = new TarefasBUS();
                    var retorno = tarefasBUS.AtualziarTarefa(tarefa);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Falha na atualziação do registro");
            }

            return RedirectToAction("ListaDeTarefa");
        }

    }
}
