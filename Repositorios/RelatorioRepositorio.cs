using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class RelatorioRepositorio : IRelatorioRepositorio
    {
        private readonly Contexto _dbContext;

        public RelatorioRepositorio(Contexto dbCotext)
        {
            _dbContext = dbCotext;
        }

        public async Task<List<RelatorioModel>> GetAll()
        {
            return await _dbContext.Relatorio.ToListAsync();
        }

        public async Task<RelatorioModel> GetById(int id)
        {
            return await _dbContext.Relatorio.FirstOrDefaultAsync(x => x.RelatorioId == id);
        }

        public async Task<RelatorioModel> InsertRelatorio(RelatorioModel relatorio)
        {
            await _dbContext.Relatorio.AddAsync(relatorio);
            await _dbContext.SaveChangesAsync();
            return relatorio;

        }

        public async Task<RelatorioModel> UpdateRelatorio(RelatorioModel relatorios, int id)
        {
            RelatorioModel relatorio = await GetById(id);
            if (relatorio == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                relatorios.RelatorioDescricao = relatorios.RelatorioDescricao;
                _dbContext.Relatorio.Update(relatorios);
                await _dbContext.SaveChangesAsync();
            }
            return relatorios;
        }

        public async Task<bool> DeleteRelatorio(int id)
        {
            RelatorioModel relatorio = await GetById(id);
            if (relatorio == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Relatorio.Remove(relatorio);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
