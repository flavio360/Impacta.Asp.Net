using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;
using POC.ADONET.MODELS;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaInsertNRaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            Assert.IsNotNull(clienteDAL.Add("CHORORO", "CHORRO@PICOTA.COM", "PAI DO FILHO DO VIZINHO"));
        }

         [TestMethod]
         public void TestarBuscarDadosNaTabelaCliente()
         {
             ClienteDAL clienteDAL = new ClienteDAL();
            Assert.IsNotNull(clienteDAL.selectAll());
         }

        [TestMethod]//busca os dados na tabela por ID
        public void TestarAtualziarNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;

            //executa p select por id
            cliente = clienteDAL.selectById(1001);

            //atribui dados para teste do udate.
            cliente.Nome = "TesteAlterar";
            cliente.Email = "EmailTeste";
            cliente.Observacao = "ObsTeste";

            //verifica se resultado é diferente de null
            Assert.IsNotNull(clienteDAL.Update(cliente, cliente.Id));
            Assert.AreNotEqual("", cliente.Nome);


        }

        //update
        [TestMethod]
        public void TestarAlteracaoNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;
            int id = 1;

            //executa p select por id
            cliente = clienteDAL.selectById(id);

            cliente.Nome = "NomeTeste";
            cliente.Email = "EmailTeste";
            cliente.Observacao = "ObsTeste";

            clienteDAL.Update(cliente, cliente.Id);
        }


        //deleta
        [TestMethod]
        public void TestarApagarRegistroTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            int id = 1005;

            Assert.IsTrue(clienteDAL.DeleteById(id));
        }



       
    }


}
