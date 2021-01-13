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
            builder.Property(c => c.DataCadastro).HasColumnType("DATE").IsRequired().HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.PessoaId).HasColumnType("INT").IsRequired();
            builder.Property(c => c.TelefoneCelular).HasColumnType("CHAR(15)").IsRequired();
            builder.Property(c => c.HotelId).IsRequired();
            builder.Property(c => c.EnderecoId).IsRequired();
        }
    }
}