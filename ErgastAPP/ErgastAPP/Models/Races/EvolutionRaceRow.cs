using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{

    public class EvolutionRaceRow
    {
        public string Time { get; set; }
        public int Position { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
    }
}
