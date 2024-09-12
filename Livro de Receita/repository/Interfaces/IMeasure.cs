﻿using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IMeasure
    {
        Measures Create(Measures measures);
        Measures Retrieve(int id);
        List<Measures> RetrieveAll();
        Measures Update(Measures measures);
        void Delete(int id);
    }
}
