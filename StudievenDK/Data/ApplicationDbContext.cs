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

            // 1-N relation - Course/FacultyName
            modelBuilder.Entity<Course>()
                .HasOne<Faculty>(course => course.Faculties)
                .WithMany(f => f.Courses);

            // 1-N relation - Course/Term
            modelBuilder.Entity<Course>()
                .HasOne<Term>(course => course.Term)
                .WithMany(term => term.Courses);

            // N-N relation Course/Programme -Using shadow table
            modelBuilder.Entity<CourseProgramme>()
                .HasKey(cp => new { CourseName = cp.CourseName_fk, ProgrammeName = cp.ProgrammeName_fk });
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.CourseProgrammes)
                .HasForeignKey(cp => cp.CourseName_fk);
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Programme)
                .WithMany(p => p.CourseProgrammes)
                .HasForeignKey(p => p.ProgrammeName_fk);

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
                new Course { CourseName = "GUI", TermYear_fk = 4, FacultyName_fk = "Technical Sciences" },
                new Course { CourseName = "DAB", TermYear_fk = 4, FacultyName_fk = "Technical Sciences" },
                new Course { CourseName = "ISU", TermYear_fk = 3, FacultyName_fk = "Technical Sciences" },
                new Course { CourseName = "DOA", TermYear_fk = 3, FacultyName_fk = "Technical Sciences" },
                new Course { CourseName = "SWT", TermYear_fk = 3, FacultyName_fk = "Technical Sciences" },
                new Course { CourseName = "DSB", TermYear_fk = 3, FacultyName_fk = "Technical Sciences" }
            );

            //Programme
            modelBuilder.Entity<Programme>().HasData(
                new Programme { ProgrammeName = "IKT"},
                new Programme { ProgrammeName = "E" },
                new Programme { ProgrammeName = "ST" },
                new Programme { ProgrammeName = "EE" },
                new Programme { ProgrammeName = "Datalogi" },
                new Programme { ProgrammeName = "Medievidenskab" }
            );

            //CourseProgramme Shaddowtable
            modelBuilder.Entity<CourseProgramme>().HasData(
                new CourseProgramme { CourseName_fk = "GUI", ProgrammeName_fk = "IKT" },
                new CourseProgramme { CourseName_fk = "DAB", ProgrammeName_fk = "IKT" },
                new CourseProgramme { CourseName_fk = "ISU", ProgrammeName_fk = "IKT" },
                new CourseProgramme { CourseName_fk = "DSB", ProgrammeName_fk = "E" },
                new CourseProgramme { CourseName_fk = "DSB", ProgrammeName_fk = "IKT" },
                new CourseProgramme { CourseName_fk = "SWT", ProgrammeName_fk = "ST" },
                new CourseProgramme { CourseName_fk = "SWT", ProgrammeName_fk = "IKT" }
            );
            
            //Course
            modelBuilder.Entity<Course>().HasData(
                new Course {CourseName = "GUI", }
            );

            //Case
            modelBuilder.Entity<Case>().HasData(
                new Case {CaseId = 1, Text = "Jeg har brug for hjaelp", Subject = "Hjaelp?", UserSeeker_fk = "Thanh@Studieven.dk", UserHelper_fk = "Alexander@Studieven.dk", CourseName_fk = "GUI"},
                new Case { CaseId = 2, Text = "Jeg skal bruge hjaelp til DAB", Subject = "EF core", UserSeeker_fk = "Alexander@Studieven.dk", UserHelper_fk = "Thanh@Studieven.dk", CourseName_fk = "DAB" },
                new Case { CaseId = 3, Text = "hvordan opretter man en traad?", Subject = "threads", UserSeeker_fk = "Jonas@Studieven.dk", UserHelper_fk = "Trang@Studieven.dk", CourseName_fk = "ISU" },
                new Case { CaseId = 4, Text = "observer pattern - forklar lige det paa en knap", Subject = "user interface", UserSeeker_fk = "Nikolaj@Studieven.dk", UserHelper_fk = "Randi@Studieven.dk", CourseName_fk = "GUI" },
                new Case { CaseId = 5, Text = "hvordan laver jeg farven gul paa en knap", Subject = "fare paa knap", UserSeeker_fk = "Mads@Studieven.dk", UserHelper_fk = "Nikolaj@Studieven.dk", CourseName_fk = "GUI" }
            );

            //FacultyName
            modelBuilder.Entity<Faculty>().HasData(
            new Faculty { FacultyName = "Natural Sciences"},
            new Faculty { FacultyName = "Technical Sciences"},
            new Faculty { FacultyName = "Health"},
            new Faculty { FacultyName = "Aarhus BSS" },
            new Faculty { FacultyName = "Arts" }
            );
        }
    }
}
