using PaymentPlataform.Infra.Repositories.Transfers;
using PaymentPlataform.Infra.Repositories.Wallets;
using PaymentPlataform.Services.Wallets;

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

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            //services.AddScoped<ITransferService, TransferService>();

            return services;
        }
    }
}
