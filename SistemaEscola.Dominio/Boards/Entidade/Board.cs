
using SistemaEscola.Dominio.Colunas.Entidade;

namespace SistemaEscola.Dominio.Baords.Entidade
{
    public class Board : BaseEntity
    {   
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public IList<Coluna> Colunas { get; set; }  = new List<Coluna>();
    }
}
