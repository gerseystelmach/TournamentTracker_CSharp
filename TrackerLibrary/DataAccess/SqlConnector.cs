using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {

        private const string databaseName = "Tournaments";

        /// <summary>
        /// Saves a new person into the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Person object, including the unique identifier (ID).</returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // It will open the connection to database and then close it, so it avoids memory leeks.  
            using (IDbConnection connection = new SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {
                var param = new DynamicParameters();
   
                // Replacing the parameters by the values of the PersonModel object.
                param.Add("@FirstName", model.FirstName);
                param.Add("@LastName", model.LastName);
                param.Add("@EmailAddress", model.EmailAddress);
                param.Add("@CellphoneNumber", model.CellphoneNumber);
              
                param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Executing the insert query created in the storage procedure. 
                connection.Execute("dbo.spPeople_Insert", param, commandType: CommandType.StoredProcedure);

                // Recovering the Id created in the stored procedure scope, when inserting the object into db
                model.Id = param.Get<int>("@id");

                return model;
            }
        }

        // TODO - Make the CreatePrize method actually save to the database.
        /// <summary>
        /// Saves a new prize into the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Prize object, including the unique identifier (ID).</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // It will open the connection to database and then close it, so it avoids memory leeks.  
            using (IDbConnection connection = new SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {
                var param = new DynamicParameters();
      
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

        /// <summary>
        /// Creates a new Team, handling the data creation of two differents tables (Team and TeamMembers) that are related.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            // It will open the connection to database and then close it, so it avoids memory leeks.  
            using (IDbConnection connection = new SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {
                var param = new DynamicParameters();

                // Creating a Team Name and its Id

                param.Add("@TeamName", model.TeamName);
                param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // It will creates a team into the table Teams
                connection.Execute("dbo.spTeams_Insert", param, commandType: CommandType.StoredProcedure);

                model.Id = param.Get<int>("@id");

                // Creating a list of all members of a team

                foreach (PersonModel teamMember in model.TeamMembers)
                {
                    param = new DynamicParameters();
                    if (teamMember != null)
                    {
                        param.Add("@TeamId", model.Id);
                        param.Add("@PersonId", teamMember.Id);

                        // It will creates a member into table TeamMembers for each Person object in the TeamMembers list. 
                        connection.Execute("dbo.spTeamMembers_Insert", param, commandType: CommandType.StoredProcedure);

                    }
                }
                return model;
            }
        }


        /// <summary>
        /// Query the database to recover all data from table Person.
        /// </summary>
        /// <returns>List of PersonModel.</returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return output;
        }
    }
}
