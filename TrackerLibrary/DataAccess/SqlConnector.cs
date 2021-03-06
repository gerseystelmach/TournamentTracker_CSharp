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

        private static DynamicParameters param = new DynamicParameters();

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
        /// Responsible to save a tournament in database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {

                SaveTournamentIntoDb(connection, model);

                SaveTournamentPrizesIntoDb(connection, model.Prizes);

                SaveTournamentEnteredTeamsIntoDb(connection, model.EnteredTeams);

            }
        }

        /// <summary>
        /// Save a Tournament into database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="model"></param>
        private void SaveTournamentIntoDb(IDbConnection connection, TournamentModel model)
        {     
            param.Add("@TournamentName", model.TournamentName);
            param.Add("@EntryFee", model.EntryFee);
            param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", param, commandType: CommandType.StoredProcedure);

            model.Id = param.Get<int>("@id");
        }

        /// <summary>
        ///  Save the Prizes atributte of a Tournament into database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tournamentPrizes"></param>
        private void SaveTournamentPrizesIntoDb(IDbConnection connection, List<PrizeModel> tournamentPrizes)
        {
            foreach (PrizeModel prize in tournamentPrizes)
            {                
                param.Add("@TournamentId", prize.Id);
                param.Add("@PrizeId", prize.Id);
                param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentPrizes_Insert", param, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Save the enteredTeams atributte of a Tournament into database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enteredTeams"></param>
        private void SaveTournamentEnteredTeamsIntoDb(IDbConnection connection, List<TeamModel> enteredTeams)
        {
            foreach (TeamModel team in enteredTeams)
            {               
                param.Add("@TournamentId", team.Id);
                param.Add("@TeamId", team.Id);
                param.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentEntries_Insert", param, commandType: CommandType.StoredProcedure);

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

        /// <summary>
        /// Query the database to recover all data from table Teams.
        /// </summary>
        /// <returns>List of TeamModel.</returns>
        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.getConnectionString(databaseName)))
            {
                // Getting all teams in db
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    // Creating the parameter for the query in stored procedure
                    var param = new DynamicParameters();
                    param.Add("@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }

    } 
}

