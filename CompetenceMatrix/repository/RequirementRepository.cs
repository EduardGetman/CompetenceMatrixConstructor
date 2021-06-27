using System;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class RequirementRepository
    {
        public static void Save(Requirement requirement)
        {
            String sql = string.Format(
                "insert into requirement(pos_id, com_id, level) values(1,1,1)",
                requirement.PositionId, requirement.CompetenceId, requirement.Level);
            DatabaseConnection.executeNonQuery(sql);
        }
    }
}