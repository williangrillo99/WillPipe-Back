using SistemaEscola.Dominio.Usuarios.Entidade;

namespace SistemaEscola.Dominio.Comentarios.Entidade
{
    public class Comentario : BaseEntity
    {
        public string Texto { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    }
}
