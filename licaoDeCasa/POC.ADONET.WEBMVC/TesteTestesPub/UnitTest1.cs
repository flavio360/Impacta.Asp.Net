using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;
using POC.ADONET.MODELS;

namespace TesteTestesPub
{
    [TestClass]
    public class UnitTest1
    {
        //teste para insert na tabela title bd pubs
        [TestMethod]
        public void TestaInsertNRaTabelaLivros()
        {
            LivrosDAL livrosDAL = new LivrosDAL();

            Assert.IsNotNull(livrosDAL.AdcionaRegistro(7777,"piporota","CHORRO@PICOTA.COM", "5689", 28.71, 50.01, 200, 4040, "teste insert final", "1991-06-12"));
        }

        [TestMethod]
        public void TestarUpdateNaTabelaCloneLiVROS()
        {
            LivrosDAL livrosDAL = new LivrosDAL();
            LivrosMOD livroAlteraTeste = new LivrosMOD();

            livroAlteraTeste.Id = "0";
            livroAlteraTeste.Preco = 1009.98;
            livroAlteraTeste.Resenha = "Update a partir da SL alterar valor como double";



            Assert.IsNotNull(livrosDAL.AlteraRegistro(livroAlteraTeste));
        }

    }
}
