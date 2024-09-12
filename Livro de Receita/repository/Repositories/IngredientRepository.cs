using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Livro_de_Receita.repository.Repositories
{
    public class IngredientRepository : IIngredient
    {
        private readonly string tableName = "ingredients";
        public Ingredient Create(Ingredient ingredient)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{ingredient.IngredientName}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Ingredient Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id}";
            SqlDataReader reader = SQL.Execute(sql);
            if(reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Ingredient not found");
        }

        public List<Ingredient> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Ingredient>ingredient= new List<Ingredient>();
            while(reader.Read())
            {
                ingredient.Add(Parse(reader));
            }
            return ingredient;

        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = $"UPDATE {tableName} SET name ='{ingredient.IngredientName}' WHERE id = {ingredient.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(ingredient.Id);
        }
        private Ingredient Parse(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id= Convert.ToInt32(reader["id"]);
            ingredient.IngredientName = Convert.ToString(reader["name"]);
            return ingredient;
        }
    }
}
