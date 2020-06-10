using AnaliseDadosVendas.Domain.Entities;
using AnaliseDadosVendas.Domain.Entities.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class RelatorioVendaDTOTest
    {
        [TestMethod]
        public void TesteNomePiorVendedor()
        {
            string nomePiorVendedor = BuscarRelatorioVendaDTO().BuscarNomePiorVendedor();

            Assert.IsTrue(nomePiorVendedor.Equals("Paulo"));
        }

        [TestMethod]
        public void TesteVendaMaisCara()
        {
            int idVendaMaisCara = BuscarRelatorioVendaDTO().BuscarIdVendaMaisCara() ?? 0;

            Assert.IsTrue(idVendaMaisCara == 10);
        }

        [TestMethod]
        public void TesteQuantidadeCliente()
        {
            int quantidadeCliente = BuscarRelatorioVendaDTO().Clientes?.Count ?? 0;

            Assert.IsTrue(quantidadeCliente == 2);
        }

        [TestMethod]
        public void TesteQuantidadeVendedor()
        {
            int quantidadeVendedor = BuscarRelatorioVendaDTO().Vendedores?.Count ?? 0;

            Assert.IsTrue(quantidadeVendedor == 2);
        }

        #region Montagem de dados para a DTO

        private RelatorioVendaDTO BuscarRelatorioVendaDTO()
        {
            RelatorioVendaDTO relatorioVendaDTO = new RelatorioVendaDTO();
            relatorioVendaDTO.Clientes = BuscarClientes();
            relatorioVendaDTO.Vendedores = BuscarVendedores();
            relatorioVendaDTO.Vendas = BuscarVendas();

            return relatorioVendaDTO;
        }

        private List<Cliente> BuscarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente("2345675434544345", "Jose da Silva", "Rural"));
            clientes.Add(new Cliente("2345675433444345", "Eduardo Pereira", "Rural"));

            return clientes;
        }

        private List<Vendedor> BuscarVendedores()
        {
            List<Vendedor> vendedores = new List<Vendedor>();
            vendedores.Add(new Vendedor("1234567891234", "Pedro", decimal.Parse("50000")));
            vendedores.Add(new Vendedor("3245678865434", "Paulo", decimal.Parse("40000,99")));

            return vendedores;
        }

        private List<Venda> BuscarVendas()
        {
            List<Venda> vendas = new List<Venda>();
            vendas.Add(new Venda(10, "Pedro", BuscarVendaItemPedro()));
            vendas.Add(new Venda(8, "Paulo", BuscarVendaItemPaulo()));

            return vendas;
        }

        private List<VendaItem> BuscarVendaItemPedro()
        {
            List<VendaItem> itens = new List<VendaItem>();
            itens.Add(new VendaItem(1, 10, decimal.Parse("100")));
            itens.Add(new VendaItem(2, 30, decimal.Parse("2,50")));
            itens.Add(new VendaItem(3, 40, decimal.Parse("3,10")));

            return itens;
        }

        private List<VendaItem> BuscarVendaItemPaulo()
        {
            List<VendaItem> itens = new List<VendaItem>();
            itens.Add(new VendaItem(1, 34, decimal.Parse("10")));
            itens.Add(new VendaItem(2, 33, decimal.Parse("1,50")));
            itens.Add(new VendaItem(3, 40, decimal.Parse("0,10")));

            return itens;
        }

        #endregion
    }
}
