using Solution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Repository.Interface
{
    public interface IParkingRepository
    {
        Task<bool> CheckIn(CheckInDetails input);
        Task<bool> CheckOut(string licencePlateId);
        Task<string> GetVehiclesByTicketType(int? ticketType);
    }
}
