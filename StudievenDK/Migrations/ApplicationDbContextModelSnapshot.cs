﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudievenDK.Data;

namespace StudievenDK.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StudievenDK.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName_fk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserHelper_fk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserSeeker_fk")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CaseId");

                    b.HasIndex("CourseName_fk");

                    b.HasIndex("UserHelper_fk");

                    b.HasIndex("UserSeeker_fk");

                    b.ToTable("Cases");

                    b.HasData(
                        new
                        {
                            CaseId = 1,
                            CourseName_fk = "GUI",
                            Subject = "Hjaelp?",
                            Text = "Jeg har brug for hjaelp",
                            UserHelper_fk = "Alexander@Studieven.dk",
                            UserSeeker_fk = "Thanh@Studieven.dk"
                        },
                        new
                        {
                            CaseId = 2,
                            CourseName_fk = "DAB",
                            Subject = "EF core",
                            Text = "Jeg skal bruge hjaelp til DAB",
                            UserHelper_fk = "Thanh@Studieven.dk",
                            UserSeeker_fk = "Alexander@Studieven.dk"
                        },
                        new
                        {
                            CaseId = 3,
                            CourseName_fk = "ISU",
                            Subject = "threads",
                            Text = "hvordan opretter man en traad?",
                            UserHelper_fk = "Trang@Studieven.dk",
                            UserSeeker_fk = "Jonas@Studieven.dk"
                        },
                        new
                        {
                            CaseId = 4,
                            CourseName_fk = "GUI",
                            Subject = "user interface",
                            Text = "observer pattern - forklar lige det paa en knap",
                            UserHelper_fk = "Randi@Studieven.dk",
                            UserSeeker_fk = "Nikolaj@Studieven.dk"
                        },
                        new
                        {
                            CaseId = 5,
                            CourseName_fk = "GUI",
                            Subject = "fare paa knap",
                            Text = "hvordan laver jeg farven gul paa en knap",
                            UserHelper_fk = "Nikolaj@Studieven.dk",
                            UserSeeker_fk = "Mads@Studieven.dk"
                        });
                });

            modelBuilder.Entity("StudievenDK.Models.Course", b =>
                {
                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacultyName_fk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TermYear_fk")
                        .HasColumnType("int");

                    b.HasKey("CourseName");

                    b.HasIndex("FacultyName_fk");

                    b.HasIndex("TermYear_fk");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            CourseName = "GUI",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 4
                        },
                        new
                        {
                            CourseName = "DAB",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 4
                        },
                        new
                        {
                            CourseName = "ISU",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 3
                        },
                        new
                        {
                            CourseName = "DOA",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 3
                        },
                        new
                        {
                            CourseName = "SWT",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 3
                        },
                        new
                        {
                            CourseName = "DSB",
                            FacultyName_fk = "Technical Sciences",
                            TermYear_fk = 3
                        });
                });

            modelBuilder.Entity("StudievenDK.Models.CourseProgramme", b =>
                {
                    b.Property<string>("CourseName_fk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProgrammeName_fk")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CourseName_fk", "ProgrammeName_fk");

                    b.HasIndex("ProgrammeName_fk");

                    b.ToTable("CourseProgrammes_ST");

                    b.HasData(
                        new
                        {
                            CourseName_fk = "GUI",
                            ProgrammeName_fk = "IKT"
                        },
                        new
                        {
                            CourseName_fk = "DAB",
                            ProgrammeName_fk = "IKT"
                        },
                        new
                        {
                            CourseName_fk = "ISU",
                            ProgrammeName_fk = "IKT"
                        },
                        new
                        {
                            CourseName_fk = "DSB",
                            ProgrammeName_fk = "E"
                        },
                        new
                        {
                            CourseName_fk = "DSB",
                            ProgrammeName_fk = "IKT"
                        },
                        new
                        {
                            CourseName_fk = "SWT",
                            ProgrammeName_fk = "ST"
                        },
                        new
                        {
                            CourseName_fk = "SWT",
                            ProgrammeName_fk = "IKT"
                        });
                });

            modelBuilder.Entity("StudievenDK.Models.Faculty", b =>
                {
                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FacultyName");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            FacultyName = "Natural Sciences"
                        },
                        new
                        {
                            FacultyName = "Technical Sciences"
                        },
                        new
                        {
                            FacultyName = "Health"
                        },
                        new
                        {
                            FacultyName = "Aarhus BSS"
                        },
                        new
                        {
                            FacultyName = "Arts"
                        });
                });

            modelBuilder.Entity("StudievenDK.Models.Programme", b =>
                {
                    b.Property<string>("ProgrammeName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProgrammeName");

                    b.ToTable("Programmes");

                    b.HasData(
                        new
                        {
                            ProgrammeName = "IKT"
                        },
                        new
                        {
                            ProgrammeName = "E"
                        },
                        new
                        {
                            ProgrammeName = "ST"
                        },
                        new
                        {
                            ProgrammeName = "EE"
                        },
                        new
                        {
                            ProgrammeName = "Datalogi"
                        },
                        new
                        {
                            ProgrammeName = "Medievidenskab"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudievenDK.Models.Case", b =>
                {
                    b.HasOne("StudievenDK.Models.Course", "Course")
                        .WithMany("Cases")
                        .HasForeignKey("CourseName_fk");

                    b.HasOne("StudievenDK.Models.User", "UserHelper")
                        .WithMany("Cases")
                        .HasForeignKey("UserHelper_fk");

                    b.HasOne("StudievenDK.Models.User", "UserSeeker")
                        .WithMany("CasesSeeker")
                        .HasForeignKey("UserSeeker_fk");
                });

            modelBuilder.Entity("StudievenDK.Models.Course", b =>
                {
                    b.HasOne("StudievenDK.Models.Faculty", "Faculty")
                        .WithMany("Courses")
                        .HasForeignKey("FacultyName_fk");

                    b.HasOne("StudievenDK.Models.Term", "Term")
                        .WithMany("Courses")
                        .HasForeignKey("TermYear_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudievenDK.Models.CourseProgramme", b =>
                {
                    b.HasOne("StudievenDK.Models.Course", "Course")
                        .WithMany("CourseProgrammes")
                        .HasForeignKey("CourseName_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudievenDK.Models.Programme", "Programme")
                        .WithMany("CourseProgrammes")
                        .HasForeignKey("ProgrammeName_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
