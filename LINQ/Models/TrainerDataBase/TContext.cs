using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LINQ.Models.TrainerDataBase
{
    public partial class TContext : DbContext
    {
        public TContext()
            : base("name=TrainerContext")
        {
        }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercises>()
                .Property(e => e.Exercise_description)
                .IsUnicode(false);

            modelBuilder.Entity<Exercises>()
                .Property(e => e.Etal_zapros)
                .IsUnicode(false);

            modelBuilder.Entity<Exercises>()
                .Property(e => e.GroupByTable)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Name_temi)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login_user)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password_user)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.First_name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Second_name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Father_name)
                .IsUnicode(false);
        }
    }
}
