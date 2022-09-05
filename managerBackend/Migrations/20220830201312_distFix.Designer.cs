﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using managerBackend;

#nullable disable

namespace managerBackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220830201312_distFix")]
    partial class distFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompetitionDistance", b =>
                {
                    b.Property<int>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("DistancesId")
                        .HasColumnType("int");

                    b.HasKey("CompetitionsId", "DistancesId");

                    b.HasIndex("DistancesId");

                    b.ToTable("CompetitionDistance");
                });

            modelBuilder.Entity("managerBackend.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Contribution")
                        .HasColumnType("int");

                    b.Property<int>("CurrentComands")
                        .HasColumnType("int");

                    b.Property<int>("CurrentMembers")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndCompetition")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Individual")
                        .HasColumnType("bit");

                    b.Property<bool>("InvitOnly")
                        .HasColumnType("bit");

                    b.Property<int>("MaxComandMembers")
                        .HasColumnType("int");

                    b.Property<int>("MaxComands")
                        .HasColumnType("int");

                    b.Property<int>("MaxMembers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PoolLanes")
                        .HasColumnType("int");

                    b.Property<int>("PoolLength")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartCompetition")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("managerBackend.Models.Distance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dist = "50",
                            Gender = "mail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 2,
                            Dist = "50",
                            Gender = "femail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 3,
                            Dist = "50",
                            Gender = "mail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 4,
                            Dist = "50",
                            Gender = "femail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 5,
                            Dist = "50",
                            Gender = "mail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 6,
                            Dist = "50",
                            Gender = "femail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 7,
                            Dist = "50",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 8,
                            Dist = "50",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 9,
                            Dist = "100",
                            Gender = "mail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 10,
                            Dist = "100",
                            Gender = "femail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 11,
                            Dist = "100",
                            Gender = "mail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 12,
                            Dist = "100",
                            Gender = "femail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 13,
                            Dist = "100",
                            Gender = "mail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 14,
                            Dist = "100",
                            Gender = "femail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 15,
                            Dist = "100",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 16,
                            Dist = "100",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 17,
                            Dist = "100",
                            Gender = "mail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 18,
                            Dist = "100",
                            Gender = "femail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 19,
                            Dist = "200",
                            Gender = "mail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 20,
                            Dist = "200",
                            Gender = "femail",
                            Style = "Fl"
                        },
                        new
                        {
                            Id = 21,
                            Dist = "200",
                            Gender = "mail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 22,
                            Dist = "200",
                            Gender = "femail",
                            Style = "BK"
                        },
                        new
                        {
                            Id = 23,
                            Dist = "200",
                            Gender = "mail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 24,
                            Dist = "200",
                            Gender = "femail",
                            Style = "BR"
                        },
                        new
                        {
                            Id = 25,
                            Dist = "200",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 26,
                            Dist = "200",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 27,
                            Dist = "200",
                            Gender = "mail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 28,
                            Dist = "200",
                            Gender = "femail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 29,
                            Dist = "400",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 30,
                            Dist = "400",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 31,
                            Dist = "400",
                            Gender = "mail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 32,
                            Dist = "400",
                            Gender = "femail",
                            Style = "IM"
                        },
                        new
                        {
                            Id = 33,
                            Dist = "800",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 34,
                            Dist = "800",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 35,
                            Dist = "1500",
                            Gender = "mail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 36,
                            Dist = "1500",
                            Gender = "femail",
                            Style = "FR"
                        },
                        new
                        {
                            Id = 37,
                            Dist = "4x100",
                            Gender = "mail",
                            Style = "RLFR"
                        },
                        new
                        {
                            Id = 38,
                            Dist = "4x100",
                            Gender = "femail",
                            Style = "RLFR"
                        },
                        new
                        {
                            Id = 39,
                            Dist = "4x100",
                            Gender = "mail",
                            Style = "RLIM"
                        },
                        new
                        {
                            Id = 40,
                            Dist = "4x100",
                            Gender = "femail",
                            Style = "RLIM"
                        },
                        new
                        {
                            Id = 41,
                            Dist = "4x200",
                            Gender = "mail",
                            Style = "RLFR"
                        },
                        new
                        {
                            Id = 42,
                            Dist = "4x200",
                            Gender = "femail",
                            Style = "RLFR"
                        });
                });

            modelBuilder.Entity("managerBackend.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("managerBackend.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MainAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        },
                        new
                        {
                            Id = 4,
                            Name = "VipUser"
                        });
                });

            modelBuilder.Entity("managerBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1000L, 1);

                    b.Property<string>("UserCity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("UserNickname")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("UserOrganization")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserCity = "Moscow",
                            UserEmail = "akt@mm.com",
                            UserName = "mainadmin",
                            UserNickname = "MainAdmin",
                            UserOrganization = "Administrations",
                            UserPassword = "mainadmin",
                            UserPhone = "89111111111"
                        },
                        new
                        {
                            Id = 1000,
                            UserCity = "Moscow",
                            UserEmail = "foo@foo.com",
                            UserName = "Admin1000",
                            UserNickname = "Admin1000",
                            UserOrganization = "Administrations",
                            UserPassword = "admin1000",
                            UserPhone = "89111111145"
                        });
                });

            modelBuilder.Entity("managerBackend.Models.YearGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Infinity")
                        .HasColumnType("bit");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("yearGroups");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");

                    b.HasData(
                        new
                        {
                            RolesId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            RolesId = 2,
                            UsersId = 1000
                        });
                });

            modelBuilder.Entity("CompetitionDistance", b =>
                {
                    b.HasOne("managerBackend.Models.Competition", null)
                        .WithMany()
                        .HasForeignKey("CompetitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("managerBackend.Models.Distance", null)
                        .WithMany()
                        .HasForeignKey("DistancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("managerBackend.Models.Competition", b =>
                {
                    b.HasOne("managerBackend.Models.User", "User")
                        .WithMany("Competitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("managerBackend.Models.RefreshToken", b =>
                {
                    b.HasOne("managerBackend.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("managerBackend.Models.YearGroup", b =>
                {
                    b.HasOne("managerBackend.Models.Competition", null)
                        .WithMany("YearGroups")
                        .HasForeignKey("CompetitionId");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("managerBackend.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("managerBackend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("managerBackend.Models.Competition", b =>
                {
                    b.Navigation("YearGroups");
                });

            modelBuilder.Entity("managerBackend.Models.User", b =>
                {
                    b.Navigation("Competitions");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}