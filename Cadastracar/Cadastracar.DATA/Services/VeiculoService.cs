using Cadastracar.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Services
{
    public class VeiculoService
    {
        public RepositoryVEICULO RpVeiculo { get; set; }
        public RepositoryCATEGORIA RpCategoria { get; set; }
        public RepositoryFUNCIONARIO RpFuncionario { get; set; }

        public VeiculoService()
        {
            RpVeiculo = new RepositoryVEICULO();
            RpCategoria = new RepositoryCATEGORIA();
            RpFuncionario = new RepositoryFUNCIONARIO();
        }
    }
}
