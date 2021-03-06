﻿using HotelApi.Data.Configuracoes;
using HotelApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        
        // Necessário para o EF Tools
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> opcoes) : base(opcoes)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=Hotel;User Id=postgres;Password=root123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguracao());
            modelBuilder.ApplyConfiguration(new HotelConfiguracao());
            modelBuilder.ApplyConfiguration(new ReservaConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new PessoaConfiguracao());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguracao());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguracao());
            modelBuilder.ApplyConfiguration(new EstadoConfiguracao());
            modelBuilder.ApplyConfiguration(new CidadeConfiguracao());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}