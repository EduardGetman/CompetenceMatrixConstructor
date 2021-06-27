using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class PostitonRepository
    {
        public List<Position> findAll()
        {
            List<Position> result = new List<Position>();
            String sql = "select * from position";
            
            SqlConnection connection = DatabaseConnection.getInstance();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Position()
                    {Id = reader.GetInt32(0), Name = reader.GetString(1)});
            }

            reader.Close();
            
            return result;
        }
    }
}