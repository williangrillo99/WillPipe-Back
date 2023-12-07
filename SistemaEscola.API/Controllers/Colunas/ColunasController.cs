using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Colunas.Servicos.Interface;
using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Colunas.Response;
using SistemaEscola.Dominio.Colunas.Consultas;
using SistemaEscola.Dominio.Colunas.Entidade;

namespace SistemaEscola.API.Controllers.Colunas
{
    [ApiController]
    [Route("[controller]")]
    public class ColunasController : ControllerBase
    {
        readonly private IColunaAppServico colunasAppServico;
        public ColunasController(IColunaAppServico colunasAppServico)
        {
            this.colunasAppServico = colunasAppServico;
        }

        [HttpGet]
        [Route("Listar/{idBoard}")]
        public async Task<ActionResult<ColunaListagem>> Listar(int idBoard)
        {
            ColunaListagem colunas = await colunasAppServico.Listar(idBoard);
            
            return Ok(colunas);
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<ActionResult<Coluna>>Adicionar(AdicionarColunasRequest request)
        {
            Coluna coluna = await colunasAppServico.Adicionar(request);

            return Ok(coluna);
        }

        [Route("Atualizar/{id}")]
        [HttpPut]
        public async Task<ActionResult<ColunasResponse>> Editar(int id,  ColunaTituloRequest request)
        {

            var response = await colunasAppServico.AtualizarTitulo(id, request);

            return response;

        }

        [Route("Deletar/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await colunasAppServico.DeletarColuna(id);

            
            return Ok();    
        }
  

    }
}
