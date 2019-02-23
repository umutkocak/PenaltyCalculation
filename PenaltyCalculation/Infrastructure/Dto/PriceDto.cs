using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PenaltyCalculation.Infrastructure.Dto
{
    public class PriceDto
    {
        /// <summary>
        /// Calculated Business Days
        /// </summary>
        public double BusinessDay { get; set; }

        /// <summary>
        /// Calculated penalty
        /// </summary>
        public string Penalty { get; set; }

      
    }
}