using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class MinhasPlantasMap : IEntityTypeConfiguration<MinhasPlantasModel>
    {
        public void Configure(EntityTypeBuilder<MinhasPlantasModel> builder)
        {
            builder.HasKey(x => x.MinhasPlantasId);
            builder.Property(x => x.MinhasPlantasTipo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MinhasplantasDescricao).IsRequired().HasMaxLength(255);
        }
    }
}