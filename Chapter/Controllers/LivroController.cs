using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Produces("application/json")] //ira devolver o arquivo no formato json
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_livroRepository.buscarPorId(id));
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }
        [Authorize(Roles = "1")]
        [HttpPost]
       public IActionResult Cadastrar(Livro L)
        {
            try
            {
                _livroRepository.Cadastrar(L);

                return StatusCode(201);
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("O livro foi removido com sucesso.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livro L)
        {
            try
            {
                _livroRepository.Alterar(id, L);
                return StatusCode(204);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
