using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ObservacoesMap : IEntityTypeConfiguration<ObservacoesModel>
    {
        public void Configure(EntityTypeBuilder<ObservacoesModel> builder)
        {
            builder.HasKey(x => x.ObservacoesId);
            builder.Property(x => x.ObservacoesDescri).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoLocal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoData).IsRequired();
        }
    }
}