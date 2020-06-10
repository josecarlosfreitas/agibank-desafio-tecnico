using AnaliseDadosVendas.Domain.Entities.DTO;

namespace AnaliseDadosVendas.Factory
{
    public interface IRelatorioVendaFactory
    {
        RelatorioVendaDTO MontarDTO(string file);
    }
}
