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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseProgramme>()
                .HasKey(cp => new {cp.CourseName, cp.ProgrammeName});
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.CourseProgrammes)
                .HasForeignKey(cp => cp.CourseName);
            modelBuilder.Entity<CourseProgramme>()
                .HasOne(cp => cp.Programme)
                .WithMany(c => c.CourseProgrammes)
                .HasForeignKey(p => p.ProgrammeName);
        }
    }
}
