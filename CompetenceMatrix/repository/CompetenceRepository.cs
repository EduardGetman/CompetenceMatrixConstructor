using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class CompetenceRepository
    {
        public List<Competence> findAll()
        {
            List<Competence> result = new List<Competence>();
            String sql = "select * from competence";

            SqlConnection connection = DatabaseConnection.getInstance();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Competence()
                    {Id = reader.GetInt32(0), Name = reader.GetString(1)});
            }

            reader.Close();
            
            return result;
        }
    }
}