using AnaliseDadosVendas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseDadosVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            ArquivoUtil.MonitorarPastaEGerarRelatorio();
            Console.ReadLine();
        }
    }
}
