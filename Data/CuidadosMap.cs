using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CuidadosMap : IEntityTypeConfiguration<CuidadosModel>
    {
        public void Configure(EntityTypeBuilder<CuidadosModel> builder)
        {
            builder.HasKey(x => x.CuidadosId);
            builder.Property(x => x.CuidadosBriófitas).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CuidadosPteridófitas).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CuidadosGimnospermas).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CuidadosAngiospermas).IsRequired().HasMaxLength(255);
        }
    }
}