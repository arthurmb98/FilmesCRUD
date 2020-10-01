﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testedotnet.Data;

namespace testedotnet.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("testedotnet.Models.Filmes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sinopse")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("testedotnet.Models.Generos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("testedotnet.Models.Filmes", b =>
                {
                    b.HasOne("testedotnet.Models.Generos", "Genero")
                        .WithMany("Filmes")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
