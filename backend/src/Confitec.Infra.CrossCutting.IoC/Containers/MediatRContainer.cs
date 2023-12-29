using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.CrossCutting.IoC.Containers
{
    public class MediatRContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.Contains("Confitec.Application")).ToArray();

            services.AddMediatR(assemblies);
        }
    }
}
