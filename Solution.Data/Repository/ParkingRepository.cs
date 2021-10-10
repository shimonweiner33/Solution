using Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Solution.Data.Models;
using Solution.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Repository
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {
        private readonly ILogger _logger;

        public ParkingRepository(IConfiguration configuration) : base(configuration)
        {
            _logger = Log.ForContext<ParkingRepository>();
        }



        public async Task<bool> CheckIn(CheckInDetails input)
        {
            try
            {
                var sQuery = string.Format(@"
                                DECLARE @capacity INT
                                SET @capacity = (select {0} from Params)
                                DECLARE @minLot INT
                                SET @minLot = (select {1} from Params)
                                DECLARE @maxLot INT
                                SET @maxLot = (select {2} from Params)
                                
                                DROP TABLE IF EXISTS #Temp

                                CREATE TABLE #Temp
                                (
                                    LotNumber int
                                )
                                INSERT INTO #Temp
                                SELECT LotNumber FROM ParkingLots WHERE TicketType = @ticketType
                                ---------------
                                DECLARE @lot INT;
                                SET @lot = @minLot;
                                
                                DECLARE @lotFound BIT;
                                SET @lotFound = 0;
                                
                                WHILE @lot <= @maxLot AND @lotFound = 0
                                BEGIN
                                   IF(@lot NOT IN (select LotNumber from #Temp))
                                		BEGIN
                                				PRINT @lot
                                				SET @lotFound = 1
                                		END
                                   ELSE
                                		BEGIN
                                				SET @lot = @lot + 1;
                                		END
                                END;


                                DECLARE @occupy INT
                                SET @occupy = (select count(LicencePlateId) from ParkingLots where TicketType = @ticketType)

                                IF(@capacity > @occupy AND 
                                    NOT EXISTS (SELECT * FROM ParkingLots WHERE LicencePlateId = @licencePlateId)
                                )
                                BEGIN
                                      INSERT INTO ParkingLots(LicencePlateId, Name, Phone, TicketType, VehicleType, VehicleHeight, VehicleWidth, VehicleLength, LotNumber)
                                      VALUES(@licencePlateId, @name, @phone, @ticketType, @vehicleType, @vehicleHeight, @vehicleLength, @vehicleWidth, @lot);
                                END 
                                ", input.TicketType + "Capacity", input.TicketType + "MinLot", input.TicketType + "MaxLot");

                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        var affectedRowId = await conn.ExecuteScalarAsync(sQuery,
                                    new
                                    {
                                        licencePlateId = input.LicencePlateId,
                                        name = input.Name,
                                        phone = input.Phone,
                                        ticketType = ((int)(input.TicketType)),
                                        vehicleType = input.VehicleType,
                                        vehicleHeight = input.VehicleHeight,
                                        vehicleLength = input.VehicleLength,
                                        vehicleWidth = input.VehicleWidth
                                    }, transaction);
                        transaction.Commit();
                    }
                    _logger.Debug($"CheckIn ('{input}')  result={true}");

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckIn('{input}')  failed");
                throw ex;
            }
        }


        public async Task<bool> CheckOut(string licencePlateId)
        {
            try
            {
                var sQuery = @"DELETE FROM ParkingLots WHERE LicencePlateId = @licencePlateId";

                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    var affectedRowId = await conn.ExecuteScalarAsync(sQuery, new { licencePlateId = licencePlateId });
                    _logger.Debug($"CheckOut ('{licencePlateId}')  result={affectedRowId}");

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckOut('{licencePlateId}')  failed");
                throw ex;
            }
        }
        /// <summary>
        /// This function Gets the Vehicles list from the ParkingLots By TicketType.
        /// </summary>
        /// <param name="ticketType">use to filter vehicles in ParkingLots-Table.</param>
        /// <returns>the vehicles list that parking in the ParkingLots filter by ticketType. if ticketType is null => return all the Vehicles</returns>
        public async Task<string> GetVehiclesByTicketType(int? ticketType)
        {
            try
            {
                DynamicParameters _params = new DynamicParameters();

                using (IDbConnection conn = Connection)
                {
                    if (ticketType.HasValue)
                    {
                        _params.Add("ticketType", ticketType.Value, direction: ParameterDirection.Input);
                    }
                    _params.Add("jsonResult", "", direction: ParameterDirection.Output);
                    var result = await conn.ExecuteAsync("GetVehiclesByTicketType", _params, commandType: CommandType.StoredProcedure);
                    var retVal = _params.Get<string>("jsonResult");
                    _logger.Debug($"GetVehiclesByTicketType ('{ticketType}')  result={retVal}");

                    return retVal;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"GetVehiclesByTicketType('{ticketType}')  failed");
                throw ex;
            }
        }

    }
}
