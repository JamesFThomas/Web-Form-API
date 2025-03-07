using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Form_API.Models;

namespace Web_Form_API.Data
{
    public class FormDBContext : DbContext
    {

        // class constructor will push options to base class it was extended from
        public FormDBContext(DbContextOptions<FormDBContext> options) : base(options)
        { 
                    
        }

        // create a db table for form data submission
        public DbSet<FormBase> Forms { get; set; }

        // method to seed db tables with mock data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // override autoincrementing id column for seed data
            modelBuilder.Entity<FormBase>()
                .Property(f => f.Id)
                .ValueGeneratedNever(); // will not auto increment id column


            modelBuilder.Entity<FormBase>().HasData(
                // seed data
                new FormBase { Id = 1, FirstName = "Johhny", LastName = "Fives", Message = "This is test data", Completed = false },
                new FormBase { Id = 2, FirstName = "Emily", LastName = "Smith", Message = "Sample message for testing", Completed = false },
                new FormBase { Id = 3, FirstName = "John", LastName = "Doe", Message = "Another test entry", Completed = false },
                new FormBase { Id = 4, FirstName = "Sophia", LastName = "Brown", Message = "Testing data input format", Completed = false },
                new FormBase { Id = 5, FirstName = "Liam", LastName = "Johnson", Message = "Example of a form submission", Completed = false },
                new FormBase { Id = 6, FirstName = "Olivia", LastName = "Miller", Message = "Checking the message field", Completed = false },
                new FormBase { Id = 7, FirstName = "Noah", LastName = "Davis", Message = "Ensuring proper formatting", Completed = false },
                new FormBase { Id = 8, FirstName = "Ava", LastName = "Wilson", Message = "Test message for system validation", Completed = false },
                new FormBase { Id = 9, FirstName = "James", LastName = "Anderson", Message = "FormBase test entry number 9", Completed = false },
                new FormBase { Id = 10, FirstName = "Emma", LastName = "Taylor", Message = "Final test data input", Completed = false },
                new FormBase { Id = 22, FirstName = "Remove", LastName = "Me", Message = "Test the delete endpoint", Completed = false }
               );

        }

    }
}
