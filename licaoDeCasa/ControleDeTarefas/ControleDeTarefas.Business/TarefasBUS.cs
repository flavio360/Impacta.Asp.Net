using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Data;
using ControleDeTarefas.Model;

namespace ControleDeTarefas.Business
{
    public class TarefasBUS
    {
        public bool SalvarTarefa(Tarefas objtarefas)
        {
            if (Validar(objtarefas))
            {
                //se retornou true, é por que todos dados estão válidos.
                Repository.Incluir(objtarefas);
            }

            return true;
        }

        //
        // Validar
        //
        private bool Validar(Tarefas objtarefas)
        {
            //Nome é obrigatório
            if (string.IsNullOrEmpty(objtarefas.Nome) ||
            objtarefas.Nome.Trim().Length == 0)
            {
                throw new Exception(
                "Informe o nome da tarefa");
            }
            //Prioridade é um número entre 1 e 3
            if (objtarefas.Prioridade < 1 ||
            objtarefas.Prioridade > 3)
            {
                throw new Exception(
                "A prioridade deve ser um número entre 1 e 3");
            }
            // Formata observações para ficar Null
            // Isso facilita algumas Conversões de Dados
            if (objtarefas.Obs == null)
            {
                objtarefas.Obs = string.Empty;
            }

            return true;
        }


        public List<Tarefas> SelecionarTodasTarefas()
        {
            return Repository.ObterTodasTarefas();
        }


        public Tarefas SelecionarTarefa(int id)
        {
            //camada web bussines que chama camada repository que devolve para web
            return Repository.ObterTarefa(id);
        }

        public bool AtualziarTarefa(Tarefas tarefa)
        {
            if (Validar(tarefa))
            {
                return Repository.AtualizarTarefa(tarefa);
            }

            //se o metodo que fvalida os campos retornar falso, devolvemos resultado 
            return false;
        }
    }
}
