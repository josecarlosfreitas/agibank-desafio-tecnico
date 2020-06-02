using AnaliseDadosVendas.Util;
using Domain.Entities;
using Domain.Entities.DTO;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace AnaliseDadosVendas.Factory
{
    public class RelatorioVendaArquivoFactory : IRelatorioVendaFactory
    {
        RelatorioVendaDTO _relatorioVendaDTO;
        string _file;
        char SEPARADOR_LINHA_DE_ARQUIVO = 'ç';

        public RelatorioVendaArquivoFactory(string file)
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
            if (!Enum.TryParse(arrLinha[0], out TipoDeDado tipoDeDado))
            {
                throw new Exception($"Não foi possivel converter '{arrLinha[0]}' em int.");
            }
        }

        #endregion
    }
}
