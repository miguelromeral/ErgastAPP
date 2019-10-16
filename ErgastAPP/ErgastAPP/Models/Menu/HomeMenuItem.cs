using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Menu item. Its instances will be displayed on the MasterPageDetail menu.
    /// </summary>
    public class HomeMenuItem
    {
        /// <summary>
        /// URL image from the icon.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Menu ID.
        /// <seealso cref="MenuItemType"/>
        /// </summary>
        public MenuItemType Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
    }
}
