using Microsoft.Extensions.DependencyInjection;
using Demo.Core.Business;
using Demo.Core.Repository;
using Demo.Core.UnitOfWork;
using Demo.Register.Application.ApplicationServices;
using Demo.Register.Application.Base;
using Demo.Register.Application.Interface;
using Demo.Register.Domain;
using Demo.Register.Domain.Base;
using Demo.Register.Domain.Interfaces.Repositories;
using Demo.Register.Domain.Notifications;
using Demo.Register.Infrastructure.Base;
using Demo.Register.Infrastructure.Context;
using Demo.Register.Infrastructure.Repositories;
using Demo.Register.Infrastructure.UnitOfWork;

namespace Demo.Register.Ioc
{
    public class DependencyResolver
    {

        public static void Resolve(IServiceCollection services)
        {
            ResolveDependencies(services);
        }

        private static void ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<RegisterDataContext>();

            //Proton Core
            services.AddScoped(typeof(IBusinessCrud<>), typeof(BusinessCrud<>));

            services.AddScoped(typeof(IRepositoryCrud<>), typeof(RepositoryCrud<>));

            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));


            services.AddScoped<ITerminalRepository, TerminalRepository>();

            services.AddScoped<ITerminalBusiness, TerminalBusiness>();


            // Application Services
            services.AddScoped<ITerminalAppService, TerminalAppService>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
