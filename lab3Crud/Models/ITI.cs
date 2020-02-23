namespace lab3Crud.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ITI : DbContext
    {
        public ITI()
            : base("name=ITI")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Instructors)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Dept_Id);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Instructor)
                .HasForeignKey(e => e.Dept_Manager);
        }
    }
}
