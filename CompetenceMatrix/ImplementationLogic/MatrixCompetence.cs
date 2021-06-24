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
        List<Employee> employees;
        DataTable DataTable { get => throw new NotImplementedException(); }
        public MatrixCompetence(Position position, Employee[] employees)
        {
            this.position = position;
            this.employees = new List<Employee>();
            this.employees.AddRange(employees);
        }
    }
}
