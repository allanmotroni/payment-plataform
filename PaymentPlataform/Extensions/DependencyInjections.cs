using PaymentPlataform.Infra.Repositories.Transfers;
using PaymentPlataform.Infra.Repositories.Wallets;

namespace PaymentPlataform.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            return services;
        }
    }
}
