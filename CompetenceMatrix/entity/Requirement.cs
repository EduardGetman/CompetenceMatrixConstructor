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
        public Position Position { get; set; }
        public Competence Competence { get; set; }

    }
}