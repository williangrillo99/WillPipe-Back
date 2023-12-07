using SistemaEscola.Dominio.Usuarios.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Usuarios.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Login { get; set; }
        public string Email { get; set; }
        public string Dominio { get; set; }
        public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
    }
}
