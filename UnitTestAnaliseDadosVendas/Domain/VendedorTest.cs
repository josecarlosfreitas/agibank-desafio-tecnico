using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class VendedorTest
    {
        [TestMethod]
        public void TesteLinhaParaVendedor()
        {
            Vendedor vendedor = new Vendedor(BuscarLinhaArquivoVendedor());

            Assert.IsTrue(equals(BuscarVendedor(), vendedor));
        }

        private string[] BuscarLinhaArquivoVendedor()
        {
            string[] vendedor = { "001", "3245678865434", "Paulo", "40000.99" };
            return vendedor;
        }

        private Vendedor BuscarVendedor()
        {
            return new Vendedor("3245678865434", "Paulo", decimal.Parse("40000.99"));
        }

        private bool equals(Vendedor vendedor1, Vendedor vendedor2)
        {
            return vendedor1 != null && vendedor2 != null
                && vendedor1.CPF == vendedor2.CPF
                && vendedor1.Salary == vendedor2.Salary
                && vendedor1.Name == vendedor2.Name;
        }
    }
}
