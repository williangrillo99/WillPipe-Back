using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Dominio.Comentarios.Entidade;
using SistemaEscola.Dominio.Tarefas.Entidade;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.DataTransfer.Colunas;

namespace SistemaEscola.DataTransfer.Cartoes
{
    public class CartaoMoverRequest
    {
        public int IdBoard { get;set; }
        public List<CartaoRequest>? colunaAntiga { get; set; }
        public string? NomeConlunaAnterior { get; set; }
        public List<CartaoRequest>? colunaAtual { get; set; }
        public string? NomeColunaIndex { get; set; }


    }
    public class CartaoRequest
    {
            public int Id { get; set; }
            public string Titulo { get; set; } = null!;
            public string? Descricao { get; set; }
            public ColunasRequest Coluna { get; set; } = null!;
            public DateTime DataInicio { get; set; }
            public DateTime? DataFim { get; set; }
        
    }
}
