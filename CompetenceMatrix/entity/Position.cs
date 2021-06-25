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
    }
}