using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Tarefas
{
    public class CriarTarefaRequest
    {
        public string Descricao { get; set; } = null!;
        public int IdCartao { get; set; }
    }
}
