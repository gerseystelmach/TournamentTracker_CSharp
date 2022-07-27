using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// This method recovers the filePath from App.config and returns it with the @param fileName.
        /// </summary>
        /// <param name="fileName">As a extension method.</param>
        /// <returns>The filePath indicated in AppSettings with the filename.</returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        /// <summary>
        /// Load a text file and returns a list with all file lines or an empty list if the file does not exist.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// It loops a List of lines, splits each line separated by a comma and transform the substrings into a PrizeModel object attributes. 
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>A list of PrizeModel objects. </returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                PrizeModel p = new PrizeModel();

                // Trying to convert a string to an int, otherwise it will crash. 
                p.Id = int.Parse(columns[0]);
                p.PlaceNumber = int.Parse(columns[1]);
                p.PlaceName = columns[2];
                p.PrizeAmount = decimal.Parse(columns[3]);
                p.PrizePercentage = double.Parse(columns[4]);

                output.Add(p);
            }
            return output;           
        }

        /// <summary>
        /// It loops a List of lines, splits each line separated by a comma and transform the substrings into a PersonModel object attributes. 
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>A list of PersonModel objects. </returns>
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                PersonModel p = new PersonModel();

                // Trying to convert a string to an int, otherwise it will crash. 
                p.Id = int.Parse(columns[0]);
                p.FirstName = columns[1];
                p.LastName = columns[2];
                p.EmailAddress = columns[3];
                p.CellphoneNumber = columns[4];

                output.Add(p);
            }
            return output;
        }

        /// <summary>
        /// It loops a List of string lines, splits each line separated by a comma and transform the substrings into a TeamModel object attributes. 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="peopleFileName">A file containing PeopleModels.</param>
        /// <returns></returns>
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();

            // Loading the PeopleFile and convert the text to List<PersonModel>
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                TeamModel team = new TeamModel();

                team.Id = int.Parse(columns[0]);
                team.TeamName = columns[1];

                string[] teamMembersIds = columns[2].Split("|");

                foreach (string id in teamMembersIds)
                {
                    // Taking all the people in the text file,
                    // filtering by the id of the person when it equals the passed id,
                    // returning the first one found.
                    team.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
                output.Add(team); 
            }
            return output;
        }
        
        /// <summary>
        /// Writes a prize object into a flat file. 
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            // Converting object to string
            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.Id }, { p.PlaceNumber }, { p.PlaceName }, { p.PrizeAmount }, { p.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Writes a Person object into a flat file. 
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            // Converting object to string
            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id}, {p.FirstName}, {p.LastName}, {p.EmailAddress}, {p.CellphoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Save a list of TeamModels into a flat file.
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            // Converting object to string
            foreach (TeamModel t in models)
            {
                lines.Add($"{t.Id}, {t.TeamName}, { convertPeopleListToString(t.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Transform a list of PersonModel into a string containing only the Id of each object.
        /// </summary>
        /// <param name="people"> </param>
        /// <param name="separator">Character to separate each element.</param>
        /// <returns>String with the Persons Ids separated by the separator.</returns>
        private static string convertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }

            foreach (PersonModel person in people)
            {
                output += $"{ person.Id }|";
            }

            // Taking out the last pipe from the string
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModels(
        this List<string> lines,
        string teamFileName,
        string peopleFileName,
        string prizeFileName)
        {
            //id, tournamentname, entryfee, (id|id|id - enteredTeams), (id|id|id - prizes), (Rounds - id^id^id|id^id^id|id^id^id)

            List<TournamentModel> output = new List<TournamentModel>();
            // Converting a file containing PeopleModels into TeamModel Object. 
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                TournamentModel tournamentModel = new TournamentModel();

                tournamentModel.Id = int.Parse(columns[0]);
                tournamentModel.TournamentName = columns[1];
                tournamentModel.EntryFee = decimal.Parse(columns[2]);

                string[] teamIds = columns[3].Split("|");

                foreach (string id in teamIds)
                {
                    // Taking all the people in the text file,
                    // filtering by the id of the person when it equals the passed id,
                    // returning the first one found.
                    tournamentModel.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                string[] prizesIds = columns[4].Split("|");

                foreach (string id in prizesIds)
                {
                    tournamentModel.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(tournamentModel);
            }
            return output;
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tournament in models)
            {
                lines.Add($@"{ tournament.Id },
                         { tournament.TournamentName },
                         { tournament.EntryFee },
                         { ConvertTeamListToString(tournament.EnteredTeams) }
                         { ConvertPrizesToString(tournament.Prizes) },
                         { ConvertRoundListToString(tournament.Rounds) }
                         ");
            }

            File.WriteAllLines(fileName, lines);
        }

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0)
            {
                return "";
            }

            foreach (TeamModel team in teams)
            {
                output += $"{team.Id}|";
            }

            // Taking out the last pipe from the string
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        /// <summary>
        /// Converting a list of PrizesModel into a string.
        /// </summary>
        /// <param name="prizes"></param>
        /// <returns></returns>
        private static string ConvertPrizesToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0)
            {
                return "";
            }

            foreach (PrizeModel prize in prizes)
            {
                output += $"{prize.Id}|";
            }

            // Taking out the last pipe from the string
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        /// <summary>
        /// Converts a List of a List of MatchupModel into String.
        /// </summary>
        /// <param name="rounds"></param>
        /// <returns></returns>
        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";

            if (rounds.Count == 0)
            {
                return "";
            }

            foreach (List<MatchupModel> round in rounds)
            {
                output += $"{ ConvertMatchupListToString(round) }|";
            }

            // Taking out the last pipe from the string
            output = output.Substring(0, output.Length - 1);

            return output;
        }

        /// <summary>
        /// Converts a MatchupList into a string.
        /// </summary>
        /// <param name="matchups"></param>
        /// <returns></returns>
        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = "";

            if (matchups.Count == 0)
            {
                return "";
            }

            foreach (MatchupModel matchup in matchups)
            {
                output += $"{ matchup.Id }^";
            }

            // Taking out the last pipe from the string
            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
