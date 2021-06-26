using CompetenceMatrix.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetenceMatrix.entity
{
    public class Knowledge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public Competence Competence { get; set; }
        [Required]
        public Employee Employee { get; set; }

        //Создаёт новый окземпляр знания и возвращает его. Добавляет новое знание в базу данных
        //Не уверен что в возвращаемом объекте будут инициализированы все поля, например id
        public static Knowledge addKnowledge(Competence competence, Employee employee )
        {
            Knowledge newKnowledge = new Knowledge() { Competence = competence, Employee = employee };
            CompetenceMatrixContext context = new CompetenceMatrixContext();
            context.Knowledges.Add(newKnowledge);
            context.SaveChanges();
            return newKnowledge;
        }
    }
}