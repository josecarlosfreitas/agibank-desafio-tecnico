using Domain.Entities;
using Domain.Entities.DTO;
using Domain.Enums;
using System;
using System.IO;

namespace AnaliseDadosVendas.Builders
{
    public class RelatorioVendaArquivoBuilder : IRelatorioVendaBuilder
    {
        RelatorioVendaDTO _relatorioVendaDTO;
        string _file;

        public RelatorioVendaArquivoBuilder(string file) 
        {
            _file = file;
            _relatorioVendaDTO = new RelatorioVendaDTO();
        }
       
        public RelatorioVendaDTO MontarDTO()
        {
            string linha;
            using (StreamReader sr = new StreamReader(_file))
            {
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] arrLinha = linha.Split('ç');

                    ValidarLinhaArquivo(arrLinha);

                    Enum.TryParse(arrLinha[0], out TipoDeDado tipoDeDado);

                    switch (tipoDeDado)
                    {
                        case TipoDeDado.Vendedor:
                            _relatorioVendaDTO.Vendedores.Add(new Vendedor(arrLinha));
                            break;

                        case TipoDeDado.Cliente:
                            _relatorioVendaDTO.Clientes.Add(new Cliente(arrLinha));
                            break;

                        case TipoDeDado.Venda:
                            _relatorioVendaDTO.Vendas.Add(new Venda(arrLinha));
                            break;
                        default:
                            break;
                    }
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
