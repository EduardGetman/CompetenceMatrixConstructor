using CompetenceMatrix.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetenceMatrix.entity
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public List<Requirement> Requirements { get; set; }
        public List<Employee> Employees { get; set; }

        // Возвращает true если работник подходит по требованиям
        public bool IsEmployeeSuitable(Employee employee)
        {
            foreach (var item in Requirements)
            {
                if (!employee.MeetRequirement(item))
                {
                    return false;
                }
            }
            return true;
        }
        public bool CompetenceIsIncluded(Competence competence)
        {
            foreach (var item in Requirements)
            {
                if (item.Competence.Id == competence.Id)
                {
                    return false;
                }
            }
            return true;
        }

        //Создаёт новый окземпляр должности и возвращает его. Добавляет новоую должность в базу данных
        //Не уверен что в возвращаемом объекте будут инициализированы все поля, например id
        public static Position addPosition(string name)
        {
            PostitonRepository.Save(name);
            return PostitonRepository.findByName(name);
            // Position newPosition = new Position() { Name = name};
            // CompetenceMatrixContext context = new CompetenceMatrixContext();
            // context.Positions.Add(newPosition);
            // context.SaveChanges();
            // return newPosition;
        }
        public static Position UpdatePosition(string name, Requirement[] knowledges)
        {
            throw new NotImplementedException();
        }
        public static bool DeletePosition(int id)
        {
            throw new NotImplementedException();
        }
    }
}