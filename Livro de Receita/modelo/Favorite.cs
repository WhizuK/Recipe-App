using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.modelo
{
    public class Favorite
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Recipe RecipeId { get; set; }
    }
}
