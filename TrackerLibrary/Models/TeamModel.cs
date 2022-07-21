using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models

{
    /// <summary>
    /// Represents a team that may participate in a matchup.
    /// </summary>
    public class TeamModel
    {

        /// <summary>
        /// Represents the people that belongs to a team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();  // Other way to instantiate instead of using a constructor. 
        /// <summary>
        /// Represents the name of the team.
        /// </summary>
        public string TeamName { get; set; }
    }
}
