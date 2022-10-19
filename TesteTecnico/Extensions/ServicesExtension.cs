using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TesteTecnico.Interfaces;
using TesteTecnico.Repository;

namespace TesteTecnico.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<IRetorno, RetornaListaRepository>();
            service.AddTransient<IVerificaValores, VerificaValoresRepository>();
        }
    }
}
