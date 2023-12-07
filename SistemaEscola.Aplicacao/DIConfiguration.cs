using Microsoft.Extensions.DependencyInjection;
using SistemaEscola.Aplicacao.Usuarios.Servicos;
using SistemaEscola.Aplicacao.Usuarios.Servicos.Interface;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscola.Aplicacao;
public class DIConfiguration
{    
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();
    }
}



