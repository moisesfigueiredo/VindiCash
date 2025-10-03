using Microsoft.Extensions.DependencyInjection;
using Vindi.Cash.Api.Domain.Abstractions;
using Vindi.Cash.Api.ImMemoryDatabase.Repositories;

namespace Vindi.Cash.Api.IoC
{
    public static class RootBootstrapper
    {
        public static void BootstrapperRegisterServices(this IServiceCollection services)
        {
            var assemblyTypes = typeof(RootBootstrapper).Assembly.GetNoAbstractTypes();

            services.AddImplementations(ServiceLifetime.Scoped, typeof(IBaseRepository), assemblyTypes);

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILogDesativacaoRepository, LogDesativacaoRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            var handlers = AppDomain.CurrentDomain.Load("Vindi.Cash.Api.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));
        }
    }
}