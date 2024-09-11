using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsersModel> User { get; set; }
        public DbSet<CatalogoModel> Catalogo { get; set; }
        public DbSet<CuidadosModel> Cuidados { get; set; }
        public DbSet<MinhasPlantasModel> MinhasPlantas { get; set; }
        public DbSet<RelatorioModel> Relatorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new CatalogoMap());
            modelBuilder.ApplyConfiguration(new CuidadosMap());
            modelBuilder.ApplyConfiguration(new MinhasPlantasMap());
            modelBuilder.ApplyConfiguration(new RelatorioMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
