using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        private readonly Contexto _dbContext;

        public AnimalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AnimalModel>> GetAll()
        {
            return await _dbContext.Animal.ToListAsync();
        }

        public async Task<AnimalModel> GetById(int id)
        {
            return await _dbContext.Animal.FirstOrDefaultAsync(x => x.AnimalId == id);
        }

        public async Task<AnimalModel> InsertAnimal(AnimalModel animal)
        {
            await _dbContext.Animal.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<AnimalModel> UpdateAnimal(AnimalModel animal, int id)
        {
            AnimalModel animais = await GetById(id);
            if (animais == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                animais.NomeAnimal =  animal.NomeAnimal;
                animais.AnimalRaca = animal.AnimalRaca;
                animais.AnimalTipo = animal.AnimalTipo;
                animais.AnimalSexo = animal.AnimalSexo;
                animais.AnimalDtDesaparecimento = animal.AnimalDtDesaparecimento;
                animais.AnimalDtEncontro = animal.AnimalDtEncontro;
                animais.AnimalStatus = animal.AnimalStatus;

                _dbContext.Animal.Update(animais);
                await _dbContext.SaveChangesAsync();
            }
            return animais;

        }

        public async Task<bool> DeleteAnimal(int id)
        {
            AnimalModel animais = await GetById(id);
            if (animais == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Animal.Remove(animais);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}


