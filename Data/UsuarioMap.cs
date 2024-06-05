using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.NomeUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SenhaUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TelefoneUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EmailUsuario).IsRequired().HasMaxLength(255);
        }
    }
}