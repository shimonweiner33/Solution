using Solution.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Solution.Data.Models
{
    public class CheckInResult
    {
        public bool IsCheckIn { get; set; }
        public string ErrorMessage { get; set; }
        public TicketBase CorrectTicket { get; set; }
    }
}
