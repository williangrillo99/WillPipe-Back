using SistemaEscola.Dominio.Usuarios.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Dominio.Usuarios.Entidade
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Dominio { get; set; } = null!;
        public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
        protected Usuario() { }

        public Usuario(string nome, string login, string senha, string email, string dominio)
        {
            Nome = nome;
            Senha =  senha;
            Email = email;
            Dominio = dominio;
            Senha = senha;
        }
    }
}
