using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_App_TarefasAdoNet.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Obs { get; set; }

        public List<string> lista { get; set; }

#warning serve para sempre apresentar na Warnings list
        //TODO : aparece na task list
    }
}