using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VendaItem
    {
        public int ItemID { get; set; }
        public int ItemQuantity { get; set; }
        public decimal? ItemPrice { get; set; }

        public VendaItem(string[] arrLinha)
        {
            ItemID = int.Parse(arrLinha[0]);
            ItemQuantity = int.Parse(arrLinha[1]);
            ItemPrice = string.IsNullOrEmpty(arrLinha[2]) ? 0 : decimal.Parse(arrLinha[2].Replace(".", ","));
        }
    }
}
