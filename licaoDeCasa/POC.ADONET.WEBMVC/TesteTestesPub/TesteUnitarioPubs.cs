using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;
using POC.ADONET.MODELS;

namespace TesteTestesPub
{
    class TesteUnitarioPubs
    {
        //teste para insert na tabela title bd pubs
        [TestMethod]
        public void TestaInsertNRaTabelaLivros()
        {
            LivrosDAL livrosDAL = new LivrosDAL();

           // Assert.IsNotNull(livrosDAL.AdcionaRegistro("CHORORO", "CHORRO@PICOTA.COM", "1888", 20.00, 5000.00, 10, 4040, "teste insert pubs", ""));
        }
    }
}
