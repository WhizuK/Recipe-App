﻿using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly string tableName = "post";
        public Post Create(Post post)
        {
            string sql = $"INSERT INTO {tableName} (id_user, id_recipe, comment, rating) " +
                        $"VALUES ({post.UserId.Id}, {post.RecipeId.Id}, '{post.Comment}', {post.Rating});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }


        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Post Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Post not found.");
        }

        public List<Post> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> post = new List<Post>();
            while (reader.Read())
            {
                post.Add(Parse(reader));
            }
            return post;

        }

        public List<Post> RetrieveAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> posts = new List<Post>();

            while (reader.Read())
            {
                posts.Add(Parse(reader));
            }

            return posts;
        }

        public Post Update(Post post)
        {
            string sql = $"UPDATE {tableName} SET" +
                $" recipe_id = {post.RecipeId.Id}, " +
                $" comment = '{post.Comment}', " +
                $" rating = {post.Rating}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(post.Id);
        }
        private Post Parse(SqlDataReader reader)
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(reader["id"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            post.UserId = user;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            post.RecipeId = recipe; 

            post.Comment = Convert.ToString(reader["comment"]);

            post.Rating = Convert.ToInt32(reader["rating"]);

            return post;
        }
    }
}
