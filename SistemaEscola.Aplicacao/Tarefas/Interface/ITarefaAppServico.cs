using SistemaEscola.DataTransfer.Tarefas;
using SistemaEscola.Dominio.Tarefas.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Tarefas.Interface
{
    public interface ITarefaAppServico
    {
        Task<List<Tarefa>> Listar();
        Task<Tarefa> Adicionar(CriarTarefaRequest request);
        Task<Tarefa> RecuperarPorId(int id);
    }
}
