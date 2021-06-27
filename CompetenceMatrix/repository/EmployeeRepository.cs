using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class EmployeeRepository
    {
        public List<Employee> findAll()
        {
            List<Employee> employees = new List<Employee>();
            String sql = "select * from employee";

            SqlConnection connection = DatabaseConnection.getInstance();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee()
                {
                    Id = reader.GetInt32(0),
                    PositionId = reader.GetInt32(1),
                    FullName = reader.GetString(2)
                });
            }

            reader.Close();

            return employees;
        }

        public void deleteById(int id)
        {
            String sql = string.Format(
                "delete from employee where id = {0}",
                id);
            DatabaseConnection.executeNonQuery(sql);
        }

        public void delete(Employee employee)
        {
            String sql = string.Format(
                "delete from employee where id = {0} and pos_id = {1}",
                employee.Id, employee.PositionId);
            DatabaseConnection.executeNonQuery(sql);
        }


        public static Employee findByName(String name)
        {
            Employee result = new Employee();
            String sql = string.Format(
                "select * from employee where name = '{0}'",
                name);

            SqlConnection connection = DatabaseConnection.getInstance();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result = new Employee()
                {
                    Id = reader.GetInt32(0),
                    PositionId = reader.GetInt32(1),
                    FullName = reader.GetString(2)
                };
            }

            reader.Close();

            return result;
        }

        public static void Save(String name)
        {
            String sql = string.Format(
                "insert into employee(id, pos_id, fullname) values(1,null,'{0}')",
                name);
            DatabaseConnection.executeNonQuery(sql);
        }
    }
}