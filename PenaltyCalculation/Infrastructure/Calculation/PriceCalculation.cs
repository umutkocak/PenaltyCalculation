using System;
using System.Globalization;
using System.Linq;
using PenaltyCalculation.Infrastructure.Dto;
using PenaltyCalculation.Models;

namespace PenaltyCalculation.Infrastructure.Calculation
{

    public class PriceCalculation
    {
        readonly PenaltyContext _context = new PenaltyContext();

        #region Fields

        private decimal _price = 5;
        private decimal _israelPrice = 2;

        #endregion

        #region Property
        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public decimal IsraelPrice
        {
            get => _israelPrice;
            set => _israelPrice = value;
        }

        #endregion

        public PriceDto DaysBetween(DateTime deliveryDate, DateTime returnDate, int countryId)
        {
            decimal totalPrice = 0;
            decimal totalPriceIsrael = 0;

            var countryName = _context.Country.FirstOrDefault(x => x.Id == countryId)?.Name;
            
            if (deliveryDate.AddDays(10) < returnDate)
            {
                totalPrice = Convert.ToDecimal((returnDate - deliveryDate.AddDays(10)).TotalDays) * Price;
                totalPriceIsrael = Convert.ToDecimal((returnDate - deliveryDate.AddDays(10)).TotalDays) * IsraelPrice;
            }
            else
            {
                totalPrice = 0;
                totalPriceIsrael = 0;
            }

            return new PriceDto
            {
                BusinessDay = Convert.ToInt32((returnDate - deliveryDate.AddDays(10)).TotalDays),
                Penalty = countryName == "Turkey" ? totalPrice.ToString("C", new CultureInfo("tr-TR")) : totalPriceIsrael.ToString("C", new CultureInfo("he-IL"))
            };

        }
    }
}