using Solution.Data.Models;
using Solution.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Configuration;
using Solution.Data.Repository.Interface;
using Solution.Common.Enums;

namespace Solution.Services.Tests
{


    /// <summary>
    /// This unit testing class verify the correct functionality of the "ParkingService".
    /// </summary>
    public class ParkingServiceShould : BaseTest
    {
        public ParkingServiceShould()
        {
        }

        /// <summary>
        /// Tests if the Vehicles list were returned from ParkingLots table by order.
        /// if TicketType is not null => The expected result is all the Vehicles that parking now in the parking-lot with specific TicketType. 
        /// if TicketType is null => The expected result is all the Vehicles that parking now in the parking-lot.
        /// </summary>
        [Theory]
        [MemberData(nameof(ParkingInlineTestData.GetVehiclesByTicketType), MemberType = typeof(ParkingInlineTestData))]
        public async void GetVehiclesByTicketType_AllItemsReturned(ParkingGetAllInlineTestDataInfo testDataInfo)
        {
            // Arrange
            Vehicles resultData;
            bool actualResult;
            // Act
            try
            {
                actualResult = await _parkingService.CheckIn(testDataInfo.Data);
                Assert.True(actualResult);

                resultData = await _parkingService.GetVehiclesByTicketType(testDataInfo.TicketType);
                actualResult = resultData.Items != null && resultData.Items.Count > 0;

                actualResult = await _parkingService.CheckOut(testDataInfo.Data.LicencePlateId);
                Assert.True(actualResult);
            }
            catch
            {
                actualResult = false;
            }

            // Assert
            Assert.Equal(testDataInfo.ExpectedResult, actualResult);
        }

        /// <summary>
        /// Tests if check in vehicle will success.
        /// The result is true if success. else result is false.
        /// </summary>
        [Theory]
        [MemberData(nameof(ParkingInlineTestData.TestData_Check_In_DataValid), MemberType = typeof(ParkingInlineTestData))]
        public async void CheckInCheckOn_AddAndSubtractVehicleFromParkingLots(CheckInDetailsInlineTestDataInfo testDataInfo)
        {
            // Arrange

            bool actualResult = false;

            // Act
            try
            {
                TicketBase ticketBase = await _ticketFactory.GetTicket(testDataInfo.Data.TicketType.Value);
                Assert.NotNull(ticketBase);

                if (!ticketBase.IsVehiclesDimensionsSuitableTicketType(testDataInfo.Data.VehicleHeight.Value, testDataInfo.Data.VehicleWidth.Value, testDataInfo.Data.VehicleLength.Value))
                {
                    actualResult = false;
                }
                else
                {
                    actualResult = await _parkingService.CheckIn(testDataInfo.Data);
                    Assert.True(actualResult);
                    actualResult = await _parkingService.CheckOut(testDataInfo.Data.LicencePlateId);
                }
            }
            catch
            {
                actualResult = false;
            }
            finally
            {
                // need to Rollback;
            }
            Assert.Equal(testDataInfo.ExpectedResult, actualResult);
        }
        /// <summary>
        /// Tests if check in vehicle will fail with invalid data. The data does not match the rules of the TicketType
        /// The result is true if the data not match the rules. else result is false.
        /// </summary>
        [Theory]
        [MemberData(nameof(ParkingInlineTestData.TestData_Check_In_DataInValid), MemberType = typeof(ParkingInlineTestData))]
        public async void CheckIn_NotAddVehicleToParkingLots(CheckInDetailsInlineTestDataInfo testDataInfo)
        {
            // Arrange

            bool actualResult = false;

            // Act
            try
            {
                TicketBase ticketBase = await _ticketFactory.GetTicket(testDataInfo.Data.TicketType.Value);
                Assert.NotNull(ticketBase);

                if (!ticketBase.IsVehiclesDimensionsSuitableTicketType(testDataInfo.Data.VehicleHeight.Value, testDataInfo.Data.VehicleWidth.Value, testDataInfo.Data.VehicleLength.Value))
                {
                    ticketBase = await _ticketFactory.GetCorrectTicket(testDataInfo.Data.VehicleHeight.Value, testDataInfo.Data.VehicleWidth.Value, testDataInfo.Data.VehicleLength.Value);
                    Assert.NotNull(ticketBase);
                    actualResult = true;
                }
            }
            catch
            {
                actualResult = false;
            }
            finally
            {
                // need to Rollback;
            }
            Assert.Equal(testDataInfo.ExpectedResult, actualResult);
        }


        /// <summary>
        /// Checks the functionality of the GetTicket and IsVehiclesDimensionsSuitableTicketType functions is correct.
        /// The result is true if the functionality is correct. else result is false.
        /// </summary>
        [Fact]
        public async void ChecksFunctionality()
        {
            bool actualResult = false;

            try
            {
                TicketBase ticketVIP = await _ticketFactory.GetTicket(TicketTypes.VIP);
                Assert.NotNull(ticketVIP);
                Assert.True(ticketVIP.IsVehiclesDimensionsSuitableTicketType(8000, 8000, 8000));

                TicketBase ticketValue = await _ticketFactory.GetTicket(TicketTypes.Value);
                Assert.NotNull(ticketValue);
                Assert.True(ticketValue.IsVehiclesDimensionsSuitableTicketType(2500, 2400, 5000));

                TicketBase ticketRegular = await _ticketFactory.GetTicket(TicketTypes.Regular);
                Assert.NotNull(ticketRegular);
                Assert.True(ticketRegular.IsVehiclesDimensionsSuitableTicketType(2000, 2000, 3000));

                actualResult = true;
            }
            catch
            {
                actualResult = false;
            }
            finally
            {
                // need to Rollback;
            }
            Assert.True(actualResult);
        }
    }
}
