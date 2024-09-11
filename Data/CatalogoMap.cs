using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CatalogoMap : IEntityTypeConfiguration<CatalogoModel>
    {
        public void Configure(EntityTypeBuilder<CatalogoModel> builder)
        {
            builder.HasKey(x => x.CatalogoId);
            builder.Property(x => x.CatalogoName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CatalogoTipo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CatalogoCor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CatalogoCategoria).IsRequired().HasMaxLength(255);
        }
    }
}