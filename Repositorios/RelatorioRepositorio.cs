using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class RelatorioRepositorio : IRelatorioRepositorio
    {
        private readonly Contexto _dbContext;

        public RelatorioRepositorio (Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RelatorioModel>> GetAll()
        {
            return await _dbContext.Relatorio.ToListAsync();
        }

        public async Task<RelatorioModel> GetById(int id)
        {
            return await _dbContext.Relatorio.FirstOrDefaultAsync(x => x.RelatorioId == id);
        }

        public async Task<RelatorioModel> InsertUser(RelatorioModel relatorio)
        {
            await _dbContext.Relatorio.AddAsync(relatorio);
            await _dbContext.SaveChangesAsync();
            return relatorio;
        }

        public async Task<RelatorioModel> UpdateRelatorio(RelatorioModel relatorio, int id)
        {
            RelatorioModel relatorios = await GetById(id);
            if(relatorios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                relatorios.RelatorioDescricao = relatorio.RelatorioDescricao;
                _dbContext.Relatorio.Update(relatorios);
                await _dbContext.SaveChangesAsync();
            }
            return relatorios;
           
        }

        public async Task<bool> DeleteRelatorio(int id)
        {
            RelatorioModel relatorios = await GetById(id);
            if (relatorios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Relatorio.Remove(relatorios);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
