using Cadastracar.DATA.Interfaces;
using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadastracar.DATA.Repositories
{
    public class RepositoryVEICULO : RepositoryBase<Veiculo>, IRepositoryVEICULO
    {
        public RepositoryVEICULO(bool SaveChages = true) : base(SaveChages)
        {
            _Contexto = new CADASTRACARContext();
        }

        public Veiculo SelecionarByFrota(String frota)
        {
            return (from p in _Contexto.Set<Veiculo>().ToList() where p.VcoFrota == frota select p).FirstOrDefault();
        }

        public Veiculo SelecionarByPlaca(String placa)
        {
            return (from p in _Contexto.Set<Veiculo>().ToList() where p.VcoPlaca == placa select p).FirstOrDefault();
        }

        public List<VwVeiculo> SelecionarTodosVw()
        {
            return _Contexto.Set<VwVeiculo>().ToList();
        }
    }
}
