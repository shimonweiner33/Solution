using Solution.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Data.Models
{
    public abstract class TicketBase
    {
        protected int Height { get; set; }
        protected int Width { get; set; }
        protected int Length { get; set; }
        protected int Lots { get; set; }
        protected List<Class> Classes { get; set; }
        protected int Cost { get; set; }
        protected int TimeLimitInHours { get; set; }

        public virtual bool IsVehiclesDimensionsSuitableTicketType(int vehicleHeight, int vehicleWidth, int vehicleLength)
        {
            if (this.Height > vehicleHeight && this.Width > vehicleWidth && this.Length > vehicleLength) return true;
            return false;
        }
    }
    public class TicketVIP : TicketBase
    {
        public TicketVIP()
        {
            Height = int.MaxValue;
            Width = int.MaxValue;
            Length = int.MaxValue;
            Lots = 10;
            Classes = new List<Class>() { Class.A, Class.B, Class.C };
            Cost = 200;
            TimeLimitInHours = int.MaxValue;
        }
    }

    public class TicketValue : TicketBase
    {
        public TicketValue()
        {
            Height = 2500;
            Width = 2400;
            Length = 5000;
            Lots = 20;
            Classes = new List<Class>() { Class.A, Class.B };
            Cost = 100;
            TimeLimitInHours = 72;
        }
    }

    public class TicketRegular : TicketBase
    {
        public TicketRegular()
        {
            Height = 2000;
            Width = 2000;
            Length = 3000;
            Lots = 30;
            Classes = new List<Class>() { Class.A };
            Cost = 50;
            TimeLimitInHours = 24;
        }
    }
}
