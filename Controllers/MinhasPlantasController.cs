using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinhasPlantasController : ControllerBase
    {
        private readonly IMinhasPlantasRepositorio _minhasplantasRepositorio;

        public MinhasPlantasController(IMinhasPlantasRepositorio minhasplantasRepositorio)
        {
            _minhasplantasRepositorio = minhasplantasRepositorio;
        }

        [HttpGet("GetAllMinhasPlantas")]
        public async Task<ActionResult<List<MinhasPlantasModel>>> GetAllMinhasPlantas()
        {
            List<MinhasPlantasModel> minhasplantas = await _minhasplantasRepositorio.GetAll();
            return Ok(minhasplantas);
        }

        [HttpGet("GetMinhasPlantasId/{id}")]
        public async Task<ActionResult<MinhasPlantasModel>> GetMinhasPlantasId(int id)
        {
            MinhasPlantasModel minhasplantas = await _minhasplantasRepositorio.GetById(id);
            return Ok(minhasplantas);
        }

        [HttpPost("CreateMinhasPlantas")]
        public async Task<ActionResult<MinhasPlantasModel>> InsertMinhasPlantas([FromBody] MinhasPlantasModel minhasplantasModel)
        {
            MinhasPlantasModel minhasplantas = await _minhasplantasRepositorio.InsertMinhasPlantas(minhasplantasModel);
            return Ok(minhasplantas);
        }

    }
}
