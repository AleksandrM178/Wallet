﻿using Wallet.BLL.Logic.Contracts.Notififcation;
using Wallet.BLL.Logic.Contracts.Users;
using Wallet.BLL.Logic.Notification;
using Wallet.BLL.Logic.Users;
using Wallet.Common.Entities.HttpClientts;
using Wallet.DAL.Repository;
using Wallet.DAL.Repository.Contracts;
using Wallet.DAL.Repository.EF;

namespace Wallet.Api.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection ConfigureBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<INotificationLogic, NotificationLogic>();
            return services;
        }

        public static IServiceCollection ConfigureDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEFUserRepository, EFUserRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection ConfigureHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddHttpClient(
                HttpClientNames.EMAIL_SERVICE,
                client =>
                {  
                    client.BaseAddress = new Uri("https://localhost:7212/api/EmailSender/send");
                });
            return services;
        }
    }
}
