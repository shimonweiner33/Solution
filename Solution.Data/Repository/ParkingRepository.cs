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
    class ParkingRepository : BaseRepository, IParkingRepository
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
                                SET @capacity = (select {0} from ParkingLots)
                                DECLARE @occupy INT
                                SET @occupy = (select count(LicencePlateId) from Vehicles where TicketType = @ticketType)

                                IF(@capacity > @occupy AND 
                                    NOT EXISTS (SELECT * FROM Vehicles WHERE LicencePlateId = @licencePlateId)
                                )
                                BEGIN
                                      INSERT INTO Vehicles(LicencePlateId, Name, Phone, TicketType, VehicleType, VehicleHeight, VehicleWidth, VehicleLength)
                                      VALUES(@licencePlateId, @name, @phone, @ticketType, @vehicleType, @vehicleHeight, @vehicleLength, @vehicleWidth);
                                END 
                                ", input.TicketType + "Capacity");

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
                var sQuery = @"DELETE FROM Vehicles WHERE LicencePlateId = @licencePlateId";

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
        /// This function Gets the Vehicles list By TicketType.
        /// </summary>
        /// <param name="ticketType">use to filter vehicles in Vehicles-Table.</param>
        /// <returns>vehicles list filter by ticketType. if ticketType is null => return all the Vehicles</returns>
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
