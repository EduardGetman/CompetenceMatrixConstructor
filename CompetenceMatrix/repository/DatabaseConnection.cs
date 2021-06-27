using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class DatabaseConnection
    {
        private static string connectionString =
            "Server=.\\SQLEXPRESS;Database=CompetenceMatrixDB;Trusted_Connection=True;";

        //TODO
        private static SqlConnection instance = null;

        private DatabaseConnection()
        {
            instance = new SqlConnection(connectionString);
            instance.Open();
        }

        public static SqlConnection getInstance()
        {
            if (instance == null)
                new DatabaseConnection();
            return instance;
        }
        
        public static void executeNonQuery(String sql)
        {
            using (var command = new SqlCommand(sql, instance))
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}