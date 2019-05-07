using Cashback.Commom.Notifications;
using Cashback.Commom.Publisher;
using Cashback.Database.Context;
using Cashback.Database.Repositories;
using Cashback.Database.UnitOfWork;
using Cashback.Domain.Commands;
using Cashback.Domain.Events;
using Cashback.Domain.Interfaces;
using Cashback.Domain.Services;
using Cashback.Infrastructure.ExternalServices.SpotifyService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cashback.Cross.IoC
{
    public static class DepedencyInjectRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Publisher 
            services.AddScoped<IPublisher, Publisher>();

            // Domain Services
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddScoped<ICashBackCalculatorService, CashBackCalculatorService>();
            services.AddScoped<ICashBackConfigurationService, CashBackConfigurationService>();
            
            //Repository
            services.AddScoped<IDiskReadRepositoy, ReadOnlyDiskCollection>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<ICashBackRepository, CashBackRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Context
            //services.AddScoped<DiskEcommerceContext>();
            //services.AddScoped<DbContextOptions<DiskEcommerceContext>>();
            services.AddDbContext<DiskEcommerceContext>(opt => opt.UseInMemoryDatabase("eCashback",null));

            //Commands
            services.AddScoped<IRequestHandler<PlaceOrderCommand,Unit>, PlaceOrderCommandHandler>();

            //Events
            services.AddScoped<INotificationHandler<OrderPlacedEvent>, OrderPlacedEventHandler>();
            services.AddScoped<DomainNotificationHandler>();

           
        }
    }
}
