using CompetenceMatrix.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetenceMatrix.entity
{
    public class Competence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Requirement> Requirements { get; set; }
        public List<Knowledge> Knowledges { get; set; }

        //Создаёт новый окземпляр компетенции и возвращает его. Добавляет новую компетенцию в базу данных
        //Не уверен что в возвращаемом объекте будут инициализированы все поля, например id
        public static Competence addCompetence(string name)
        {
            Competence newCompetence = new Competence() { Name = name };
            CompetenceMatrixContext context = new CompetenceMatrixContext();
            context.Competences.Add(newCompetence);
            context.SaveChanges();
            return newCompetence;
        }
    }
}