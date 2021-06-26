using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetenceMatrix.entity;

namespace CompetenceMatrix.ImplementationLogic
{
    //TODO: Реализовать метод постраения матрицы компетенций возвращающий DataTable
    public class MatrixCompetence
    {
        Position position;
        Employee[] SuitableEmployees;
        Employee[] UnsuitableEmployees;
        Employee MostSuitableEmployees;
        Employee BestIndicators;
        Employee AverageIndicators;
        DataTable DataTable { get => throw new NotImplementedException(); }
        public MatrixCompetence(Position position, Employee[] employees)
        {
            this.position = position;
            SuitableEmployees = getSuitableEmployees(employees);

        }
        private Employee[] getSuitableEmployees(Employee[] employees)
        {
            throw new NotImplementedException();
        }
        private Employee[] getMostSuitableEmployees(Employee[] employees)
        {
            throw new NotImplementedException();
        }
        private Employee[] getUnsuitableEmployees(Employee[] employees)
        {
            throw new NotImplementedException();
        }
        private Employee[] getBestIndicators(Employee[] employees)
        {
            throw new NotImplementedException();
        }
        private Employee[] getAverageIndicators(Employee[] employees)
        {
            throw new NotImplementedException();
        }
    }
}
