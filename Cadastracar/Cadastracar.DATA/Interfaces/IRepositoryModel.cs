using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {
        List<T> SelecionarTodos();
        T SelecionarPk(params object[] variavel);
        T Incluir(T objeto);
        T Alterar(T objeto);
        void Excluir(T objeto);
        void Excluir(params object[] variavel);
        void SaveChanges();

    }
}
