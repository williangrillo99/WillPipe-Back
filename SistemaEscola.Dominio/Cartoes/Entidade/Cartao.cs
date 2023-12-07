using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Comentarios.Entidade;
using SistemaEscola.Dominio.Tarefas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.Dominio.Cartoes.Entidade
{
    public class Cartao : BaseEntity
    {
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
        public int Progresso { get; set; }
        public Usuario? UsuarioResponsavel { get; set; }
        public Coluna Coluna { get; set; } = null!;
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public int Index { get; set; }
    }
}
