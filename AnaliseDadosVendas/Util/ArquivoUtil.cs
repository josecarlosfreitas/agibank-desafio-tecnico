using System;
using System.Collections.Generic;
using System.IO;

namespace AnaliseDadosVendas.Util
{
    public static class ArquivoUtil
    {
        public static string buscarCaminhoPastaData()
        {
            string pastaHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pastaData = Path.Combine(pastaHome, "data");
            
            VerificarPastaExistente(pastaData);
            return pastaData;
        }

        public static string BuscarCaminhoPastaIn()
        {
            string caminhoPastaIn = Path.Combine(buscarCaminhoPastaData(), "in");
            VerificarPastaExistente(caminhoPastaIn);
            return caminhoPastaIn;
        }

        public static string BuscarCaminhoPastaOut()
        {
            string caminhoPastaOut = Path.Combine(buscarCaminhoPastaData(), "out");
            VerificarPastaExistente(caminhoPastaOut);
            return caminhoPastaOut;
        }

        public static List<string> ConverterArquivoEmListaDeStringLinha(string file)
        {
            string linha;
            List<string> strLinha = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while ((linha = sr.ReadLine()) != null)
                    {
                        strLinha.Add(linha);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception($"Não foi possível ler o arquivo. erro gerado: {ex.Message}"); ;
            }

            return strLinha;
        }

        public static void GravarArquivoPastaOut(string file, List<string> linhasArquivo)
        {
            string fileName = $"{ ArquivoUtil.BuscarCaminhoPastaOut() }\\analiseDados_{ Path.GetFileName(file) }";

            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach (var linhaArquivo in linhasArquivo)
                    {
                        sw.WriteLine(linhaArquivo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #region Validações

        private static void VerificarPastaExistente(string caminho)
        {
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
        }

        public static void ValidarArquivo(string file, string tipoArquivoValidado)
        {
            ValidarArquivoExistente(file);

            if (!string.IsNullOrEmpty(tipoArquivoValidado))
            {
                ValidarTipoArquivo(file, tipoArquivoValidado);
            }
        }

        public static void ValidarTipoArquivo(string file, string tipoArquivoValidado)
        {
            if (Path.GetExtension(file) != tipoArquivoValidado)
            {
                throw new Exception($"Extensão do arquivo { Path.GetFileName(file) } inválida! É permitido apenas {tipoArquivoValidado}");
            }
        }

        public static bool ValidarArquivoExistente(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("file");
            }

            if (!File.Exists(file))
            {
                throw new Exception("Arquivo não existe no local.");
            }
            return true;
        }

        #endregion

    }
}
