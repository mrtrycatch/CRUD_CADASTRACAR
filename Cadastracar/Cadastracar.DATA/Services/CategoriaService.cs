using Cadastracar.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastracar.DATA.Services
{
    public class CategoriaService
    {
        public RepositoryCATEGORIA RpCategoria { get; set; }

        public CategoriaService()
        {
            RpCategoria = new RepositoryCATEGORIA();
        }
    }
}
