using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.ServiceInterfaces
{
    public interface IRecipeIgredientsService
    {
        RecipeIngredients Create(RecipeIngredients recipeIngredients);
        RecipeIngredients Retrieve(int id);
        List<RecipeIngredients> RetrieveAll(int recipeId);
        RecipeIngredients Update(RecipeIngredients recipeIngredients);
        void Delete(int id);
    }
}
