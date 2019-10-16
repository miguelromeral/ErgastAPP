using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Type of menu links.
    /// </summary>
    public enum MenuItemType
    {
        /// <summary>
        /// Home Menu. Begining of the application.
        /// </summary>
        Home,
        /// <summary>
        /// List of seasons and its champions.
        /// </summary>
        Seasons,
        /// <summary>
        /// List of all races.
        /// </summary>
        Races,
        /// <summary>
        /// List of all circuits.
        /// </summary>
        Circuits,
        /// <summary>
        /// List of all drivers.
        /// </summary>
        Drivers,
        /// <summary>
        /// List of all constructors.
        /// </summary>
        Constructors,
        /// <summary>
        /// About page. Application information.
        /// </summary>
        About
    }
}
