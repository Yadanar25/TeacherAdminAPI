﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherAdminAPI.Models;

namespace TeacherAdminAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211121094631_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TeacherAdminAPI.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("TeacherAdminAPI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "studentjon@gmail.com",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "studenthon@gmail.com",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "studentmary@gmail.com",
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            Email = "studentbob@gmail.com",
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            Email = "studentagnes@gmail.com",
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            Email = "studentmiche@gmail.com",
                            Status = 0
                        });
                });

            modelBuilder.Entity("TeacherAdminAPI.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "teacherken@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Email = "teacherjoe@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            Email = "teachershaun@gmail.com"
                        });
                });

            modelBuilder.Entity("TeacherAdminAPI.Models.Registration", b =>
                {
                    b.HasOne("TeacherAdminAPI.Models.Student", "Student")
                        .WithMany("StudentRegistrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeacherAdminAPI.Models.Teacher", "Teacher")
                        .WithMany("StudentRegistrations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
