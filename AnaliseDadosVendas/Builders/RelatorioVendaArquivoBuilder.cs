using AnaliseDadosVendas.Util;
using Domain.Entities;
using Domain.Entities.DTO;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace AnaliseDadosVendas.Builders
{
    public class RelatorioVendaArquivoBuilder : IRelatorioVendaBuilder
    {
        RelatorioVendaDTO _relatorioVendaDTO;
        string _file;
        char SEPARADOR_LINHA_DE_ARQUIVO = 'ç';

        public RelatorioVendaArquivoBuilder(string file)
        {
            _file = file;
            _relatorioVendaDTO = new RelatorioVendaDTO();
        }

        public RelatorioVendaDTO MontarDTO()
        {
            List<string> linhasArquivo = ArquivoUtil.ConverterArquivoEmListaDeStringLinha(_file);
            foreach (var linhaArquivo in linhasArquivo)
            {
                string[] arrLinhaArquivo = linhaArquivo.Split(SEPARADOR_LINHA_DE_ARQUIVO);

                ValidarLinhaArquivo(arrLinhaArquivo);

                Enum.TryParse(arrLinhaArquivo[0], out TipoDeDado tipoDeDado);

                switch (tipoDeDado)
                {
                    case TipoDeDado.Vendedor:
                        _relatorioVendaDTO.Vendedores.Add(new Vendedor(arrLinhaArquivo));
                        break;

                    case TipoDeDado.Cliente:
                        _relatorioVendaDTO.Clientes.Add(new Cliente(arrLinhaArquivo));
                        break;

                    case TipoDeDado.Venda:
                        _relatorioVendaDTO.Vendas.Add(new Venda(arrLinhaArquivo));
                        break;
                    default:
                        break;
                }
            }

            return _relatorioVendaDTO;
        }

        #region Validações

        private void ValidarLinhaArquivo(string[] arrLinha)
        {
            ValidarLinhaArquivoVazia(arrLinha);

            ValidarLinhaArquivoTipoDeDado(arrLinha);
        }

        private void ValidarLinhaArquivoVazia(string[] arrLinha)
        {
            if (arrLinha.Length <= 0)
            {
                throw new Exception("Linha está vazia.");
            }
        }

        private void ValidarLinhaArquivoTipoDeDado(string[] arrLinha)
        {
            if (!Enum.TryParse(arrLinha[0], out TipoDeDado tipoDeDado))
            {
                throw new Exception($"Não foi possivel converter '{arrLinha[0]}' em int.");
            }
        }

        #endregion
    }
}
