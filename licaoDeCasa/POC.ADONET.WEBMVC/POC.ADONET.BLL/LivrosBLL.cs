using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using POC.ADONET.DAL;

namespace POC.ADONET.BLL
{
    public class LivrosBLL
    {
        //Criar uma variável tipo DAL
        LivrosDAL livrosDAL;

        public List<LivrosMOD> BuscarTodosLivros()
        {
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }
                //retorna o resultado do metodo que ja defini como uma lista;
               return livrosDAL.GetBooks();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
