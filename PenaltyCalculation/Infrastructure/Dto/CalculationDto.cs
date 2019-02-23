using System;
using System.Collections.Generic;

namespace PenaltyCalculation.Infrastructure.Dto
{
    /// <summary>
    /// The data transfer object is used for calculation.
    /// </summary>
    public class CalculationDto
    {
        /// <summary>
        /// Date of receipt of the book.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// The date on which the book was returned.
        /// </summary>
        public DateTime ReturnedDate { get; set; }

       /// <summary>
        /// User-selected country Id
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// User-selected country information.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Days and public holidays by country.
        /// </summary>
        public List<DateTime> HolidaysDate { get; set; }

        /// <summary>
        /// Total Day
        /// </summary>
        public double TotalDay { get; set; }

        public PriceDto Calculation { get; set; }
    }
}