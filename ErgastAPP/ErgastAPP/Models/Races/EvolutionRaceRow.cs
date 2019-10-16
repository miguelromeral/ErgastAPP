using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Custom row that allows display the Race evolution based on drivers laps for a race.
    /// </summary>
    public class EvolutionRaceRow
    {
        /// <summary>
        /// Time set in the lap.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Current position for the driver in the lap.
        /// </summary>
        public int Position { get; set; }
        
        /// <summary>
        /// Driver who made the time.
        /// <seealso cref="Driver"/>
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Constructor that made the time.
        /// <seealso cref="Constructor"/>
        /// </summary>
        public Constructor Constructor { get; set; }
    }
}
