using AnaliseDadosVendas.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;

namespace UnitTestAnaliseDadosVendas
{
    [TestClass]
    public class ArquivoUtilTest
    {
        public TestContext TestContext { get; set; }
        private string _NomeArquivoTeste;
        private string _NomeArquivoTesteNaoExistente = @"C:\ArquivoNaoExistente.txt";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NomeArquivoNuloOuVazio_ThrowsArgumentNullException()
        {
            ArquivoUtil.ValidarArquivoExistente("");
        }

        [TestMethod]
        public void NomeArquivoExistente()
        {
            bool arquivoExistente;

            TestContext.WriteLine($"Criando arquivo: {_NomeArquivoTeste}");
            SetNomeArquivoTeste();
            
            TestContext.WriteLine($"Testando arquivo: {_NomeArquivoTeste}");
            File.AppendAllText(_NomeArquivoTeste, "1 2 3 teste.");
            arquivoExistente = ArquivoUtil.ValidarArquivoExistente(_NomeArquivoTeste);
            
            TestContext.WriteLine($"Deletando arquivo: {_NomeArquivoTeste}");
            File.Delete(_NomeArquivoTeste);

            Assert.IsTrue(arquivoExistente);
        }

        private void SetNomeArquivoTeste()
        {
            _NomeArquivoTeste = ConfigurationManager.AppSettings["NomeArquivoTeste"];
            if (_NomeArquivoTeste.Contains("[AppPath]"))
            {
                _NomeArquivoTeste = _NomeArquivoTeste.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NomeArquivoNaoExistente()
        {
            ArquivoUtil.ValidarArquivoExistente(_NomeArquivoTesteNaoExistente);
        }

    }
}
