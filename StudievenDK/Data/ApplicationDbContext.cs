using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Models;

namespace StudievenDK.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course>Course { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Faculty> Faculties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 1-N relation - Case/User
            modelBuilder.Entity<Case>()
                .HasOne<User>(c => c.UserHelper)
                .WithMany(user => user.Cases)
                .HasForeignKey(c => c.UserHelper_fk);
            modelBuilder.Entity<Case>()
                .HasOne<User>(c => c.UserSeeker)
                .WithMany(user => user.CasesSeeker)
                .HasForeignKey(c => c.UserSeeker_fk);

            // 1-N relation - Case/Courses
            modelBuilder.Entity<Case>()
                .HasOne<Course>(c => c.Course)
                .WithMany(course => course.Cases)
                .HasForeignKey(c => c.CourseName_fk);

            // 1-N relation - Course/Faculty
            modelBuilder.Entity<Course>()
                .HasOne<Faculty>(course => course.Faculties)
                .WithMany(f => f.Courses);

            // 1-N relation - Course/Term
            modelBuilder.Entity<Course>()
                .HasOne<Term>(course => course.Term)
                .WithMany(t => t.Courses);


            // N-N relation Course/Programme -Using shadow table
            modelBuilder.Entity<CourseProgramme>()
                .HasKey(cp => new { cp.CourseName, cp.ProgrammeName });
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.CourseProgrammes)
                .HasForeignKey(cp => cp.CourseName);
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Programme)
                .WithMany(p => p.CourseProgrammes)
                .HasForeignKey(p => p.ProgrammeName);


            //*********************DATA SEEDING***********************

            //User
            modelBuilder.Entity<User>().HasData(
                new User { Email = "Alexander@Studieven.dk", Password = "admin"},
                new User { Email = "Thanh@Studieven.dk", Password = "admin" },
                new User { Email = "Mads@Studieven.dk", Password = "admin" },
                new User { Email = "Trang@Studieven.dk", Password = "admin" },
                new User { Email = "Nikolaj@Studieven.dk", Password = "admin" },
                new User { Email = "Randi@Studieven.dk", Password = "admin" },
                new User { Email = "Jonas@Studieven.dk", Password = "admin" }
            );
            // Term
            modelBuilder.Entity<Term>().HasData(
                new Term { TermYear = 1 },
                new Term { TermYear = 2 },
                new Term { TermYear = 3 },
                new Term { TermYear = 4 },
                new Term { TermYear = 5 },
                new Term { TermYear = 6 },
                new Term { TermYear = 7 }
            );

            //Course
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseName = "GUI", TermYear = 4, Faculty = "Natural Sciences" },
                new Course { CourseName = "DAB", TermYear = 4, Faculty = "Natural Sciences" },
                new Course { CourseName = "ISU", TermYear = 3, Faculty = "Natural Sciences" },
                new Course { CourseName = "DOA", TermYear = 3, Faculty = "Natural Sciences" }
            );

            //Course
            modelBuilder.Entity<Case>().HasData(
                new Case {Text = "Jeg har brug for hjælp", Subject = "Hjælp?", UserSeeker_fk = "Thanh", UserHelper_fk = "Alexander", CourseName_fk = "GUI"}
            );

            


            modelBuilder.Entity<Faculty>().HasData(
            new Faculty { FacultyId = 1, FacultyName = "Natural Sciences"},
            new Faculty { FacultyId = 2, FacultyName = "Technical Sciences"},
            new Faculty { FacultyId = 3, FacultyName = "Health"},
            new Faculty { FacultyId = 4, FacultyName = "Aarhus BSS" },
            new Faculty { FacultyId = 5, FacultyName = "Arts" }
            );












        }
    }
}
