namespace LINQ.Models.TrainerDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public Topic()
        {
            Exercises = new HashSet<Exercises>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number_temi { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_temi { get; set; }
        public virtual ICollection<Exercises> Exercises { get; set; }
        public string TopicName
        {
            get
            {
                return $"{Name_temi}";
            }
        }
    }
}
