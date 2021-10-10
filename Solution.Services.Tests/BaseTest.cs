using Microsoft.Extensions.Configuration;
using Solution.Data.Models;
using Solution.Data.Repository;
using Solution.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services.Tests
{
    public class BaseTest
    {
        protected static IConfiguration Configuration { get; set; }
        protected static IParkingRepository _parkingRepository { get; set; }
        protected static IParkingService _parkingService;
        protected static TicketFactory _ticketFactory;

        

        public BaseTest()
        {
            if(Configuration == null)
            Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.json", true).Build();
            if(_parkingRepository == null)
            {
                _parkingRepository = new ParkingRepository(Configuration);
            }
            if (_parkingService == null)
            {
                _parkingService = new ParkingService(_parkingRepository);
            }
            if(_ticketFactory == null)
            {
                _ticketFactory = new TicketFactory();
            }
        }
    }
}
