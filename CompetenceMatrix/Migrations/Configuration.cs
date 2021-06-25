
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CompetenceMatrix.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CompetenceMatrix.repository.CompetenceMatrixContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}