using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repos.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosInterface _usuariosRepositorio;
        public UsuariosController(UsuariosInterface usuarioRepositorio)
        {
            _usuariosRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuariosModel>>> BuscarTodosUsuarios()
        {
            List<UsuariosModel> resultado = await _usuariosRepositorio.BuscarTodosUsuarios();
            return Ok(resultado);
        }
        [HttpGet("BuscarUsuarioPorId{id}")]
        public async Task<ActionResult<UsuariosModel>> BuscarUsuarioPorId(int id)
        {
            UsuariosModel resultado = await _usuariosRepositorio.BuscarUsuarioPorId(id);
            return Ok(resultado);
        }
        [HttpGet("BuscarUsuarioPorUsuario{usuario}")]
        public async Task<ActionResult<UsuariosModel>> BuscarUsuarioPorUsuario(string usuario)
        {
            UsuariosModel resultado = await _usuariosRepositorio.BuscarUsuarioPorUsuario(usuario);
            return Ok(resultado);
        }
        [HttpPost]
        public async Task<ActionResult<UsuariosModel>> Cadastrar([FromBody] UsuariosModel usuario)
        {
            await _usuariosRepositorio.AddUsuario(usuario);
            return Ok(usuario);
        }

        [HttpPost("usuario/login")]

        public async Task<IActionResult> Login([FromBody] UsuariosModel usuario)
        {
            var user = await _usuariosRepositorio.UsuarioLogin(usuario);
    
            if(user == false)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuariosModel>> Atualizar([FromBody] UsuariosModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuariosModel resultado = await _usuariosRepositorio.AtualizarUsuario(usuarioModel, id);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuariosModel>> Deletar(int id)
        {
            bool resultado = await _usuariosRepositorio.DeletarUsuario(id);
            return Ok(resultado);
        }
    }
}