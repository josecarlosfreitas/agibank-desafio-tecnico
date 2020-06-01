using AnaliseDadosVendas.Factory;
using AnaliseDadosVendas.Util;
using Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.IO;

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

                relatorioVendaDTO = new RelatorioVendaArquivoFactory(file).MontarDTO();

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
