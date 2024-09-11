using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoRepositorio _catalogoRepositorio;

        public CatalogoController(ICatalogoRepositorio catalogoRepositorio)
        {
            _catalogoRepositorio = catalogoRepositorio;
        }

        [HttpGet("GetAllCatalogo")]
        public async Task<ActionResult<List<CatalogoModel>>> GetAllCatalogo()
        {
            List<CatalogoModel> catalogos = await _catalogoRepositorio.GetAll();
            return Ok(catalogos);
        }

        [HttpGet("GetCatalogoId/{id}")]
        public async Task<ActionResult<CatalogoModel>> GetCatalogoId(int id)
        {
            CatalogoModel catalogo = await _catalogoRepositorio.GetById(id);
            return Ok(catalogo);
        }

        [HttpPost("CreateCatalogo")]
        public async Task<ActionResult<CatalogoModel>> InsertCatalogo([FromBody] CatalogoModel catalogoModel)
        {
            CatalogoModel catalogo = await _catalogoRepositorio.InsertCatalogo(catalogoModel);
            return Ok(catalogo);
        }

    }
}
