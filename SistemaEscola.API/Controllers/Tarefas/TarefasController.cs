using Microsoft.AspNetCore.Mvc;
using SistemaEscola.Aplicacao.Colunas.Servicos;
using SistemaEscola.Aplicacao.Colunas.Servicos.Interface;
using SistemaEscola.Aplicacao.Tarefas.Interface;
using SistemaEscola.DataTransfer.Colunas;
using SistemaEscola.DataTransfer.Tarefas;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Tarefas.Entidade;

namespace SistemaEscola.API.Controllers.Tarefas
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        readonly private ITarefaAppServico tarefaAppServico;
        public TarefasController(ITarefaAppServico tarefaAppServico)
        {
            this.tarefaAppServico = tarefaAppServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<List<Tarefa>>> Listar()
        {
            List<Tarefa> tarefas = await tarefaAppServico.Listar();

            return Ok(tarefas);
        }

        [HttpGet]
        [Route("Recuperar")]
        public async Task<ActionResult<Tarefa>> Recuperar(int id)
        {
            Tarefa tarefa = await tarefaAppServico.RecuperarPorId(id);

            return Ok(tarefa);
        }


        [Route("Adicionar")]
        [HttpPost]
        public async Task<ActionResult<Tarefa>> Adicionar(CriarTarefaRequest request)
        {
            Tarefa tarefa = await tarefaAppServico.Adicionar(request);

            return Ok(tarefa);
        }
    }
}
