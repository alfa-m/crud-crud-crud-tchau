﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Data;

#nullable disable

namespace TodoList.Migrations
{
    [DbContext(typeof(TarefaContext))]
    partial class TarefaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TodoList.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EstaFeita")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Todo");
                });
#pragma warning restore 612, 618
        }
    }
}
