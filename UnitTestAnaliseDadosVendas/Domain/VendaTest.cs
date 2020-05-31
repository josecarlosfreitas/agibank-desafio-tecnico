using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class VendaTest
    {
        [TestMethod]
        public void TesteLinhaParaVenda()
        {
            Venda venda = new Venda(BuscarLinhaArquivoVenda());

            Assert.IsTrue(equals(BuscarVenda(), venda));
        }

        private string[] BuscarLinhaArquivoVenda()
        {
            string[] venda = { "003", "10", "[1-10-100,2-30-2.50,3-40-3.10]", "Pedro" };
            return venda;
        }

        private Venda BuscarVenda()
        {
            return new Venda(10, "Pedro", BuscarVendaItem());
        }

        private List<VendaItem> BuscarVendaItem()
        {
            List<VendaItem> listaItem = new List<VendaItem>();
            listaItem.Add(new VendaItem(1, 10, decimal.Parse("100")));
            listaItem.Add(new VendaItem(2, 30, decimal.Parse("2,50")));
            listaItem.Add(new VendaItem(3, 40, decimal.Parse("3,10")));

            return listaItem;
        }

        private bool equals(Venda venda1, Venda venda2)
        {
            return venda1 != null && venda2 != null
                && venda1.SaleID == venda2.SaleID
                && venda1.SalesmanName == venda2.SalesmanName
                && VerificarItensIguais(venda1.vendaItens, venda2.vendaItens);
        }

        private bool VerificarItensIguais(List<VendaItem> listaItem1, List<VendaItem> listaItem2)
        {
            return (listaItem1 == null && listaItem2 == null)
                || (!listaItem1.Any(l => !listaItem2.Any(
                    l1 => l1.ItemID == l.ItemID &&
                    l1.ItemPrice == l.ItemPrice &&
                    l1.ItemQuantity == l.ItemQuantity)));
        }
    }
}
