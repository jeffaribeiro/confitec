using Confitec.Application.UoW;
using Confitec.Infra.Data.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace Confitec.Infra.CrossCutting.IoC.Containers
{
    public class DatabaseContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbConnection>(provider =>
            {
                return new SqlConnection(configuration.GetConnectionString("Confitec"));
            });

            services.AddScoped<DbSession>();
            services.AddScoped<IUoW, UoW>();
        }
    }
}
