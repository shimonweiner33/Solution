using Solution.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Solution.Data.Models
{
    public class Vehicles
    {
        [JsonPropertyName("Vehicles")]
        public List<CheckInDetails> Items { get; set; } = new List<CheckInDetails>();
        public override string ToString()
        {
            string result = JsonSerializer.Serialize(Items);
            return result;
        }
    }
    public class CheckInDetails
    {
        public string LicencePlateId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public TicketTypes TicketType { get; set; }
        public int VehicleType { get; set; }
        public int VehicleHeight { get; set; }
        public int VehicleWidth { get; set; }
        public int VehicleLength { get; set; }
    }
}
