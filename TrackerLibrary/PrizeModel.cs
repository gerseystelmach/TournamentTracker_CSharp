using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a prize from a tournment. 
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// Represents the unique identifier of the prize.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the required place for the prize. 
        /// </summary>
        /// <example>1 = 1st place.</example>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Represents a specified name for the place, if it is called differently than just the place number.
        /// </summary>
        /// <example>The 1st place is called "champion".</example>
        public string PlaceName { get; set; }
        /// <summary>
        /// Represents a fixed amount of money assigned for the prize. 
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Represents a percentage of the fixed prize amount. It is an alternative of Prize to the PrizeAmount. 
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
