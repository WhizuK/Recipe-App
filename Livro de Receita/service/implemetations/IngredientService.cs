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
    public class IngredientService : IIngredientsService
    {
        private readonly IIngredient _repository;
        public IngredientService(IIngredient _repository)
        {
            this._repository = _repository;
        }
        public Ingredient Create(Ingredient ingredient)
        {
            return _repository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _repository.Update(ingredient);
        }
    }
}
