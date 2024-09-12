using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.ServiceInterfaces
{
    public interface IFavoriteService
    {
        Favorite Create(Favorite favorite);
        Favorite Retrieve(int id);
        Favorite AddFavorite(int userId, int recipeId);
        List<Favorite> GetFavoritesByUserId(int userId);
        void RemoveFavorite(int favoriteId);
        List<Favorite> RetrieveAll();
        Favorite Update(Favorite favorite);
        void Delete(int id);
    }
}
