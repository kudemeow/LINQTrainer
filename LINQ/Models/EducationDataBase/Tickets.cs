namespace LINQ.Models.EducationDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumberTicket { get; set; }

        public int NumberNote { get; set; }

        public int NumberSector { get; set; }

        public int Ryad { get; set; }

        public int Mesto { get; set; }

        public virtual Repertoire Repertoire { get; set; }

        public virtual Sectors Sectors { get; set; }
    }
}
