using System.Data.Entity;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.repository
{
    public class CompetenceMatrixContext:DbContext
    {
        public CompetenceMatrixContext()
        {
            Database.CreateIfNotExists();
        }
        
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
    }
}