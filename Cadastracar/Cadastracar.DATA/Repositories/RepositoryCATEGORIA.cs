using Cadastracar.DATA.Interfaces;
using Cadastracar.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Repositories
{
    public class RepositoryCATEGORIA : RepositoryBase<Categoria>, IRepositoryCATEGORIA
    {
        public RepositoryCATEGORIA(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
