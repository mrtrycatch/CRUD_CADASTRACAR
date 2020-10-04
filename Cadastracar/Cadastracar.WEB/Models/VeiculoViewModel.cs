using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastracar.WEB.Models
{
    
    public class VeiculoViewModel
    {
        public Veiculo oVeiculo { get; set; }
        public Categoria oCategoria { get; set; }
        public Funcionario oFuncionario { get; set; }
    }
}
