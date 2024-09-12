using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.repository.Repositories;
using Livro_de_Receita.service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.implemetations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository _repository)
        {
            this._repository = _repository;
        }
        public Post Create(Post post)
        {
            return _repository.Create(post);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Post Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }
        public List<Post> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public List<Post> RetrieveAllByRecipeId(int recipeId)
        {
            return _repository.RetrieveAllByRecipeId(recipeId);
        }

        public Post Update(Post post)
        {
            return _repository.Update(post);
        }
    }

}
