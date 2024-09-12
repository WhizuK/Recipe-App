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
    public class MeasureRepository : IMeasure
    {
        private readonly string tableName = "measures";
        public Measures Create(Measures measures)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{measures.Name}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Measures Retrieve(int id)
        {
            string sql =$"SELECT * FROM {tableName} WHERE id = {id}";
            SqlDataReader reader = SQL.Execute(sql);
            if(reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Measure not found");
        }

        public List<Measures> RetrieveAll()
        {
            string sql = $"SELECT *FROM {tableName} ORDER BY id ASC;";
            SqlDataReader reader1 = SQL.Execute(sql);
            List<Measures>measures= new List<Measures>();
            while(reader1.Read())
            {
                measures.Add(Parse(reader1));
            }
            return measures;
        }

        public Measures Update(Measures measures)
        {
            string sql = $"UPDATE {tableName} SET name ='{measures.Name}' WHERE id = {measures.Id}" ;
            SQL.ExecuteNonQuery(sql);
            return Retrieve(measures.Id);
        }
        private Measures Parse(SqlDataReader reader)
        {
            Measures measures = new Measures();
            measures.Id = Convert.ToInt32(reader["id"]);
            measures.Name = Convert.ToString(reader["name"]);
            return measures;
        }
    }
}
