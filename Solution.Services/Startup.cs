using Microsoft.Extensions.DependencyInjection;
using Solution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services
{
    public static class Startup
    {

        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IAcountService, AcountService>();
            services.AddSingleton<IParkingService, ParkingService>();
            services.AddSingleton<TicketFactory>();
            return services;
        }
    }
}
