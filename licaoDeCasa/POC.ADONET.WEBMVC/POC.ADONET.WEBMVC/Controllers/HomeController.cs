﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POC.ADONET.BLL;
using POC.ADONET.MODELS;

namespace POC.ADONET.WEBMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TodosLivros()
        {
            LivrosBLL livroBLL = new LivrosBLL();

            var lista = livroBLL.BuscarTodosLivros();

            //RETORNA LISTA TIPADA DE LIVROS
            //OBTIDOS PELA CAMADA BLL (BUSINES LAYER)
            return View(lista);
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
    }
}