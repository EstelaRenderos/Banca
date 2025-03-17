using Banca.Core.Interfaces;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Repositories;
using Banca.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banca.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            services.AddScoped<ITransferTypeRepository, TransferTypeRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            return services;
        }

    }
}
