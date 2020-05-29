using Domain.Entities;
using Domain.Entities.DTO;
using AnaliseDadosVendas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Enums;

namespace AnaliseDadosVendas.Builders
{
    public interface IRelatorioVendaBuilder
    {
        RelatorioVendaDTO MontarDTO();
    }
}
