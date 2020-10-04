using Cadastracar.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Services
{
    public class FuncionarioService
    {
        public RepositoryFUNCIONARIO RpFuncionario { get; }
        
        public FuncionarioService()
        {
            RpFuncionario = new RepositoryFUNCIONARIO();
        }

    }
}
