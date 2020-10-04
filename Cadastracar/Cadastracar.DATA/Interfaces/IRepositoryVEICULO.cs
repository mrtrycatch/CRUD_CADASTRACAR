using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Interfaces
{
    public interface IRepositoryVEICULO : IRepositoryModel<Veiculo>
    {
        List<VwVeiculo> SelecionarTodosVw();
        Veiculo SelecionarByPlaca(String placa);
        Veiculo SelecionarByFrota(String frota);

    }
}
