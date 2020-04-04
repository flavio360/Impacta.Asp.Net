using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Model
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Obs { get; set; }
        List<Tarefas> tarefas { get; set; }

        //#warning serve para sempre apresentar na Warnings list
        //TODO : aparece na task list
    }
}
