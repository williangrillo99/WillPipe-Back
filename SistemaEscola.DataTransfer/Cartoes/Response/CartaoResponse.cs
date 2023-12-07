
using SistemaEscola.Dominio.Colunas.Entidade;

namespace SistemaEscola.DataTransfer.Cartoes.Response
{
    public class CartaoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Descricao { get; set; } = null!;
        public Coluna Colunas { get; set; }    
    }
}
