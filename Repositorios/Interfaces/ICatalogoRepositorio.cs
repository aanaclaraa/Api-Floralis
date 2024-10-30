using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ICatalogoRepositorio
    {
        Task<List<CatalogoModel>> GetAll();

        Task<CatalogoModel> GetById(int id);

        Task<CatalogoModel> InsertCatalogo(CatalogoModel catalogo);

        Task<CatalogoModel> UpdateCatalogo(CatalogoModel catalogo, int id);

        Task<bool> DeleteCatalogo(int id);
    }
}
