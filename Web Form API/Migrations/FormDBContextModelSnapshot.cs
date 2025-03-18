﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Form_API.Data;

namespace Web_Form_API.Migrations
{
    [DbContext(typeof(FormDBContext))]
    partial class FormDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_Form_API.Classes.UserBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "password123",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "password456",
                            Username = "emilysmith"
                        },
                        new
                        {
                            Id = 3,
                            Email = "password789",
                            Username = "liamjohnson"
                        });
                });

            modelBuilder.Entity("Web_Form_API.Models.FormBase", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Forms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = false,
                            FirstName = "Johhny",
                            LastName = "Fives",
                            Message = "This is test data"
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            FirstName = "Emily",
                            LastName = "Smith",
                            Message = "Sample message for testing"
                        },
                        new
                        {
                            Id = 3,
                            Completed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            Message = "Another test entry"
                        },
                        new
                        {
                            Id = 4,
                            Completed = false,
                            FirstName = "Sophia",
                            LastName = "Brown",
                            Message = "Testing data input format"
                        },
                        new
                        {
                            Id = 5,
                            Completed = false,
                            FirstName = "Liam",
                            LastName = "Johnson",
                            Message = "Example of a form submission"
                        },
                        new
                        {
                            Id = 6,
                            Completed = false,
                            FirstName = "Olivia",
                            LastName = "Miller",
                            Message = "Checking the message field"
                        },
                        new
                        {
                            Id = 7,
                            Completed = false,
                            FirstName = "Noah",
                            LastName = "Davis",
                            Message = "Ensuring proper formatting"
                        },
                        new
                        {
                            Id = 8,
                            Completed = false,
                            FirstName = "Ava",
                            LastName = "Wilson",
                            Message = "Test message for system validation"
                        },
                        new
                        {
                            Id = 9,
                            Completed = false,
                            FirstName = "James",
                            LastName = "Anderson",
                            Message = "FormBase test entry number 9"
                        },
                        new
                        {
                            Id = 10,
                            Completed = false,
                            FirstName = "Emma",
                            LastName = "Taylor",
                            Message = "Final test data input"
                        },
                        new
                        {
                            Id = 22,
                            Completed = false,
                            FirstName = "Remove",
                            LastName = "Me",
                            Message = "Test the delete endpoint"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
