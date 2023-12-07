using SistemaEscola.Dominio.Baords.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Baords.Servicos.Interface
{
    public interface IBoardServico
    {
        Task<Board> Recupear(int id);
    }
}
