using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Boards.Servicos.Interface;
using SistemaEscola.DataTransfer.Baords;
using SistemaEscola.DataTransfer.Boards.Response;
using SistemaEscola.Dominio.Baords.Entidade;

namespace SistemaEscola.API.Controllers.Boards
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        readonly private IBoardAppServico boardAppServico;
        public BoardController(IBoardAppServico boardAppServico)
        {
            this.boardAppServico = boardAppServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<List<Board>>> Listar()
        {
            var lista = await boardAppServico.Listar();
            return lista;
        }

        [HttpGet]
        [Route("Recuperar/{id}")]
        public async Task<ActionResult<Board>> Recuperar(int id)
        {
            var board = await boardAppServico.Recuperar(id);
            return board;
        }


        [HttpGet]
        [Route("RecuperarNome")]
        public async Task<ActionResult<List<BoardResponse>>> RecuperarNome()
        {
            var board = await boardAppServico.RecuperarPorNome();
            return board;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<ActionResult<Board>>Adicionar(BaordRequest request)
        {
            List<Board> baord = await boardAppServico.Adicionar(request);

            return Ok(baord);
        }

        [Route("Editar/{id}")]
        [HttpPut]
        public async Task<ActionResult<List<Board>>>Editar(int id,  BaordRequest request)
        {
            List<Board> baords = await boardAppServico.Editar(id, request);

            return baords;

        }

        [Route("Deletar/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await boardAppServico.Deletar(id);
            return Ok();
        }

    }
}
