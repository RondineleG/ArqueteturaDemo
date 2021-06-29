using Microsoft.Extensions.DependencyInjection;
using Proton.Core.Business;
using Proton.Core.Repository;
using Proton.Core.UnitOfWork;
using Proton.Register.Application.ApplicationServices;
using Proton.Register.Application.Base;
using Proton.Register.Application.Interface;
using Proton.Register.Domain;
using Proton.Register.Domain.Base;
using Proton.Register.Domain.Interfaces.Repositories;
using Proton.Register.Domain.Notifications;
using Proton.Register.Infrastructure.Base;
using Proton.Register.Infrastructure.Context;
using Proton.Register.Infrastructure.Repositories;
using Proton.Register.Infrastructure.UnitOfWork;

namespace Proton.Register.Ioc
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
