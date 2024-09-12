using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.ServiceInterfaces
{
    public interface IPostService
    {
        Post Create(Post post);
        Post Retrieve(int id);
        List<Post> RetrieveAll();
        List<Post> RetrieveAllByRecipeId(int recipeId);
        Post Update(Post post);
        void Delete(int id);
    }
}
