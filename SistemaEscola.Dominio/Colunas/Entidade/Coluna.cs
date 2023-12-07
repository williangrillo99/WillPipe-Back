
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Dominio.Baords.Entidade;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscola.Dominio.Colunas.Entidade
{
    public class Coluna : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public List<Cartao> Cartoes { get; set; }
        public Board Board { get; set; } = null!;
    }   
}