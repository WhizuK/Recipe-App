using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IDifficulty
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Retrieve(int id);
        List<Difficulty> RetrieveAll();
        Difficulty Update(Difficulty difficulty);
        void Delete(int id);
    }
}
