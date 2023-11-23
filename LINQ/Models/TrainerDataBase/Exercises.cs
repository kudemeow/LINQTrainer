namespace LINQ.Models.TrainerDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exercises
    {
        public Exercises()
        {
            Results = new HashSet<Results>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number_exercise { get; set; }

        public int Number_temi { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Exercise_description { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Etal_zapros { get; set; }
        public string TableName { get; set; }
        public string GroupByTable { get; set; }
        public virtual ICollection<Results> Results { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
