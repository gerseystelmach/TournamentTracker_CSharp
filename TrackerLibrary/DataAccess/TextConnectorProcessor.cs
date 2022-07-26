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
        /// It loops a List of lines, splits each line separated by a comma and transform the substrings into a TeamModel object attributes. 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="peopleFileName"></param>
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

    }
}
