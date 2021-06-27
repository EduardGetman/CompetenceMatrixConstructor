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

        public Competence findByName(String name)
        {
            Competence result = new Competence();
            String sql = string.Format(
                "select * from competence where name = '{0}'",
                name);

            SqlConnection connection = DatabaseConnection.getInstance();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result =new Competence()
                    {Id = reader.GetInt32(0), Name = reader.GetString(1)};
            }

            reader.Close();

            return result;
        }

        public void Save(String name)
        {
            String sql = string.Format(
                "insert into competence(name) values('{0}')",
                name);
            DatabaseConnection.executeNonQuery(sql);
        }
    }
}