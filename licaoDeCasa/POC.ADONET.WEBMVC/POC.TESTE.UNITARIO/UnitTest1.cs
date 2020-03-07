using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaInsertNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            Assert.IsNotNull(clienteDAL.Add("CHORORO", "CHORRO@PICOTA.COM", "PAI DO FILHO DO VIZINHO"));
        }
    }
}
