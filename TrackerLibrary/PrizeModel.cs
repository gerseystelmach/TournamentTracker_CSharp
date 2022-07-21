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

        public PrizeModel()
        {

        }
        /// <summary>
        /// This constructor process the data recovered as string and convert it to the expected model properties types. 
        /// </summary>
        /// <param name="placeNumber"></param>
        /// <param name="placeName"></param>
        /// <param name="prizeAmount"></param>
        /// <param name="prizePercentage"></param>
        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {
          
            PlaceName = placeName;
           
            int placeNumberValue = 0;
            // If the parse goes wrong, the placeNumberValue will remain 0.
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }


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
