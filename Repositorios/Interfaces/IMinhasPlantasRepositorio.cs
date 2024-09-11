using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IMinhasPlantasRepositorio
    {
        Task<List<MinhasPlantasModel>> GetAll();
        Task<MinhasPlantasModel> GetById(int id);
        Task<MinhasPlantasModel> InsertMinhasPlantas(MinhasPlantasModel minhasplantas);
        Task<MinhasPlantasModel> UpdateMinhasPlantas(MinhasPlantasModel minhasplantas, int id);
        Task<bool> DeleteMinhasPlantas(int id);


    }
}
