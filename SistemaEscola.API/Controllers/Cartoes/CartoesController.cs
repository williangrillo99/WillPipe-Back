using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Cartoes.Interface;
using SistemaEscola.DataTransfer.Cartoes;
using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.Dominio.Cartoes.Entidade;

namespace SistemaEscola.API.Controllers.Cartoes
{
    [ApiController]
    [Route("[controller]")]
    public class CartoesController : ControllerBase
    {
        readonly private ICartaoAppServico cartaoAppServico;
        public CartoesController(ICartaoAppServico cartaoAppServico)
        {
            this.cartaoAppServico = cartaoAppServico;
        }
        [HttpGet]
        [Route("Listar/{{idColuna}}")]
        public async Task<ActionResult<List<Cartao>>> Listar(int idColuna)
        {
            List<Cartao> cartao = await cartaoAppServico.Lista(idColuna);

            return Ok(cartao);
        }

        [HttpGet]
        [Route("Listar/todos/{idboard}")]
        public async Task<ActionResult<List<Cartao>>> ListarTodos(int idboard)
        {
            List<Cartao> cartao = await cartaoAppServico.ListarTodos(idboard);

            return Ok(cartao);
        }

        [HttpGet]
        [Route("Recuperar")]
        public async Task<ActionResult<Cartao>> Recuperar(int id)
        {
            Cartao cartao = await cartaoAppServico.RecuperarPorId(id);

            return Ok(cartao);
        }

        [Route("Adicionar/{idColuna}")]
        [HttpPost]
        public async Task<ActionResult<Cartao>> Adicionar(int idColuna)
        {
            Cartao cartao = await cartaoAppServico.Adicionar(idColuna);

            return Ok(cartao);
        }

        [Route("Atualizar")]
        [HttpPut]
        public async Task<ActionResult<Cartao>> Atualizar(CartaoMoverRequest request)
        {
            var cartao = await cartaoAppServico.Atualizar(request);

            return Ok(cartao);
        }
        [Route("Editar/{id}")]
        [HttpPut]
        public async Task<ActionResult<Cartao>> Editar(int id, CartoesRequest request)
        {
            var cartao = await cartaoAppServico.Editar(id, request);

            return Ok(cartao);
        }
    }
}
