using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadosController : ControllerBase
    {
        private readonly ICuidadosRepositorio _cuidadosRepositorio;

        public CuidadosController(ICuidadosRepositorio cuidadosRepositorio)
        {
            _cuidadosRepositorio = cuidadosRepositorio;
        }

        [HttpGet("GetAllCuidados")]
        public async Task<ActionResult<List<CuidadosModel>>> GetAllCuidados()
        {
            List<CuidadosModel> cuidados = await _cuidadosRepositorio.GetAll();
            return Ok(cuidados);
        }

        [HttpGet("GetCuidadosId/{id}")]
        public async Task<ActionResult<CuidadosModel>> GetCuidadosId(int id)
        {
            CuidadosModel cuidados = await _cuidadosRepositorio.GetById(id);
            return Ok(cuidados);
        }

        [HttpPost("CreateCuidados")]
        public async Task<ActionResult<CuidadosModel>> InsertCuidados([FromBody] CuidadosModel cuidadosModel)
        {
            CuidadosModel cuidados = await _cuidadosRepositorio.InsertCuidados(cuidadosModel);
            return Ok(cuidados);
        }

    }
}
