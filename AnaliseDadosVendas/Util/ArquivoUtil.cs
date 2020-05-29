using System;
using System.IO;

namespace AnaliseDadosVendas.Util
{
    public static class ArquivoUtil
    {
        private static FileSystemWatcher _monitorar;

        public static void MonitorarPastaEGerarRelatorio()
        {
            _monitorar = new FileSystemWatcher(BuscarCaminhoPastaIn(), "*.*")
            {
                IncludeSubdirectories = true
            };
            _monitorar.Created += OnFileCreated;
            _monitorar.EnableRaisingEvents = true;

            LerArquivosPastaIn();
        }
        private static void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            ConverterArquivoVenda.AnalisarArquivoEGerarRelatorioVenda(e.FullPath);
        }

        private static void LerArquivosPastaIn()
        {
            foreach (string file in Directory.EnumerateFiles(BuscarCaminhoPastaIn(), "*.*"))
            {
                ConverterArquivoVenda.AnalisarArquivoEGerarRelatorioVenda(file);
            }
        }

        public static string buscarCaminhoPastaData()
        {
            string pastaDiretorioAtual = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pastaData = Path.GetFullPath(Path.Combine(pastaDiretorioAtual, "..//..", "data"));
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
            string caminhoPastaOut = Path.Combine(buscarCaminhoPastaData(),"out");
            VerificarPastaExistente(caminhoPastaOut);
            return caminhoPastaOut;
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
