using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";

        /// <summary>
        /// Create a new prize in a text file by finding the last id record in database. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Extension method is used to call these static methods, using the same parameter. 
            // It's the same of calling individually: TextConnectorProcessor.FullFilePath(PrizesFile);

            // Load the text file and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max id 
            int currentId = 1; 

            if (prizes.Count > 0)
            {
              currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // To be used in case of writing more than 1 ids in a row
            //currentId += 1;

            // Add the new record with the new Id (max + 1)
            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        /// <summary>
        ///  Create a new person in a text file by finding the last id record in database. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // Extension method is used to call all of these static methods, using the same parameter. 
            // It's the same of calling individually: TextConnectorProcessor.FullFilePath(PrizesFile);

            // Load the text file and convert the text to List<PersonModel>
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            // Find the max id 
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

             // Add the new record with the new Id (max + 1)
            people.Add(model);

            people.SaveToPersonFile(PeopleFile);

            return model;
        }

        /// <summary>
        /// Getting Person models from the PeopleFile.
        /// </summary>
        /// <returns></returns>
        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        /// <summary>
        ///  Create a new team in a text file by finding the last id record in database. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            // Load the text file and convert the text to List<PrizeModel>
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            // Find the max id 
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new Id (max + 1)
            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;

        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }


        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            tournaments.Add(model);

            tournaments.SaveToTournamentFile(TournamentFile);

        }
    }
}
