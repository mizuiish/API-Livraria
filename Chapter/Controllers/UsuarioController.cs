using Chapter.Interfaces;
using Chapter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsuarioRepository;
        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _IUsuarioRepository = iUsuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IUsuarioRepository.Listar());
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
                Usuario usuarioEncontrado = _IUsuarioRepository.BuscarPorId(id);
                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioEncontrado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _IUsuarioRepository.CadastrarUsuario(usuario);

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
                _IUsuarioRepository.Deletar(id);
                return Ok("Usuário removido com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut("id")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _IUsuarioRepository.Atualizar(id, usuario);
                return Ok("Atualizado com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
