﻿// <auto-generated />
using System;
using EF_Core_postgres2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EF_Core_postgres2.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EF_Core_postgres2.Groupp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EF_Core_postgres2.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GrouppId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GrouppId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EF_Core_postgres2.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("EF_Core_postgres2.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("EF_Core_postgres2.Student", b =>
                {
                    b.HasOne("EF_Core_postgres2.Groupp", "Groupp")
                        .WithMany()
                        .HasForeignKey("GrouppId");

                    b.Navigation("Groupp");
                });

            modelBuilder.Entity("EF_Core_postgres2.Visit", b =>
                {
                    b.HasOne("EF_Core_postgres2.Groupp", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("EF_Core_postgres2.Student", "Student")
                        .WithMany("Visit")
                        .HasForeignKey("StudentId");

                    b.HasOne("EF_Core_postgres2.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Group");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("EF_Core_postgres2.Student", b =>
                {
                    b.Navigation("Visit");
                });
#pragma warning restore 612, 618
        }
    }
}
