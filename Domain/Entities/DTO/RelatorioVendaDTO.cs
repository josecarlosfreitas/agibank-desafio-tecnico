using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.DTO
{
    public class RelatorioVendaDTO
    {
        public List<Vendedor> Vendedores { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Venda> Vendas { get; set; }

        public RelatorioVendaDTO()
        {
            Vendedores = new List<Vendedor>();
            Clientes = new List<Cliente>();
            Vendas = new List<Venda>();
        }

        public string BuscarNomePiorVendedor()
        {
            return (from v in Vendas
                    group v by v.SalesmanName
                                into grupo
                    select new
                    {
                        Salesman = grupo.Key,
                        ValorVendido = (from i in grupo select i.vendaItens?.Sum(vi => vi.ItemPrice * vi.ItemQuantity))?.ToList().Sum()
                    })?.OrderBy(g => g.ValorVendido).Select(g => g.Salesman).FirstOrDefault();
        }

        public int? BuscarIdVendaMaisCara()
        {
            return Vendas?.OrderByDescending(v => v.vendaItens.Sum(i => i.ItemPrice * i.ItemQuantity)).FirstOrDefault()?.SaleID;
        }

    }
}
