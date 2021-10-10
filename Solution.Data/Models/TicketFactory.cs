using Solution.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Models
{
    public class TicketFactory
    {
        private TicketVIP TicketVIP { get; set; } = new TicketVIP();
        private TicketRegular TicketRegular { get; set; } = new TicketRegular();
        private TicketValue TicketValue { get; set; } = new TicketValue();

        public async Task<TicketBase> GetTicket(TicketTypes ticketype)
        {
            TicketBase ticket = null;
            if (ticketype == TicketTypes.VIP)
            {
                ticket = TicketVIP;
            }
            if (ticketype == TicketTypes.Value)
            {
                ticket = TicketValue;
            }
            if (ticketype == TicketTypes.Regular)
            {
                ticket = TicketRegular;
            }
            return ticket;
        }

        public async Task<TicketBase> GetCorrectTicket(int vehicleHeight, int vehicleWidth, int vehicleLength)
        {
            TicketBase ticket = null;

            if (TicketValue.IsVehiclesDimensionsSuitableTicketType(vehicleHeight, vehicleWidth, vehicleLength))
            {
                ticket = TicketValue;
            }
            else if (TicketRegular.IsVehiclesDimensionsSuitableTicketType(vehicleHeight, vehicleWidth, vehicleLength))
            {
                ticket = TicketRegular;
            }
            else if (TicketVIP.IsVehiclesDimensionsSuitableTicketType(vehicleHeight, vehicleWidth, vehicleLength))
            {
                ticket = TicketVIP;
            }
            return ticket;
        }
    }

}
