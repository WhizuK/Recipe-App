using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IIngredient
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Retrieve(int id);
        List<Ingredient> RetrieveAll();
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
