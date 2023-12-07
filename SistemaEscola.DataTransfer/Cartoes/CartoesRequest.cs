using SistemaEscola.DataTransfer.Colunas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Cartoes
{
    public class CartoesRequest
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public int? Progresso { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? dataFim { get; set; }
    }
}
