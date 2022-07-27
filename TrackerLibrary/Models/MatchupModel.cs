using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents a matchup from the tournament. Which means, one team vs another. 
    /// </summary>
    public class MatchupModel
    {

        /// <summary>
        /// Represents the unique identifier of the matchup.
        /// </summary>
        public int Id { get; set; }
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        public TeamModel Winner { get; set; }
        public int MatchupRound { get; set; }
    }
}
