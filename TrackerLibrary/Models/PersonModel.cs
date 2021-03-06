using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the person.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the lastname of the person.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the e-mail address of the person.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Represents the celphone number of the person.
        /// </summary>
        public string CellphoneNumber { get; set; }

        public string FullName
        {
            get 
            {
                return $"{ FirstName } { LastName }";
            }
        }

    }
}
