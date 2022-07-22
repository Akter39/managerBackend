﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using managerBackend;

#nullable disable

namespace managerBackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "50Fl"
                        },
                        new
                        {
                            Id = 2,
                            Name = "50BK"
                        },
                        new
                        {
                            Id = 3,
                            Name = "50BR"
                        },
                        new
                        {
                            Id = 4,
                            Name = "50FR"
                        },
                        new
                        {
                            Id = 5,
                            Name = "100Fl"
                        },
                        new
                        {
                            Id = 6,
                            Name = "100BK"
                        },
                        new
                        {
                            Id = 7,
                            Name = "100BR"
                        },
                        new
                        {
                            Id = 8,
                            Name = "100FR"
                        },
                        new
                        {
                            Id = 9,
                            Name = "100IM"
                        },
                        new
                        {
                            Id = 10,
                            Name = "200Fl"
                        },
                        new
                        {
                            Id = 11,
                            Name = "200BK"
                        },
                        new
                        {
                            Id = 12,
                            Name = "200BR"
                        },
                        new
                        {
                            Id = 13,
                            Name = "200FR"
                        },
                        new
                        {
                            Id = 14,
                            Name = "200IM"
                        },
                        new
                        {
                            Id = 15,
                            Name = "400FR"
                        },
                        new
                        {
                            Id = 16,
                            Name = "400IM"
                        },
                        new
                        {
                            Id = 17,
                            Name = "800FR"
                        },
                        new
                        {
                            Id = 18,
                            Name = "1500FR"
                        },
                        new
                        {
                            Id = 19,
                            Name = "4x100FR"
                        },
                        new
                        {
                            Id = 20,
                            Name = "4x100IM"
                        },
                        new
                        {
                            Id = 21,
                            Name = "4x200FR"
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
                        });
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

            modelBuilder.Entity("managerBackend.Models.User", b =>
                {
                    b.Navigation("Competitions");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
