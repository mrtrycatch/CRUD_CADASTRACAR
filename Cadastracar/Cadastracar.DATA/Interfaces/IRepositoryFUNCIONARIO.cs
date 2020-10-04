using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Interfaces
{
    public interface IRepositoryFUNCIONARIO : IRepositoryModel<Funcionario>
    {
        Funcionario SelecionarByCPF(String CPF);
    }
}
