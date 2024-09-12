using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.modelo
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User? UserId { get; set; }
        public Category? CategoryId { get; set; }
        public List<RecipeIngredients>? RecipeIngredients { get; set; }
        public int PreparetionTime { get; set; }
        public string? PreparetionMethod { get; set; }
        public Difficulty? DifficultyId { get; set; }
        public Boolean Approved { get; set; }


    }
}
