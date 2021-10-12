using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Solution.Common.Enums;
using Solution.Data.Models;
using Solution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IParkingService _parkingService;

        private readonly TicketFactory _ticketFactory;

        public ParkingController(ILogger<ParkingController> logger, IParkingService IParkingService, TicketFactory ticketFactory)
        {
            _logger = Log.ForContext<ParkingController>();
            _parkingService = IParkingService;
            _ticketFactory = ticketFactory;
        }

        /// <summary>
        /// This function Gets the Vehicles list By TicketType.
        /// </summary>
        /// <param name="ticketType">ticketType use to filter vehicles int Vehicles-Table. if null => return all</param>
        /// <returns>Result - the model asked as string</returns>
        [HttpGet, Route("GetVehiclesByTicketType")]
        public async Task<string> GetVehiclesByTicketType(int? ticketType)
        {
            string result = string.Empty;

            try
            {
                result = await _parkingService.GetVehiclesByTicketTypeJson(ticketType);
                _logger.Information($"GetVehiclesByTicketType ('{ticketType}') Vehicles list => {result}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"GetVehiclesByTicketType ('{ticketType}') failed  => exception:{ex.Message}");
                return result;
            }
            return result;
        }

        /// <summary>
        /// This function target to check-in the vehicle.
        /// Checks whether the vehicles dimensions are suitable with the TicketType. 
        /// if yes -> a parking lot assigned to the vehicle. if not -> return the appropriate TicketType.
        /// </summary>
        /// <param name="input">CheckIn - details need for checks validation and assigned the parking lot</param>
        /// <returns>Result - the model asked as ...</returns>
        [HttpPost, Route("CheckIn")]
        public async Task<CheckInResult> CheckIn(CheckInDetails input)
        {
            bool result = false;
            CheckInResult checkInResult = new CheckInResult();
            try
            {
                if (!input.VehicleType.HasValue || !input.TicketType.HasValue || !input.VehicleHeight.HasValue || !input.VehicleWidth.HasValue
                    || !input.VehicleLength.HasValue || String.IsNullOrEmpty(input.LicencePlateId))
                {
                    checkInResult.ErrorMessage = "invalid Check In Details ";
                }
                else if((int)input.TicketType.Value > 3)//to do change validation
                {
                    checkInResult.ErrorMessage = "invalid Check In Details ";
                }
                else
                {
                    TicketBase ticketBase = await _ticketFactory.GetTicket(input.TicketType.Value);
                    if (!ticketBase.IsVehiclesDimensionsSuitableTicketType(input.VehicleHeight.Value, input.VehicleWidth.Value, input.VehicleLength.Value))
                    {
                        ticketBase = await _ticketFactory.GetCorrectTicket(input.VehicleHeight.Value, input.VehicleWidth.Value, input.VehicleLength.Value);
                        checkInResult.CorrectTicket = ticketBase;
                        checkInResult.ErrorMessage = "ticket dimensions are not suitable with the Vehicle dimensions. the correct ticket is - " + ticketBase;
                    }
                    else
                    {
                        result = await _parkingService.CheckIn(input);
                        checkInResult.IsCheckIn = result;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckIn ('{input}') failed  => exception:{ex.Message}");
                return checkInResult;
            }
            return checkInResult;
        }

        /// <summary>
        /// This function target to check-out the vehicle.
        /// Checks whether exist vehicle with licencePlateId in the parking-lots if ture-> remove this vehicle. 
        /// </summary>
        /// <param name="licencePlateId">licencePlateId need for check out</param>
        /// <returns>true if the vehicle check out</returns>
        [HttpPost, Route("CheckOut")]
        public async Task<bool> CheckOut([FromBody] string licencePlateId)
        {
            bool result = false;

            try
            {
                result = await _parkingService.CheckOut(licencePlateId);
                _logger.Information($"CheckOut ('{licencePlateId}') update => {result}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckOut ('{licencePlateId}') failed  => exception:{ex.Message}");
                return false;
            }
            return result;
        }
    }
}
