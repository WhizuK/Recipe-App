using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Repositories
{
    public class RecipeIngredientsRepository : IRecipeIngredient
    {
        private readonly string tableName = "recipe_ingredients";


        public RecipeIngredients Create(RecipeIngredients recipeIngredients)
        {
            string sql = $"INSERT INTO {tableName} (id_recipe, id_ingredients, quantity, id_measure) VALUES " +
                         $"({recipeIngredients.RecipeId.Id}, {recipeIngredients.IngredientId.Id}, {recipeIngredients.Quantity}, {recipeIngredients.MeasureId.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public RecipeIngredients Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Ingredient not found.");
        }

        public List<RecipeIngredients> RetrieveAll(int recipeId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
            while (reader.Read())
            {
                recipeIngredients.Add(Parse(reader));
            }
            return recipeIngredients;
        }

        public RecipeIngredients Update(RecipeIngredients recipeIngredients)
        {
            string sql = $"UPDATE {tableName} SET " +
                         $"id_ingredients = {recipeIngredients.IngredientId.Id}, " +
                         $"quantity = {recipeIngredients.Quantity}, " +
                         $"id_measure = {recipeIngredients.MeasureId.Id} " +
                         $"WHERE id = {recipeIngredients.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(recipeIngredients.Id);
        }

        private RecipeIngredients Parse(SqlDataReader reader)
        {
            RecipeIngredients RecipeIngredients = new RecipeIngredients();

            RecipeIngredients.Id = Convert.ToInt32(reader["id"]);

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            RecipeIngredients.RecipeId = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredients"]);
            RecipeIngredients.IngredientId = ingredient;

            RecipeIngredients.Quantity = Convert.ToDouble(reader["quantity"]);

            Measures measure = new Measures();
            measure.Id = Convert.ToInt32(reader["id_measure"]);
            RecipeIngredients.MeasureId = measure;

            return RecipeIngredients;
        }

    }
}
