using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cap05_Lab1_Pag470.Models;
using Cap05_Lab1_Pag470;
using System.IO;
using System.Text;
using Cap05_Lab1_Pag470.Classes;

namespace Cap05_Lab1_Pag470.Classes
{
    public class RotinasWeb
    {      
        public static void ContatoGravar(ContatoViewModel contato)
        {            
            //VALIDAR CPF INFORMADO NO CAMPO
            if (contato.CPF != string.Empty)
                {
                string CPFValidar;
                bool a;

                CPFValidar = contato.CPF;

                a = ValidarCPF(CPFValidar);
                } 

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
        public  static bool ValidarCPF(string txt)
        {

            //txt = txt.RemoverCaracteresEspeciais();

            char[] digiCPF = new char[10];

            int regressivo = 10;
            int conta = 0;
            int soma = 0;
            string validaCPF = string.Empty;

            digiCPF = txt.ToCharArray();

            #region Trata o primeiro digito
            for (int i = 0; i < 9; i++)
            {
                conta = regressivo * Convert.ToInt32(digiCPF[i] - '0');
                regressivo--;
                soma = soma + conta;
            }

            conta = soma % 11;
            soma = 11 - conta;

            if (soma >= 10)
            {
                digiCPF[10] = '0';
            }
            else
            {
                digiCPF[9] = Convert.ToChar(Convert.ToString(soma));
            }
            #endregion

            regressivo = 11;
            soma = 0;
            conta = 0;

            for (int i = 0; i < 10; i++)
            {
                conta = regressivo * Convert.ToInt32(digiCPF[i] - '0');
                regressivo--;
                soma = soma + conta;
            }

            conta = soma % 11;
            soma = 11 - conta;

            if (soma >= 10)
            {
                digiCPF[10] = '0';
            }
            else
            {
                digiCPF[10] = Convert.ToChar(Convert.ToString(soma));
            }

            regressivo = 11;

            for (int i = 0; i < regressivo; i++)
            {
                validaCPF = validaCPF + digiCPF[i];

            }

            if (txt == validaCPF)
            {
                return true;
            }
            return false;
        }
    }
}