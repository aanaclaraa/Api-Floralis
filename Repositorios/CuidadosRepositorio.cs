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
            return await _dbContext.cuidados.ToListAsync();
        }

        public async Task<CuidadosModel> GetById(int id)
        {
            return await _dbContext.Cuidados.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<CuidadosModel> InsertObservacoes(CuidadosModel observacoes)
        {
            await _dbContext.Cuidados.AddAsync(observacoes);
            await _dbContext.SaveChangesAsync();
            return observacoes;
        }

        public async Task<CuidadosModel> UpdateObservacoes(CuidadosModel observacao, int id)
        {
            CuidadosModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoes.ObservacoesDescri = observacao.ObservacoesDescri;
                observacoes.ObservacaoLocal = observacao.ObservacaoLocal;
                observacoes.ObservacaoData = observacao.ObservacaoData;
                _dbContext.Cuidados.Update(observacoes);
                await _dbContext.SaveChangesAsync();
            }
            return observacoes;

        }

        public async Task<bool> DeleteObservacoes(int id)
        {
            CuidadosModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacoes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}