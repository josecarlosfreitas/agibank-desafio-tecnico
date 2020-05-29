using AnaliseDadosVendas.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class ConverterArquivoVendaTest
    {
        [TestMethod]
        public void TestePrincipalGeracaoRelatorio()
        {
            CriarArquivoTesteNaPastaIn();
            ArquivoUtil.MonitorarPastaEGerarRelatorio();
            bool arquivoGerado;
            arquivoGerado = VerificarRelatorioGeradoNaPastaOut();

            Assert.IsTrue(arquivoGerado);
        }

        private bool VerificarRelatorioGeradoNaPastaOut()
        {
            string nomeArquivo = $"{ ArquivoUtil.BuscarCaminhoPastaOut() }\\analiseDados_teste.txt";
            return File.Exists(nomeArquivo);
        }

        private void CriarArquivoTesteNaPastaIn()
        {
            string fileName = $"{ ArquivoUtil.BuscarCaminhoPastaIn() }\\teste.txt";
            if (!File.Exists(fileName))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("001ç1234567891234çPedroç50000");
                        sw.WriteLine("002ç2345675434544345çJose da SilvaçRural");
                        sw.WriteLine("002ç2345675433444345çEduardo PereiraçRural");
                        sw.WriteLine("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro");
                        sw.WriteLine("003ç12ç[1-10-110,2-30-2.50,3-40-3.10]çCarlos");
                        sw.WriteLine("003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo");
                        sw.WriteLine("003ç09ç[1-34-100,2-33-1.50,3-40-0.10]çPaulo");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
