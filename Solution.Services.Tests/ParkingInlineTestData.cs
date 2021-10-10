using Solution.Common.Enums;
using Solution.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services.Tests
{
    public static class ParkingInlineTestData
    {
        private static readonly List<ParkingGetAllInlineTestDataInfo> _getVehiclesByTicketType = new List<ParkingGetAllInlineTestDataInfo>()
        {
            new ParkingGetAllInlineTestDataInfo() {
                TicketType = 1,
                Data = new CheckInDetails()
                {
                    LicencePlateId = "9111111",
                    Name = "David",
                    Phone = "0545888888",
                    TicketType = TicketTypes.VIP,
                    VehicleHeight = 8000,
                    VehicleLength = 8000,
                    VehicleWidth = 8000,
                    VehicleType = VehicleTypes.Motorcycle
                },
                ExpectedResult = true
            },
            new ParkingGetAllInlineTestDataInfo() {
                TicketType = null,
                Data = new CheckInDetails()
                {
                    LicencePlateId = "9111111",
                    Name = "David",
                    Phone = "0545888888",
                    TicketType = TicketTypes.VIP,
                    VehicleHeight = 8000,
                    VehicleLength = 8000,
                    VehicleWidth = 8000,
                    VehicleType = VehicleTypes.Motorcycle
                },
                ExpectedResult = true
            },
        };
        private static readonly List<CheckInDetailsInlineTestDataInfo> _checkInDataValid = new List<CheckInDetailsInlineTestDataInfo>()
        {
                new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "9111111",
                          Name = "David",
                          Phone = "0545888888",
                          TicketType = TicketTypes.VIP,
                          VehicleHeight = 8000,
                          VehicleLength = 8000,
                          VehicleWidth = 8000,
                          VehicleType = VehicleTypes.Motorcycle
                       },
                       ExpectedResult = true
                 },
                new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "8111111",
                          Name = "Netanel",
                          Phone = "0525888888",
                          TicketType = TicketTypes.VIP,
                          VehicleHeight = 1000,
                          VehicleLength = 1000,
                          VehicleWidth = 1000,
                          VehicleType = VehicleTypes.Private
                       },
                       ExpectedResult = true
                },
                new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "7111111",
                          Name = "Shachar",
                          Phone = "0545777777",
                          TicketType = TicketTypes.Value,
                          VehicleHeight = 2400,
                          VehicleWidth = 2400,
                          VehicleLength = 4000,
                          VehicleType = VehicleTypes.Crossover
                       },
                       ExpectedResult = true
                 },
                 new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "6111111",
                          Name = "Gadi",
                          Phone = "0545666666",
                          TicketType = TicketTypes.Regular,
                          VehicleHeight = 1500,
                          VehicleLength = 1500,
                          VehicleWidth = 2000,
                          VehicleType = VehicleTypes.SUV
                       },
                       ExpectedResult = true
                 },
        };
        private static readonly List<CheckInDetailsInlineTestDataInfo> _checkInDataInValid = new List<CheckInDetailsInlineTestDataInfo>()
        {
                new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "9111111",
                          Name = "David",
                          Phone = "0545888888",
                          TicketType = TicketTypes.Regular,
                          VehicleHeight = 8000,
                          VehicleLength = 8000,
                          VehicleWidth = 8000,
                          VehicleType = VehicleTypes.Motorcycle
                       },
                       ExpectedResult = true
                 },
                new CheckInDetailsInlineTestDataInfo() {
                       Data = new CheckInDetails
                       {
                          LicencePlateId = "8111111",
                          Name = "Netanel",
                          Phone = "0525888888",
                          TicketType = TicketTypes.Value,
                          VehicleHeight = 7000,
                          VehicleLength = 7000,
                          VehicleWidth = 7000,
                          VehicleType = VehicleTypes.Private
                       },
                       ExpectedResult = true
                }
        };

        public static IEnumerable<object[]> GetVehiclesByTicketType
        {
            get
            {
                foreach (var v in _getVehiclesByTicketType)
                    yield return new object[] { v };
            }
        }
        public static IEnumerable<object[]> TestData_Check_In_DataValid
        {
            get
            {
                foreach (var v in _checkInDataValid)
                    yield return new object[] { v };
            }
        }
        public static IEnumerable<object[]> TestData_Check_In_DataInValid
        {
            get
            {
                foreach (var v in _checkInDataInValid)
                    yield return new object[] { v };
            }
        }
    }

    public class ParkingGetAllInlineTestDataInfo
    {
        public int? TicketType { get; set; }
        public CheckInDetails Data { get; set; }
        public bool ExpectedResult { get; set; }
    }
    public class CheckInDetailsInlineTestDataInfo
    {
        public CheckInDetails Data { get; set; }
        public bool ExpectedResult { get; set; }
    }
}
