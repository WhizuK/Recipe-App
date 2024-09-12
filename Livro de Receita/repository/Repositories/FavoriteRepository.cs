using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Repositories
{
    public class FavoriteRepository : IFavorite
    {
        private readonly string tableName = "favorite";
        public Favorite AddFavorite(Favorite favorite)
        {
            string sql = $"INSERT INTO {tableName} (id_user, id_recipe) VALUES ({favorite.UserId.Id}, {favorite.RecipeId.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }
        public Favorite Create(Favorite favorite)
        {
            string sql = $"INSERT INTO {tableName} (id_user, id_recipe) " +
            $"VALUES ({favorite.UserId.Id}, {favorite.RecipeId.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }
        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }
        public List<Favorite> GetFavoritesByUserId(int userId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_user = {userId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favorite> favorites = new List<Favorite>();

            while (reader.Read())
            {
                favorites.Add(Parse(reader));
            }

            return favorites;
        }
        public void RemoveFavorite(int favoriteId)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {favoriteId};";
            SQL.ExecuteNonQuery(sql);
        }

        public Favorite Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Favorite not found.");
        }

        public List<Favorite> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favorite> favorite = new List<Favorite>();
            while (reader.Read())
            {
                favorite.Add(Parse(reader));
            }
            return favorite;
        }

        public Favorite Update(Favorite favorite)
        {
            string sql = $"UPDATE {tableName} SET" +
                $" recipe_id WHERE id = {favorite.RecipeId.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(favorite.Id);
        }
        private Favorite Parse(SqlDataReader reader)
        {
            Favorite favorite = new Favorite();
            favorite.Id = Convert.ToInt32(reader["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            favorite.UserId = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            favorite.RecipeId = recipe;

            return favorite;

        }
    }
}

