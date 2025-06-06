﻿// <auto-generated />

#nullable disable

namespace AcademicRecordsApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    [DbContext(typeof(AcademicRecordsDbContext))]
    [Migration("20250306142833_AddStudentCoursesEntity")]
    partial class AddStudentCoursesEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Exams__3214EC07D6B51828");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(3, 2)");

                    b.HasKey("Id")
                        .HasName("PK__Grades__3214EC0799BA6AB4");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Students__3214EC0707A09C7C");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.StudentCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Grade", b =>
                {
                    b.HasOne("AcademicRecordsApp.Data.Models.Exam", "Exam")
                        .WithMany("Grades")
                        .HasForeignKey("ExamId")
                        .IsRequired()
                        .HasConstraintName("FK_Grades_Exams");

                    b.HasOne("AcademicRecordsApp.Data.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Grades_Students");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.StudentCourse", b =>
                {
                    b.HasOne("AcademicRecordsApp.Data.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AcademicRecordsApp.Data.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Course", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Exam", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("AcademicRecordsApp.Data.Models.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
