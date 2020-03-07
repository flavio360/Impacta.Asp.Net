using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cap04_Lab01_Pagina_392.Db;
using System.Web.Mvc;


namespace Cap04_Lab01_Pagina_392.Controllers
{
    public class ViagensOnLineController : Controller
    {
        public ActionResult Inicio()
        {
            return View();
        }


        public ActionResult Destinos()
        {
            using (var db = new ViagensOnLineDb())
            {
                return View(db.Destinos.ToArray());
            }
        }
    }
}