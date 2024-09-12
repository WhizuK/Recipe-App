using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        Category Update(Category category);
        void Delete(int id);

    }
}
