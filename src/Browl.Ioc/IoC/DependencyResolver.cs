using Browl.Core.Business;
using Browl.Core.Repository;
using Browl.Core.UnitOfWork;
using Browl.Application.ApplicationServices;
using Browl.Application.Base;
using Browl.Application.Interface;
using Browl.Domain;
using Browl.Domain.Base;
using Browl.Domain.Interfaces.Repositories;
using Browl.Domain.Notifications;
using Browl.Infrastructure.Base;
using Browl.Infrastructure.Context;
using Browl.Infrastructure.Repositories;
using Browl.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Browl.Ioc
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
