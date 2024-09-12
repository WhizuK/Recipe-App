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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository  _repository)
        {
            this._repository = _repository;
        }

        public Category Create(Category category)
        {
            return _repository.Create(category);
            
        }

        public void Delete(int id)
        {
             _repository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
    }
}
