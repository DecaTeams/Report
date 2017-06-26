using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Reporte.Models;

namespace Reporte.Repository
{
    public class Context : DbContext
    {
        public Context():base("name=Report")
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Person and Gender
            modelBuilder.Entity<Person>()
                        .HasRequired(p => p.Gender)
                        .WithMany(g => g.Persons)
                        .HasForeignKey(g => g.GenderId);
                        

            // Configure Person and Employee
            modelBuilder.Entity<Employee>()
                        .HasKey(e => e.Id);
            modelBuilder.Entity<Person>()
                        // .HasRequired(p => p.Employee) makes Employee property of 
                        // Person entity as required.
                        .HasRequired(p => p.Employee)
                        // .WithRequiredPrincipal(e => e.Person) makes Person property of 
                        // Employee entity as required.
                        .WithRequiredPrincipal(e => e.Person);

            // Configure Person and Student
            modelBuilder.Entity<Student>()
                        .HasKey(s => s.Id);
            modelBuilder.Entity<Person>()
                        // .HasRequired(p => p.Student) makes Employee property of 
                        // Person entity as required.
                        .HasRequired(p => p.Student)
                        .WithRequiredPrincipal(s => s.Person);

            // Configure Employee and Manager
            modelBuilder.Entity<Manager>()
                        .HasKey(m => m.Id)
                        .Property(m => m.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employee>()
                        .HasRequired(e => e.Manager)
                        .WithRequiredPrincipal(m => m.Employee);

            // Configure Employee and Department
            modelBuilder.Entity<Employee>()
                        .HasOptional(e => e.Department)
                        .WithMany(d => d.Employees)
                        .HasForeignKey(d => d.DepartmentId);

            // Configure Manager and Department
            modelBuilder.Entity<Department>()
                        .HasKey(d => d.Id);
            
            modelBuilder.Entity<Manager>()
                        .HasRequired(m => m.Department)
                        .WithRequiredPrincipal(d => d.Manager);

        }
    }
}