using SistemaEscola.DataTransfer.Usuarios.Request;
using SistemaEscola.DataTransfer.Usuarios.Response;
using SistemaEscola.Dominio.Usuarios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao.Usuarios.Servicos.Interface
{
    public interface IUsuariosAppServico
    {
        Task<UsuarioResponse> Adicionar(UsuarioRequest request);
        Task<List<UsuarioResponse>> Listar(string dominio);
        Usuario Logar(LoginRequest request);
        Task<Usuario> RecuperarPorId(int IdUsuario);
        Task Deletar(int IdUsuario);

    }
}
