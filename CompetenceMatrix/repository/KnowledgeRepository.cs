using System;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class KnowledgeRepository
    {
        public static void Save(Competence competence, Employee employee, int level = -1)
        {
            String sql = string.Format(
                "insert into knowledge(com_id, emp_id, level) values({0},{1},{2})",
                competence.Id, employee.Id, level);
            DatabaseConnection.executeNonQuery(sql);
        }
    }
}