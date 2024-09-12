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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavorite _repository;
        public FavoriteService(IFavorite _repository)
        {
           this._repository = _repository;
        }

        public Favorite Create(Favorite favorite)
        {
            return _repository.Create(favorite);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Favorite Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Favorite> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Favorite Update(Favorite favorite)
        {
            return _repository.Update(favorite);
        }

        public Favorite AddFavorite(int userId, int recipeId)
        {


            Favorite favorite = new Favorite
            {
                UserId = new User { Id = userId },  
                RecipeId = new Recipe { Id = recipeId } 
            };
            return _repository.AddFavorite(favorite);
        }


        public List<Favorite> GetFavoritesByUserId(int userId)
        {
            return _repository.GetFavoritesByUserId(userId);
        }

        public void RemoveFavorite(int favoriteId)
        {
            _repository.RemoveFavorite(favoriteId);
        }
    }
}
