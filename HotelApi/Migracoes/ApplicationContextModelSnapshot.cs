﻿// <auto-generated />
using System;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelApi.Migracoes
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClienteStatus")
                        .HasColumnType("INT");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(70)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("Classificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLINT")
                        .HasDefaultValue((short)1);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("ValorDuranteSemana")
                        .HasColumnType("NUMERIC(10,2)");

                    b.Property<decimal>("ValorFinalDeSemana")
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("ReservaStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("NUMERIC(10,2)");

                    b.Property<decimal>("ValorDiaria")
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HotelId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Reserva", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelApi.Dominio.Entidades.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
