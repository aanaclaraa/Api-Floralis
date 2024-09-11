using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class RelatorioMap : IEntityTypeConfiguration<RelatorioModel>
    {
        public void Configure(EntityTypeBuilder<RelatorioModel> builder)
        {
            builder.HasKey(x => x.RelatorioId);
            builder.Property(x => x.RelatorioDescricao).IsRequired().HasMaxLength(255);
        }
    }
}