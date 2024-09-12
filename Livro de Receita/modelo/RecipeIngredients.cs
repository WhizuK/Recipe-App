using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.modelo
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public  Recipe RecipeId { get; set; }
        public Ingredient IngredientId { get; set;}
        public double Quantity { get; set; }
        public Measures MeasureId { get; set; }
    }
}
