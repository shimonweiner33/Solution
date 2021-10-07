using Serilog;
using Solution.Data.Models;
using Solution.Data.Repository.Interface;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Solution.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository parkingRepository;
        private readonly Serilog.ILogger _logger;
        public ParkingService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
            _logger = Log.ForContext<ParkingService>();
        }

        public async Task<bool> CheckIn(CheckInDetails input)
        {
            bool result = false;
            try
            {
                result = await parkingRepository.CheckIn(input);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckIn('{input}')  failed");
                throw;
            }
            _logger.Debug($"CheckIn('{input}')  result={result}");
            return result;
        }

        public async Task<bool> CheckOut(string licencePlateId)
        {
            bool result = false;
            try
            {
                result = await parkingRepository.CheckOut(licencePlateId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckOut('{licencePlateId}')  failed");
                throw;
            }
            _logger.Debug($"CheckOut('{licencePlateId}')  result={result}");
            return result;
        }

        public async Task<string> GetVehiclesByTicketTypeJson(int? ticketType)
        {
            string result = string.Empty;
            try
            {
                result = await parkingRepository.GetVehiclesByTicketType(ticketType);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"GetVehiclesByTicketTypeJson('{ticketType}')  failed");
                throw;
            }
            _logger.Debug($"GetVehiclesByTicketTypeJson('{ticketType}')  result={result}");
            return result;
        }

        public async Task<Vehicles> GetVehiclesByTicketType(int? ticketType)
        {
            string jsonResult = string.Empty;
            Vehicles result = new Vehicles();
            try
            {
                jsonResult = await GetVehiclesByTicketTypeJson(ticketType);
                result = (!string.IsNullOrWhiteSpace(jsonResult)) ? JsonSerializer.Deserialize<Vehicles>(jsonResult) : null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"GetVehiclesByTicketType('{ticketType}')  failed");
                throw;
            }
            _logger.Debug($"GetVehiclesByTicketType('{ticketType}')  result={jsonResult}");
            return result;
        }
    }
}
