using Confitec.Application.Repositories;
using Confitec.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.CrossCutting.IoC.Containers
{
    public class RepositoriesContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
