using HotelApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApi.Data.Configuracoes
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Login).IsRequired().HasColumnType("VARCHAR(12)");
            builder.Property(u => u.Senha).IsRequired().HasColumnType("VARCHAR(10)");
            builder.Property(u => u.UsuariosGrupo).IsRequired();
            builder.Property(u => u.FuncionarioId).IsRequired();
            builder.Property(u => u.DataCadastro).IsRequired().HasColumnType("DATE").HasDefaultValueSql("NOW()");
        }
    }
}