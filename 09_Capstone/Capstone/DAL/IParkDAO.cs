using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Gets all parks
        /// </summary>
        /// <returns></returns>
        IList<Park> GetParks();
    }
}
