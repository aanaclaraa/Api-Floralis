using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepositorio _animalRepositorio;

        public AnimalController(IAnimalRepositorio animalRepositorio)
        {
            _animalRepositorio = animalRepositorio;
        }

        [HttpGet("GetAllAnimal")]
        public async Task<ActionResult<List<AnimalModel>>> GetAllAnimal()
        {
            List<AnimalModel> animais = await _animalRepositorio.GetAll();
            return Ok(animais);
        }

        [HttpGet("GetAnimalId/{id}")]
        public async Task<ActionResult<AnimalModel>> GetAnimalId(int id)
        {
            AnimalModel animal = await _animalRepositorio.GetById(id);
            return Ok(animal);
        }

        [HttpPost("CreateAnimal")]
        public async Task<ActionResult<AnimalModel>> InsertAnimal([FromBody] AnimalModel animalModel)
        {
            AnimalModel animal = await _animalRepositorio.InsertAnimal(animalModel);
            return Ok(animal);
        }

    }
}
