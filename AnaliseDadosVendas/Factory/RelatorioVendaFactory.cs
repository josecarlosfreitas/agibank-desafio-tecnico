using AnaliseDadosVendas.Domain.Entities;
using AnaliseDadosVendas.Domain.Entities.DTO;
using AnaliseDadosVendas.Domain.Enums;
using AnaliseDadosVendas.Util;
using System;
using System.Collections.Generic;

namespace AnaliseDadosVendas.Factory
{
    public class RelatorioVendaFactory : IRelatorioVendaFactory
    {
        RelatorioVendaDTO _relatorioVendaDTO;
        char SEPARADOR_LINHA_DE_ARQUIVO = 'ç';

        public RelatorioVendaFactory()
        {
            _relatorioVendaDTO = new RelatorioVendaDTO();
        }

        public RelatorioVendaDTO MontarDTO(string file)
        {
            List<string> linhasArquivo = ArquivoUtil.ConverterArquivoEmListaDeStringLinha(file);
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
