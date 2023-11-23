namespace LINQ.Models.EducationDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repertoire")]
    public partial class Repertoire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repertoire()
        {
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumberNote { get; set; }

        public int NumberTheatre { get; set; }

        public int NumberSpectacle { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateSpectacle { get; set; }

        public TimeSpan TimeSpectacle { get; set; }

        public virtual Plays Plays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }

        public virtual Theaters Theaters { get; set; }
    }
}
