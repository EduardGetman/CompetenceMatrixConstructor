using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CompetenceMatrix.repository;

namespace CompetenceMatrix.entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required] public String FullName { get; set; }

        // Я так понял здесь что-то наебнулось так как знаний должнобыть много.
        // Сообщи как закончишь я доделаю метод GetKnowledgeByCompetenceId
        public Knowledge Knowledge { get; set; }
        public Position Position { get; set; }

        //Возвращает true, если Position не null TODO: Реализовать свойство get
        //Реализовано
        public bool HoldPosition()
        {
            if (Position != null)
                return true;
            return false;
        }

        //TODO: Когда появиться сылка на должность реализовать.
        //Если должность назначена вернуть название, если отсутсвует вернуть "Должность отсутствует"
        //Реализовано
        public string PositionName()
        {
            if (Position == null)
                return "Должность отсутствует";
            else
                return Position.Name;
        }

        // Проверяет соотвуетсвует ли сотрудник требованию
        public bool MeetRequirement(Requirement requirement)
        {
            Knowledge RequiredKnowledge = GetKnowledgeByCompetenceId(requirement.Competence.Id);
            return RequiredKnowledge.Level >= requirement.Level;
        }

        private Knowledge GetKnowledgeByCompetenceId(int CompetenceId)
        {
            CompetenceMatrixContext context = new CompetenceMatrixContext();
            return context.Knowledges.Where(k => k.Competence.Id == CompetenceId).FirstOrDefault();
        }

        //Создаёт новый окземпляр сотрудника и возвращает его. Добавляет нового сотрудника в базу данных
        //Не уверен что в возвращаемом объекте будут инициализированы все поля, например id
        public static Employee addEmployee(string name)
        {
            Employee newEmployee = new Employee() { FullName = name };
            CompetenceMatrixContext context = new CompetenceMatrixContext();
            context.Employees.Add(newEmployee);
            context.SaveChanges();
            return newEmployee;
        }
    }
}