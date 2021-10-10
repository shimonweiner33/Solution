using Solution.Data.Models;
using Solution.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Configuration;
namespace Solution.Services.Tests
{


    /// <summary>
    /// This unit testing class verify the correct functionality of the "ParkingService".
    /// </summary>
    public class ParkingServiceShould : BaseTest
    {
        private readonly IParkingService _parkingService;
        private readonly IConfiguration _configuration;
        public ParkingServiceShould()
        {
            _parkingService = new ParkingService(new ParkingRepository(Configuration));
        }

        /// <summary>
        /// Tests if the Vehicles list were returned from ParkingLots table by order.
        /// if TicketType is not null => The expected result is all the Vehicles that parking now in the parking-lot with spesific TicketType. 
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
                resultData = await _parkingService.GetVehiclesByTicketType(testDataInfo.TicketType);
                actualResult = resultData.Items != null && resultData.Items.Count > 0;
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
        /// The result is integer number. when actualResult > expectedNotResult - the post would be fully created or updated.  in Posts - table.
        /// </summary>
        //[Theory]
        //[MemberData(nameof(ParkingInlineTestData.TestData_Check_In_DataValid), MemberType = typeof(PostsInlineTestData))]
        //public async void CheckIn_AddVehicleToParkingLots(CheckInDetailsInlineTestDataInfo testDataInfo)
        //{
        //    // Arrange

        //    int actualResult = 0;

        //    // Act
        //    try
        //    {
        //        actualResult = await _parkingService.CreateOrUpdatePost(testDataInfo.Data);
        //    }
        //    catch
        //    {
        //        actualResult = 0;
        //    }
        //    finally
        //    {
        //        // need to Rollback;
        //    }
        //    Assert.True(testDataInfo.ExpectedNotResult < actualResult);
        //}

    }

}
