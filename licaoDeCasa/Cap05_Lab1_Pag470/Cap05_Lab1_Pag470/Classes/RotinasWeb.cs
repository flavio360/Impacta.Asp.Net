using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cap05_Lab1_Pag470.Models;
using Cap05_Lab1_Pag470.Classes;
using System.IO;
using System.Text;

namespace Cap05_Lab1_Pag470.Classes
{
    public  class RotinasWeb
    {
        public static void ContatoGravar(ContatoViewModel contato)
        {
            bool a;
            try
            {
                #region//VALIDAR CPF INFORMADO NO CAMPO

                a = contato.CPF.Length == 11 && contato.CPF != string.Empty ? true : false;

                if (a)
                {
                    a = Util.ValidarCPF(contato.CPF);
                }
                #endregion
                if (a)
                {
                    string arquivo = HttpContext.Current.Server.MapPath("~/App_Data/Contatos.txt");

                    using (var sw = new StreamWriter(arquivo, true, Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine(contato.Nome);
                        sw.WriteLine(contato.Email);
                        sw.WriteLine(contato.Assunto);
                        sw.WriteLine(contato.Mensagem);
                        sw.WriteLine(contato.CPF);
                        sw.WriteLine(new string('-', 30));
                    }
                }                
            }
            catch (Exception )
            {

                throw;
            }            
        }        
    }
}