using Cadastracar.DATA.Interfaces;
using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadastracar.DATA.Repositories
{
    public class RepositoryFUNCIONARIO : RepositoryBase<Funcionario>, IRepositoryFUNCIONARIO
    {
        public RepositoryFUNCIONARIO(bool SaveChanges = true) : base(SaveChanges)
        {

        }

        public Funcionario SelecionarByCPF(string CPF)
        {
            return (from p in _Contexto.Set<Funcionario>().ToList() where p.Cpf == CPF select p).FirstOrDefault();
        }
    }
}
