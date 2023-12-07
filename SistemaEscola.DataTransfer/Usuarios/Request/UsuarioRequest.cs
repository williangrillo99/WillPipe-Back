using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.DataTransfer.Usuarios.Request
{
    public class UsuarioRequest
    {
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}

