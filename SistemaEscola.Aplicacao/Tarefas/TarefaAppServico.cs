using SistemaEscola.Aplicacao.Tarefas.Interface;
using SistemaEscola.DataTransfer.Tarefas;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Tarefas.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Tarefas
{
    public class TarefaAppServico : ITarefaAppServico
    {
        private readonly IRepositorioGenerico<Tarefa> repositorioGenerico;
        private readonly IRepositorioGenerico<Cartao> repositorioCartaoGenerico;

        public TarefaAppServico(IRepositorioGenerico<Tarefa> repositorioGenerico, IRepositorioGenerico<Cartao> repositorioCartaoGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
            this.repositorioCartaoGenerico = repositorioCartaoGenerico;
        }
        public async Task<Tarefa> Adicionar(CriarTarefaRequest request)
        {
            var cartao = await repositorioCartaoGenerico.RecuperarPorIdAsync(request.IdCartao);

            if (cartao == null)
            {
                throw new NotImplementedException();

            }
            Tarefa tarefa = new Tarefa();
            tarefa.Descricao = request.Descricao;
            tarefa.Cartao = cartao;


             return tarefa;
        }

        public async Task<List<Tarefa>> Listar()
        {
            var cartao = await repositorioGenerico.RecuperarAsync(null, null, x=> x.Cartao);

            return cartao;
        }

        public async Task<Tarefa> RecuperarPorId(int id)
        {
            var cartao = await repositorioGenerico.RecuperarPorIdAsync(id);

            return cartao;
        }
    }
}
