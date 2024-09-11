using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class CatalogoRepositorio : ICatalogoRepositorio
    {
        private readonly Contexto _dbContext;

        public CatalogoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CatalogoModel>> GetAll()
        {
            return await _dbContext.Catalogo.ToListAsync();
        }

        public async Task<CatalogoModel> GetById(int id)
        {
            return await _dbContext.Catalogo.FirstOrDefaultAsync(x => x.CatalogoId == id);
        }

        public async Task<CatalogoModel> InsertCatalogo(CatalogoModel catalogo)
        {
            await _dbContext.Catalogo.AddAsync(catalogo);
            await _dbContext.SaveChangesAsync();
            return catalogo;
        }

        public async Task<CatalogoModel> UpdateCatalogo(CatalogoModel catalogo, int id)
        {
            CatalogoModel catalogos = await GetById(id);
            if (catalogo == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                catalogo.CatalogoName =  catalogo.CatalogoName;
                catalogo.CatalogoTipo = catalogo.CatalogoTipo;
                catalogo.CatalogoCor = catalogo.CatalogoCor;
                _dbContext.Catalogo.Update(catalogo);
                await _dbContext.SaveChangesAsync();
            }
            return catalogo;

        }

        public async Task<bool> DeleteCatalogo(int id)
        {
            CatalogoModel catalogos = await GetById(id);
            if (catalogos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Catalogo.Remove(catalogos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}


