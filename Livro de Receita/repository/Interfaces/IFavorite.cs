using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IFavorite
    {
        Favorite Create(Favorite favorite);
        Favorite Retrieve(int id);
        List<Favorite> RetrieveAll();
        Favorite AddFavorite(Favorite favorite);
        void RemoveFavorite(int favoriteId);
        List<Favorite> GetFavoritesByUserId(int userId);
        Favorite Update(Favorite favorite);
        void Delete(int id);
    }
}
