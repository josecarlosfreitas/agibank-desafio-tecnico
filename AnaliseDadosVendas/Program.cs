using AnaliseDadosVendas.Util;
using System;

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
