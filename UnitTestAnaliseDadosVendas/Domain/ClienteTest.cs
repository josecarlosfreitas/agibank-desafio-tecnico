using AnaliseDadosVendas.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAnaliseDadosVendas.Domain
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void TesteLinhaParaCliente()
        {
            Cliente cliente = new Cliente(BuscarLinhaArquivoCliente());

            Assert.IsTrue(equals(BuscarCliente(), cliente));
        }

        private string[] BuscarLinhaArquivoCliente()
        {
            string[] cliente = { "002", "2345675434544345", "Jose da Silva", "Rural" };
            return cliente;
        }

        private Cliente BuscarCliente()
        {
            return new Cliente("2345675434544345", "Jose da Silva", "Rural");
        }

        private bool equals(Cliente cliente1, Cliente cliente2)
        {
            return cliente1 != null && cliente2 != null
                && cliente1.CNPJ == cliente2.CNPJ
                && cliente1.BusinessArea == cliente2.BusinessArea
                && cliente1.Name == cliente2.Name;
        }
    }
}
