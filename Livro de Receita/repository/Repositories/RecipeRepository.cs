using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string tableName = "recipes";


        public Recipe Create(Recipe recipe)
        {

            int isApproved = recipe.Approved ? 1 : 0;

            string sql = $"INSERT INTO {tableName} (title, id_user, id_category, prep_time, prep_method, id_difficulty, is_approved) " +
                $"VALUES ('{recipe.Name}', {recipe.UserId.Id}, {recipe.CategoryId.Id}, {recipe.PreparetionTime}, '{recipe.PreparetionMethod}', {recipe.DifficultyId.Id}, {isApproved});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }



        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Recipe Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Recipe not found.");
        }

        public List<Recipe> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Recipe> recipes = new List<Recipe>();
            while (reader.Read())
            {
                recipes.Add(Parse(reader));
            }

            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            int isApproved = recipe.Approved ? 1 : 0;

            string sql = $"UPDATE {tableName} SET " +
                $"title = '{recipe.Name}', " +
                $"id_user = {recipe.UserId.Id}, " +
                $"id_category = {recipe.CategoryId.Id}, " +
                $"prep_time = {recipe.PreparetionTime}, " +
                $"prep_method = '{recipe.PreparetionMethod}', " +
                $"id_difficulty = {recipe.DifficultyId.Id}, " +
                $"is_approved = {isApproved} " +
                $"WHERE id = {recipe.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(recipe.Id);
        }

        private Recipe Parse(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id"]);

            recipe.Name = Convert.ToString(reader["title"]);

            User name = new User();
            name.Id = Convert.ToInt32(reader["id_user"]);
            recipe.UserId = name;

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id_category"]);
            recipe.CategoryId = category;

            recipe.PreparetionTime = Convert.ToInt32(reader["prep_time"]);
            recipe.PreparetionMethod = Convert.ToString(reader["prep_method"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id_difficulty"]);
            recipe.DifficultyId = difficulty;

            recipe.Approved = Convert.ToBoolean(reader["is_approved"]);

            return recipe;
        }
    }
}
