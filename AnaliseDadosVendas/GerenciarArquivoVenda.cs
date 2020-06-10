using AnaliseDadosVendas.Domain.Entities.DTO;
using AnaliseDadosVendas.Factory;
using AnaliseDadosVendas.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace AnaliseDadosVendas
{
    public class GerenciarArquivoVenda
    {
        private IRelatorioVendaFactory _relatorioVendaFactory;
        private FileSystemWatcher _monitorar;


        public GerenciarArquivoVenda(IRelatorioVendaFactory relatorioVendaFactory)
        {
            _relatorioVendaFactory = relatorioVendaFactory;
        }

        public void MonitorarPastaEGerarRelatorio()
        {
            _monitorar = new FileSystemWatcher(ArquivoUtil.BuscarCaminhoPastaIn(), "*.*")
            {
                IncludeSubdirectories = true
            };
            _monitorar.Created += OnFileCreated;
            _monitorar.EnableRaisingEvents = true;

            LerArquivosPastaIn();
        }
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            AnalisarArquivoEGerarRelatorioVenda(e.FullPath);
        }

        private void LerArquivosPastaIn()
        {
            foreach (string file in Directory.EnumerateFiles(ArquivoUtil.BuscarCaminhoPastaIn(), "*.*"))
            {
                AnalisarArquivoEGerarRelatorioVenda(file);
            }
        }

        public void AnalisarArquivoEGerarRelatorioVenda(string file)
        {
            RelatorioVendaDTO relatorioVendaDTO;
            try
            {
                ArquivoUtil.ValidarArquivo(file, ".txt");

                relatorioVendaDTO = _relatorioVendaFactory.MontarDTO(file);

                GerarRelatorioVenda(file, relatorioVendaDTO);

                Console.WriteLine("Relatório gerado com sucesso.");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GerarRelatorioVenda(string file, RelatorioVendaDTO relatorioVendaDTO)
        {
            ArquivoUtil.GravarArquivoPastaOut(file, new List<string>
            {
                string.Format("Quantidade de clientes: {0}", relatorioVendaDTO.Clientes?.Count ?? 0),
                string.Format("Quantidade de vendedores: {0}", relatorioVendaDTO.Vendedores?.Count ?? 0),
                string.Format("ID da venda mais cara: {0}", relatorioVendaDTO.BuscarIdVendaMaisCara() ?? 0),
                string.Format("Pior vendedor: {0}", relatorioVendaDTO.BuscarNomePiorVendedor())
            });
        }
    }
}
