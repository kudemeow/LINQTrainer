namespace LINQ.Models.TrainerDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public Users()
        {
            Results = new HashSet<Results>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_user { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_user { get; set; }

        [Required]
        [StringLength(30)]
        public string Password_user { get; set; }

        public bool Level_dostup { get; set; }

        [Required]
        [StringLength(20)]
        public string First_name { get; set; }

        [Required]
        [StringLength(30)]
        public string Second_name { get; set; }

        [StringLength(30)]
        public string Father_name { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}
