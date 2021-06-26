using CompetenceMatrix.repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetenceMatrix.entity
{
    public class Requirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Level { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public Competence Competence { get; set; }

        //Создаёт новый экземпляр требования и возвращает его. Добавляет новое требование в базу данных
        //Не уверен что в возвращаемом объекте будут инициализированы все поля, например id
        public static Requirement addRequirement(Competence competence, Position position)
        {
            Requirement newRequirement = new Requirement() { Competence = competence, Position = position };
            CompetenceMatrixContext context = new CompetenceMatrixContext();
            context.Requirements.Add(newRequirement);
            context.SaveChanges();
            return newRequirement;
        }
    }
}