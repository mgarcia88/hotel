using HotelApi.Data.Configuracoes;
using HotelApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        
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

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}