﻿// <auto-generated />
using System;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelApi.migracoes
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210103183112_AdicionandoCampoIBGE")]
    partial class AdicionandoCampoIBGE
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("EstadoId")
                        .HasColumnType("integer");

                    b.Property<string>("IBGE")
                        .HasColumnType("CHAR(5)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("PessoaId")
                        .HasColumnType("INT");

                    b.Property<string>("TelefoneCelular")
                        .IsRequired()
                        .HasColumnType("CHAR(15)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<int>("CidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Complemento")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataAdmissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("DataDemissao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Funcionarios");
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

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("Documento")
                        .HasColumnType("VARCHAR(15)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("TelefonePrincipal")
                        .HasColumnType("text");

                    b.Property<string>("TelefoneSecundario")
                        .HasColumnType("text");

                    b.Property<decimal>("ValorDuranteSemana")
                        .HasColumnType("NUMERIC(10,2)");

                    b.Property<decimal>("ValorFinalDeSemana")
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("Documento")
                        .HasColumnType("CHAR(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("VARCHAR(70)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
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

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("VARCHAR(12)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("UsuariosGrupo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Cidade", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("HotelApi.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Funcionario", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelApi.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Hotel", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("HotelApi.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("HotelApi.Dominio.Entidades.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
