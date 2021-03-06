﻿// <auto-generated />
using System;
using Ilithenza.App.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ilithenza.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210214231847_TestEntry")]
    partial class TestEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ilithenza.App.DataAccess.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClassId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("ClassId");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            Description = "Can manipulate Earth, water, fire, air",
                            Name = "Elementalist"
                        });
                });

            modelBuilder.Entity("Ilithenza.App.DataAccess.ClassPath", b =>
                {
                    b.Property<int>("PathId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PathId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("PathId");

                    b.ToTable("ClassPath");
                });

            modelBuilder.Entity("Ilithenza.App.DataAccess.ClassPathNode", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NodeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Ap")
                        .HasColumnType("int")
                        .HasColumnName("Ap");

                    b.Property<int?>("DependsOnId")
                        .HasColumnType("int")
                        .HasColumnName("DependsOnId");

                    b.Property<string>("DetailedDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("DetailedDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.Property<int?>("RecoveryTime")
                        .HasColumnType("int")
                        .HasColumnName("RecoveryTime");

                    b.Property<int?>("RelatedAttributeId")
                        .HasColumnType("int")
                        .HasColumnName("RelatedAttributeId");

                    b.Property<string>("Roll")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Roll");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Summary");

                    b.Property<string>("Tier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Type");

                    b.HasKey("NodeId");

                    b.ToTable("ClassPathNode");
                });
#pragma warning restore 612, 618
        }
    }
}
