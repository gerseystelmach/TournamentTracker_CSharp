using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreatePrize method actually save to the database.
        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The prize information, including the unique identifier (ID).</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // It will open the connection to database and then close it, so it avoids memory leeks.  
            using (IDbConnection connection = new SqlConnection(GlobalConfig.getConnectionString("Tournaments")))
            {
                var param = new DynamicParameters();
                StringBuilder errorMessages = new StringBuilder();

                // Replacing the parameters by the values of the PrizeModel object.
                param.Add("@PlaceNumber", model.PlaceNumber);
                param.Add("@PlaceName", model.PlaceName);
                param.Add("@PrizeAmount", model.PrizeAmount);
                param.Add("@PrizePercentage", model.PrizePercentage);
                param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Executing the insert query created in the storage procedure. 
                connection.Execute("dbo.spPrizes_Insert", param, commandType: CommandType.StoredProcedure);

                // Recovering the Id created in the stored procedure scope, when inserting the object into db
                model.Id = param.Get<int>("@id");

                return model;
            }
        }
    }
}
