using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Usuarios.Servicos.Interface;
using SistemaEscola.DataTransfer.Usuarios.Request;
using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.API.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppServico usuariosAppServico;
        public UsuariosController(IUsuariosAppServico usuariosAppServico) {
            this.usuariosAppServico = usuariosAppServico;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(UsuarioRequest request)
        {
            var resutado = await usuariosAppServico.Adicionar(request);

            return Ok(resutado);
        }

        [HttpGet]
        [Route("Recuperar")]
        public async Task<IActionResult> Recuperar(int idUsuario)
        {
            var resultado = await usuariosAppServico.RecuperarPorId(idUsuario);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("ListarUsuario")]
        public async Task<IActionResult> ListarUsuarios(string dominio)
        {
            var resultado = await usuariosAppServico.Listar(dominio);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("Logar")]
        public ActionResult<Usuario> Logar(LoginRequest request)
        {
            var resultado = usuariosAppServico.Logar(request);

            return Ok(resultado);
        }

        //[HttpDelete]
        //[Route("Deletar")]
        //public async Task<IActionResult> Delete(int id) {

        //    await usuariosAppServico.Deletar(id);

        //    return Ok();
        //}

    }
}
