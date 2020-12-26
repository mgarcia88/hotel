using HotelApi.Dominio.Entidades;
using HotelApi.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApi.Data.Configuracoes
{
    public class HotelConfiguracao : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(h => h.EnderecoId).IsRequired();
            builder.Property(h => h.Classificacao).HasColumnType("SMALLINT").HasDefaultValue(1);
            builder.Property(h => h.DataCadastro).HasColumnType("DATE").IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(h => h.ValorDuranteSemana).HasColumnType("NUMERIC(10,2)").IsRequired();
            builder.Property(h => h.ValorFinalDeSemana).HasColumnType("NUMERIC(10,2)").IsRequired();
            builder.Property(h => h.Documento).IsRequired().HasColumnName("Documento").HasConversion(
                Documento => Documento.ToString(),
                Documento => Cnpj.Parse(Documento)
            ).HasColumnType("VARCHAR(15)");
        }
    }
}