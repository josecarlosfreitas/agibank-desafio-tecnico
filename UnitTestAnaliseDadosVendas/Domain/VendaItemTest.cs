using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class VendaItemTest
    {
        [TestMethod]
        public void TesteLinhaParaVendaItem()
        {
            VendaItem vendaItem = new VendaItem(BuscarLinhaArquivoVendaItem());

            Assert.IsTrue(equals(BuscarVendaItem(), vendaItem));
        }

        private string[] BuscarLinhaArquivoVendaItem()
        {
            string[] vendaItem = { "1", "10", "100" };
            return vendaItem;
        }

        private VendaItem BuscarVendaItem()
        {
            return new VendaItem(1, 10, decimal.Parse("100"));
        }

        private bool equals(VendaItem vendaItem1, VendaItem vendaItem2)
        {
            return vendaItem1 != null && vendaItem2 != null
                && vendaItem1.ItemID == vendaItem2.ItemID
                && vendaItem1.ItemPrice == vendaItem2.ItemPrice
                && vendaItem1.ItemQuantity == vendaItem2.ItemQuantity;
        }
    }
}
