using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class MinhasPlantasRepositorio : IMinhasPlantasRepositorio
    {
        private readonly Contexto _dbContext;

        public MinhasPlantasRepositorio(Contexto dbCotext)
        {
            _dbContext = dbCotext;
        }

        public async Task<List<MinhasPlantasModel>> GetAll()
        {
            return await _dbContext.MinhasPlantas.ToListAsync();
        }

        public async Task<MinhasPlantasModel> GetById(int id)
        {
            return await _dbContext.MinhasPlantas.FirstOrDefaultAsync(x => x.MinhasPlantasId == id);
        }

        public async Task<MinhasPlantasModel> InsertMinhasPlantas(MinhasPlantasModel minhasplantas)
        {
            await _dbContext.MinhasPlantas.AddAsync(minhasplantas);
            await _dbContext.SaveChangesAsync();
            return minhasplantas;

        }

        public async Task<MinhasPlantasModel> UpdateMinhasPlantas(MinhasPlantasModel minhasplantas, int id)
        {
            MinhasPlantasModel minhaplanta = await GetById(id);
            if (minhasplantas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                minhasplantas.MinhasPlantasTipo = minhasplantas.MinhasPlantasTipo;
                minhasplantas.MinhasplantasDescricao = minhasplantas.MinhasplantasDescricao;
                _dbContext.MinhasPlantas.Update(minhasplantas);
                await _dbContext.SaveChangesAsync();
            }
            return minhasplantas;
        }

        public async Task<bool> DeleteMinhasPlantas(int id)
        {
            MinhasPlantasModel minhasplantas = await GetById(id);
            if (minhasplantas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.MinhasPlantas.Remove(minhasplantas);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}