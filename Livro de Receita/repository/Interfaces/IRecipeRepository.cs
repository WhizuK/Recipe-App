using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe Create(Recipe recipe);
        Recipe Retrieve(int id);
        List<Recipe> RetrieveAll();
        Recipe Update(Recipe recipe);
        void Delete(int id);

    }
}
