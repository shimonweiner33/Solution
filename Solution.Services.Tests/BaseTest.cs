using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services.Tests
{
    public class BaseTest
    {
        public IConfiguration Configuration { get; set; }

        public BaseTest()
        {
            if(Configuration == null)
            Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.json", true).Build();
        }
    }
}
