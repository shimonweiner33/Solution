using Solution.Data.Models;
using System;
using System.Threading.Tasks;

namespace Solution.Services
{
    public interface IParkingService
    {
        Task<bool> CheckIn(CheckInDetails input);
        Task<bool> CheckOut(string licencePlateId);
        Task<string> GetVehiclesByTicketTypeJson(int? ticketType);
        Task<Vehicles> GetVehiclesByTicketType(int? ticketType);
    }
}
