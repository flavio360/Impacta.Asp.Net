using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Dados
{
    public static class MetodosDeExtensao
    {
        // para estender as capacidades dos controles, 
        // informamos qual o tipo de controle (classe) que será
        // estendida e a palavra this para "apontar para ele mesmo"

        public static string ValidarVazio(this string txt)
        {
            if (txt.Trim().Equals(""))
            {
                throw new Exception("O Texto não pode ser vazio");
            }
            return txt;
        }










        public static string ValidarEmail(this string  txt)
        {
            if (!Regex.IsMatch(txt,
                @"^[a-zA-Z0-9\._\-]+\@+[a-zA-Z0-9\._\-]+\.[a-zA-Z]+$"))
            {
                throw new Exception("Informe um email válido!");
            }
            return txt;
        }

        //public static DateTime ValidarData(this TextBox txt)
        //{
        //    try
        //    {
        //        return Convert.ToDateTime(txt.Text);
        //    }
        //    catch
        //    {
        //        txt.Focus();
        //        txt.SelectAll();
        //        throw new Exception("Informe uma data válida");
        //    }
        //}

        //public static decimal ValidarDecimal(this TextBox txt)
        //{
        //    try
        //    {
        //        return Convert.ToDecimal(txt.Text);
        //    }
        //    catch
        //    {
        //        txt.Focus();
        //        txt.SelectAll();
        //        throw new Exception("Informe um valor válido");
        //    }
        //}

        public static string RetirarAcentos(this string texto)
        {
            string com_Acentos =
                "ÄÀÁÂÃäàáâãËÈÉÊëèéêÏÌÍÎïìíîÖÒÓÔÕöòóôõÜÙÚÛüùúûÇçÑñ";
            string sem_Acentos =
                "AAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUUuuuuCcNn";

            for (int i = 0; i < com_Acentos.Length; i++)
            {
                texto = texto.Replace(com_Acentos[i], sem_Acentos[i]);
            }
            return texto;
        }

        //public static void LimparTela(this Form formulario)
        //{
        //    foreach (Control ctl in formulario.Controls)
        //    {
        //        if (ctl is TextBox)
        //        {
        //            (ctl as TextBox).Clear();
        //        }
        //        else if (ctl is MaskedTextBox)
        //        {
        //            (ctl as MaskedTextBox).Clear();
        //        }
        //    }
        //}

        //public static bool ValidaCPF(this MaskedTextBox msk)
        //{

        //    return ValidaCPF(msk.Text);

        //}

        public static bool ValidaCPF(this string vrCPF)
        {

            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }
    }

}
