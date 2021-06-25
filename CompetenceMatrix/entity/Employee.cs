using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetenceMatrix.entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public String FullName { get; set; }
        // Я так понял здесь что-то наебнулось так как знаний должнобыть много.
        // Сообщи как закончишь я доделаю метод GetKnowledgeByCompetenceId
        public Knowledge Knowledge { get; set; }

        //Возвращает true, если Position не null TODO: Реализовать свойство get
        public bool HoldPosition { get => throw new NotImplementedException(); }

        //TODO: Когда появиться сылка на должность реализовать.
        //Если должность назначена вернуть название, если отсутсвует вернуть "Должность отсутствует"
        public string PositionName { get => throw new NotImplementedException(); }
        // Проверяет соотвуетсвует ли сотрудник требованию
        public bool MeetRequirement(Requirement requirement )
        {
            Knowledge RequiredKnowledge = GetKnowledgeByCompetenceId( requirement.Competence.Id);
            return RequiredKnowledge.Level >= requirement.Level;
        }
        private Knowledge GetKnowledgeByCompetenceId(int CompetenceId)
        {
            throw new NotImplementedException();
        }

    }
}