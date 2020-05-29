using AnaliseDadosVendas.Builders;
using AnaliseDadosVendas.Util;
using Domain.Entities.DTO;
using System;
using System.IO;
using System.Linq;

namespace AnaliseDadosVendas
{
    public static class ConverterArquivoVenda
    {
        public static void AnalisarArquivoEGerarRelatorioVenda(string file)
        {
            RelatorioVendaDTO relatorioVendaDTO;
            try
            {
                ArquivoUtil.ValidarArquivo(file, ".txt");

                relatorioVendaDTO = new RelatorioVendaArquivoBuilder(file).MontarDTO();

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
            string fileName = $"{ ArquivoUtil.BuscarCaminhoPastaOut() }\\analiseDados_{ Path.GetFileName(file) }";

            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("Quantidade de clientes: {0}", relatorioVendaDTO.Clientes?.Count ?? 0);
                    sw.WriteLine("Quantidade de vendedores: {0}", relatorioVendaDTO.Vendedores?.Count ?? 0);
                    sw.WriteLine("ID da venda mais cara: {0}", relatorioVendaDTO.BuscarIdVendaMaisCara() ?? 0);
                    sw.WriteLine("Pior vendedor: {0}", relatorioVendaDTO.BuscarNomePiorVendedor());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
