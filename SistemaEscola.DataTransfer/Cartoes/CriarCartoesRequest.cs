using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Comentarios.Entidade;
using SistemaEscola.Dominio.Tarefas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Cartoes
{
    public class CriarCartoesRequest
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int IdColuna { get; set; }
    }
}
