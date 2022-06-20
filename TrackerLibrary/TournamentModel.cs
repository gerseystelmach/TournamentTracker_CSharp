using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents all the information from a tournament. 
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// Represents the tournament name.
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Represents the required fee to participate into the tournament. As it is related to money, the decimal type is more precise than double. 
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// Represents the teams that participates in the tournament.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// Represents the prizes that may be offered for the tournament.
        /// </summary>
       public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// Represents the matchups (team x team) participating in each round. 
        /// The first list represents the rounds and for each round we have a list of matchups. 
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();


    }
}
