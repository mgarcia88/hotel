using HotelApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApi.Data.Configuracoes
{
    public class ReservaConfiguracao : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reservas");
            builder.HasKey(r => r.Id);
            builder.Property(c => c.ClienteId).IsRequired();
            builder.Property(r => r.HotelId).IsRequired();
            builder.Property(r => r.DataEntrada).HasColumnType("DATE").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(r => r.DataSaida);
            builder.Property(r => r.ReservaStatus).HasConversion<string>().IsRequired();
            builder.Property(r => r.ValorDiaria).HasColumnType("NUMERIC(10,2)");
            builder.Property(r => r.ValorDesconto).HasColumnType("NUMERIC(10,2)");
        }
    }
}