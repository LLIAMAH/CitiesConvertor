﻿// <auto-generated />
using System;
using Cities.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cities.DB.Migrations
{
    [DbContext(typeof(AppDbCtx))]
    partial class AppDbCtxModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<long?>("Test1Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Test1Id");

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

            modelBuilder.Entity("Cities.DB.Entities.Test", b =>
                {
                    b.HasOne("Cities.DB.Entities.Test1", "Test1")
                        .WithMany()
                        .HasForeignKey("Test1Id");

                    b.Navigation("Test1");
                });
#pragma warning restore 612, 618
        }
    }
}
