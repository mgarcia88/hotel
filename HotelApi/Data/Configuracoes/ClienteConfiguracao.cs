using System.Reflection.Metadata;
using HotelApi.Dominio.Entidades;
using HotelApi.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApi.Data.Configuracoes
{
    public class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Documento).HasColumnName("Documento").HasConversion(
                Documento => Documento.ToString(),
                Documento => Cpf.Parse(Documento))
                .HasColumnType("CHAR(15)").IsRequired();
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(c => c.Email).HasColumnName("Email").HasColumnType("VARCHAR(70)").IsRequired().HasConversion(
                enderecoEmail => enderecoEmail.ToString(),
                enderecoEmail => Email.Parse(enderecoEmail)
                );
            builder.Property(c => c.DataCadastro).HasColumnType("DATE").IsRequired().HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.ClienteStatus).HasColumnType("INT").IsRequired();
        }
    }
}