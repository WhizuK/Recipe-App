using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.implemetations
{
    public class RecipeIngredientService : IRecipeIgredientsService
    {
        private readonly IRecipeIngredient _repository;
        private readonly IIngredientsService _ingredientsService;
        private readonly IMeasuresService _measuresService;

        public RecipeIngredientService(IRecipeIngredient repository, IIngredientsService ingredientsService, IMeasuresService  measureService)
        {
            _repository = repository;
            _ingredientsService = ingredientsService;
            _measuresService = measureService;
        }


        public RecipeIngredients Create(RecipeIngredients recipeIngredients)
        {
            return _repository.Create(recipeIngredients);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public RecipeIngredients Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<RecipeIngredients> RetrieveAll(int recipeId)
        {
            List<RecipeIngredients> ingredient = _repository.RetrieveAll(recipeId);
            foreach (RecipeIngredients recipeingredient in ingredient)
            {
                recipeingredient.IngredientId = _ingredientsService.Retrieve(recipeingredient.IngredientId.Id);
                recipeingredient.MeasureId = _measuresService.Retrieve(recipeingredient.MeasureId.Id);
            }
            return ingredient;
        }
        public RecipeIngredients Update(RecipeIngredients recipeIngredients)
        {
            return _repository.Update(recipeIngredients);
        }
    }
}
