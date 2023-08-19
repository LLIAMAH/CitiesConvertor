﻿// <auto-generated />
using Cities.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cities.DB.Migrations
{
    [DbContext(typeof(AppDbCtx))]
    [Migration("20230819184526_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cities.DB.Entities.Test", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Test1Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Test1Id")
                        .IsUnique();

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Cities.DB.Entities.Test1", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("TestData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests1");
                });

            modelBuilder.Entity("Cities.DB.Entities.Test2", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("TestData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Tests2");
                });

            modelBuilder.Entity("Cities.DB.Entities.TestMany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestsManies");
                });

            modelBuilder.Entity("TestTestMany", b =>
                {
                    b.Property<long>("TestManiesId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestsId")
                        .HasColumnType("bigint");

                    b.HasKey("TestManiesId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("TestTestMany");
                });

            modelBuilder.Entity("Cities.DB.Entities.Test", b =>
                {
                    b.HasOne("Cities.DB.Entities.Test1", "Test1")
                        .WithOne("Test")
                        .HasForeignKey("Cities.DB.Entities.Test", "Test1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test1");
                });

            modelBuilder.Entity("Cities.DB.Entities.Test2", b =>
                {
                    b.HasOne("Cities.DB.Entities.Test", "Test")
                        .WithMany("Test2s")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestTestMany", b =>
                {
                    b.HasOne("Cities.DB.Entities.TestMany", null)
                        .WithMany()
                        .HasForeignKey("TestManiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cities.DB.Entities.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cities.DB.Entities.Test", b =>
                {
                    b.Navigation("Test2s");
                });

            modelBuilder.Entity("Cities.DB.Entities.Test1", b =>
                {
                    b.Navigation("Test")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
