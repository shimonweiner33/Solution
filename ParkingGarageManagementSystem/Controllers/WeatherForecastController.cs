using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingGarageManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckInDetailsController : ControllerBase
    {

        private readonly ILogger<CheckInDetailsController> _logger;

        public CheckInDetailsController(ILogger<CheckInDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Object Get()
        {
            return new { "fffffffffffff"};
        }
    }
}
