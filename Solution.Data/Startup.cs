using Microsoft.Extensions.DependencyInjection;
using Solution.Data.Repository;
using Solution.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Data
{
    public static class Startup
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IParkingRepository, ParkingRepository>();
            services.AddSingleton<IMemberRepository, MemberRepository>();
            services.AddSingleton<IAcountRepository, AcountRepository>();

            return services;
        }
    }
}
