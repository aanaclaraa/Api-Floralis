using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class CuidadosRepositorio : ICuidadosRepositorio
    {
        private readonly Contexto _dbContext;

        public CuidadosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CuidadosModel>> GetAll()
        {
            return await _dbContext.Cuidados.ToListAsync();
        }

        public async Task<CuidadosModel> GetById(int id)
        {
            return await _dbContext.Cuidados.FirstOrDefaultAsync(x => x.CuidadosId == id);
        }

        public async Task<CuidadosModel> InsertCuidados(CuidadosModel cuidados)
        {
            await _dbContext.Cuidados.AddAsync(cuidados);
            await _dbContext.SaveChangesAsync();
            return cuidados;
        }

        public async Task<CuidadosModel> UpdateCuidados(CuidadosModel cuidados, int id)
        {
            CuidadosModel cuidado = await GetById(id);
            if (cuidados == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                cuidados.CuidadosBriófitas = cuidado.CuidadosBriófitas;
                cuidados.CuidadosPteridófitas = cuidado.CuidadosPteridófitas;
                cuidado.CuidadosGimnospermas = cuidado.CuidadosGimnospermas;
                cuidados.CuidadosAngiospermas = cuidado.CuidadosAngiospermas;
                _dbContext.Cuidados.Update(cuidados);
                await _dbContext.SaveChangesAsync();
            }
            return cuidados;

        }

        public async Task<bool> DeleteCuidados(int id)
        {
            CuidadosModel cuidados = await GetById(id);
            if (cuidados == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cuidados.Remove(cuidados);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}