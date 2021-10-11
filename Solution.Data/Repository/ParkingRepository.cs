using Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Solution.Common.Enums;
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

        //public async Task<string> GetVehiclesByTicketType(int? ticketType)

        public async Task<bool> CheckIn(CheckInDetails input)
        {
            try
            {
                DynamicParameters _params = new DynamicParameters();

                using (IDbConnection conn = Connection)
                {
                    _params.Add("licencePlateId", input.LicencePlateId, direction: ParameterDirection.Input);
                    _params.Add("name", input.Name, direction: ParameterDirection.Input);
                    _params.Add("phone", input.Phone, direction: ParameterDirection.Input);
                    _params.Add("ticketType", (int)input.TicketType, direction: ParameterDirection.Input);
                    _params.Add("ticketTypeName", ((TicketTypes)input.TicketType).ToString(), direction: ParameterDirection.Input);
                    _params.Add("vehicleType", (int)input.VehicleType, direction: ParameterDirection.Input);
                    _params.Add("vehicleTypeName", ((VehicleTypes)input.VehicleType).ToString(), direction: ParameterDirection.Input);
                    _params.Add("vehicleHeight", input.VehicleHeight, direction: ParameterDirection.Input);
                    _params.Add("vehicleWidth", input.VehicleWidth, direction: ParameterDirection.Input);
                    _params.Add("vehicleLength", input.VehicleLength, direction: ParameterDirection.Input);

                    var result = await conn.ExecuteAsync("CheckIn", _params, commandType: CommandType.StoredProcedure);
                    
                    _logger.Debug($"CheckIn ('{input}')  result={result}");

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"CheckIn('{input}')  failed");
                throw ex;
            }
        }
        //public async Task<bool> CheckIn(CheckInDetails input)
        //{
        //    var sQuery = string.Format(@"
        //                        DECLARE @capacity INT
        //                        SET @capacity = (select {0} from Params)
        //                        DECLARE @minLot INT
        //                        SET @minLot = (select {1} from Params)
        //                        DECLARE @maxLot INT
        //                        SET @maxLot = (select {2} from Params)

        //                        DROP TABLE IF EXISTS #Temp

        //                        CREATE TABLE #Temp
        //                        (
        //                            LotNumber int
        //                        )
        //                        INSERT INTO #Temp
        //                        SELECT LotNumber FROM Vehicles WHERE TicketType = @ticketType
        //                        ---------------
        //                        DECLARE @lot INT;
        //                        SET @lot = @minLot;

        //                        DECLARE @lotFound BIT;
        //                        SET @lotFound = 0;

        //                        WHILE @lot <= @maxLot AND @lotFound = 0
        //                        BEGIN
        //                           IF(@lot NOT IN (select LotNumber from #Temp))
        //                        		BEGIN
        //                        				PRINT @lot
        //                        				SET @lotFound = 1
        //                        		END
        //                           ELSE
        //                        		BEGIN
        //                        				SET @lot = @lot + 1;
        //                        		END
        //                        END;


        //                        DECLARE @occupy INT
        //                        SET @occupy = (select count(LicencePlateId) from Vehicles where TicketType = @ticketType)

        //                        IF(@capacity > @occupy AND 
        //                            NOT EXISTS (SELECT * FROM Vehicles WHERE LicencePlateId = @licencePlateId)
        //                        )
        //                        BEGIN
        //                              INSERT INTO Vehicles(LicencePlateId, Name, Phone, TicketType, VehicleType, VehicleHeight, VehicleWidth, VehicleLength, LotNumber)
        //                              VALUES(@licencePlateId, @name, @phone, @ticketType, @vehicleType, @vehicleHeight, @vehicleLength, @vehicleWidth, @lot);
        //                        END 
        //                        ", input.TicketType + "Capacity", input.TicketType + "MinLot", input.TicketType + "MaxLot");

        //    using (IDbConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (var transaction = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                var affectedRowId = await conn.ExecuteScalarAsync(sQuery,
        //                        new
        //                        {
        //                            licencePlateId = input.LicencePlateId,
        //                            name = input.Name,
        //                            phone = input.Phone,
        //                            ticketType = ((int)(input.TicketType)),
        //                            vehicleType = input.VehicleType,
        //                            vehicleHeight = input.VehicleHeight,
        //                            vehicleLength = input.VehicleLength,
        //                            vehicleWidth = input.VehicleWidth
        //                        }, transaction);
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                _logger.Error(ex, $"CheckIn('{input}')  failed");

        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //        _logger.Debug($"CheckIn ('{input}')  result={true}");

        //        return true;
        //    }
        //}


        public async Task<bool> CheckOut(string licencePlateId)
        {
            try
            {
                var sQuery = @"
                                BEGIN TRY
                                	BEGIN TRAN T1;
                                
                                		DECLARE @deletedTBL TABLE  
                                		(  
                                		    LotNumber INT 
                                		);
                                		DELETE FROM Vehicles 
                                		OUTPUT DELETED.LotNumber INTO @deletedTBL  
                                		WHERE LicencePlateId = @licencePlateId
                                		
                                		UPDATE ParkingLots
                                		SET Status = 0
                                		WHERE LotNumber = (select LotNumber from @deletedTBL)
                                
                                	COMMIT TRAN T1; 
                                END TRY
                                
                                BEGIN CATCH
                                	ROLLBACK
                                END CATCH
                                ";

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
        /// <param name="ticketType">use to filter vehicles in Vehicles-Table.</param>
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
                    _params.Add("jsonResult", "", direction: ParameterDirection.Output, size: int.MaxValue);
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
