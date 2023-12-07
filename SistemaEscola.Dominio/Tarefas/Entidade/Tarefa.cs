using SistemaEscola.Dominio.Cartoes.Entidade;

namespace SistemaEscola.Dominio.Tarefas.Entidade
{
    public class Tarefa : BaseEntity
    {
        public string Descricao { get; set; } = null!;
        public bool Completo { get; set; }
        public Cartao Cartao { get; set; } = null!;
    }
}
