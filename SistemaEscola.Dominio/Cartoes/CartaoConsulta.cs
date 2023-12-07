using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Cartoes
{
    public  class CartaoConsulta
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }   
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
