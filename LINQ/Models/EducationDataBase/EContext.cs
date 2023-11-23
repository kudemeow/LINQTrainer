using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LINQ.Models.EducationDataBase
{
    public partial class EContext : DbContext
    {

        public EContext()
            : base("name=EducationContext")
        {
        }
        private static EContext context = new EContext();
        public static EContext GetEContext() => context;
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Plays> Plays { get; set; }
        public virtual DbSet<Repertoire> Repertoire { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Theaters> Theaters { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(e => e.NameJanr)
                .IsUnicode(false);

            modelBuilder.Entity<Plays>()
                .Property(e => e.NameSpectacle)
                .IsUnicode(false);

            modelBuilder.Entity<Sectors>()
                .Property(e => e.NameSector)
                .IsUnicode(false);

            modelBuilder.Entity<Theaters>()
                .Property(e => e.NameTheatre)
                .IsUnicode(false);

            modelBuilder.Entity<Theaters>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Theaters>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Theaters>()
                .Property(e => e.House)
                .IsUnicode(false);
        }
    }
}
