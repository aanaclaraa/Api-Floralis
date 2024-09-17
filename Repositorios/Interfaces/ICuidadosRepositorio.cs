using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ICuidadosRepositorio
    {
        Task<List<CuidadosModel>> GetAll();

        Task<CuidadosModel> GetById(int id);

        Task<CuidadosModel> InsertCuidados(CuidadosModel cuidados);

        Task<CuidadosModel> UpdateCuidados(CuidadosModel cuidados, int id);

        Task<bool> DeleteCuidados(int id);
    }
}
