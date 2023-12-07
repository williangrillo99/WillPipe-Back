using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Usuarios.Enum
{
    public enum TipoUsuarioEnum
    {

        [Description("Comunm")]
        Comum = 0,
        [Description("Admin")]
        Admin = 1,
    }
}
