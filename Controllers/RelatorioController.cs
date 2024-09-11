using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepositorio _relatorioRepositorio;

        public RelatorioController(IRelatorioRepositorio relatorioRepositorio)
        {
            _relatorioRepositorio = relatorioRepositorio;
        }

        [HttpGet("GetAllRelatorio")]
        public async Task<ActionResult<List<RelatorioModel>>> GetAllRelatorio()
        {
            List<RelatorioModel> relatorios = await _relatorioRepositorio.GetAll();
            return Ok(relatorios);
        }

        [HttpGet("GetRelatorioId/{id}")]
        public async Task<ActionResult<RelatorioModel>> GetRelatorioId(int id)
        {
            RelatorioModel relatorio = await _relatorioRepositorio.GetById(id);
            return Ok(relatorio);
        }

        [HttpPost("CreateRelatorio")]
        public async Task<ActionResult<RelatorioModel>> InsertRelatorio([FromBody] RelatorioModel relatorioModel)
        {
            RelatorioModel relatorio = await _relatorioRepositorio.InsertRelatorio(relatorioModel);
            return Ok(relatorio);
        }

    }
}