﻿// <auto-generated />
using System;
using AppChamados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppChamados.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180914233012_UpdateSolicitante")]
    partial class UpdateSolicitante
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AppChamados.Models.Chamados", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("data");

                    b.Property<DateTime>("dataSolucao");

                    b.Property<DateTime>("horaFim");

                    b.Property<DateTime>("horaInicio");

                    b.Property<string>("numero");

                    b.Property<string>("problema");

                    b.Property<int?>("solicitanteid");

                    b.HasKey("id");

                    b.HasIndex("solicitanteid");

                    b.ToTable("Chamado");
                });

            modelBuilder.Entity("AppChamados.Models.Solicitante", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("nome");

                    b.Property<string>("telefone");

                    b.HasKey("id");

                    b.ToTable("Solicitante");
                });

            modelBuilder.Entity("AppChamados.Models.Chamados", b =>
                {
                    b.HasOne("AppChamados.Models.Solicitante", "solicitante")
                        .WithMany()
                        .HasForeignKey("solicitanteid");
                });
#pragma warning restore 612, 618
        }
    }
}