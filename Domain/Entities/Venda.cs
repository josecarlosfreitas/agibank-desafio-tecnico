using System.Collections.Generic;

namespace Domain.Entities
{
    public class Venda
    {
        public int SaleID { get; set; }
        public string SalesmanName { get; set; }

        public List<VendaItem> vendaItens { get; set; }

        public Venda(int saleID, string salesmanName, List<VendaItem> vendaItens)
        {
            SaleID = saleID;
            SalesmanName = salesmanName;
            this.vendaItens = vendaItens;
        }

        public Venda(string[] arrLinha)
        {
            SaleID = int.Parse(arrLinha[1]);
            SalesmanName = arrLinha[3];
            TransformarStringEmItensDaVenda(arrLinha[2]);
        }

        private void TransformarStringEmItensDaVenda(string strLinha)
        {
            vendaItens = new List<VendaItem>();
            string itemsLine = strLinha.Substring(1, strLinha.Length - 2);

            foreach (var item in itemsLine.Split(','))
            {
                VendaItem vendaItem = new VendaItem(item.Split('-'));
                vendaItens.Add(vendaItem);
            }
        }
    }
}
