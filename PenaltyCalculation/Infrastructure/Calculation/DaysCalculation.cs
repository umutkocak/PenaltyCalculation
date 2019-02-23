using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PenaltyCalculation.Infrastructure.Dto;
using PenaltyCalculation.Models;

namespace PenaltyCalculation.Infrastructure.Calculation
{
    public class DaysCalculation
    {
        public readonly PriceCalculation PriceCalculation = new PriceCalculation();

        private readonly PenaltyContext _context = new PenaltyContext();
        public CalculationDto GetDays(DateTime deliveryDate, DateTime returnDate,
            List<DateTime> holidaysDate, int countryId, string ofDay1, string ofDay2)
        {
            bool IsGetDay(int days)
            {
                var currentDate = deliveryDate.AddDays(days);
                var isNonGetDay = currentDate.DayOfWeek == (DayOfWeek)System.Enum.Parse(typeof(DayOfWeek), ofDay1) ||
                                  currentDate.DayOfWeek == (DayOfWeek)System.Enum.Parse(typeof(DayOfWeek), ofDay2) ||
                                  holidaysDate.Exists(excludedDate => excludedDate.Date.Equals(currentDate.Date));
                return !isNonGetDay;
            }

            var result = Enumerable.Range(0, (returnDate.AddDays(+1) - deliveryDate).Days).Count(IsGetDay);
            
            return new CalculationDto()
            {
                HolidaysDate = holidaysDate,
                DeliveryDate = deliveryDate,
                ReturnedDate = returnDate,
                Country = _context.Country.FirstOrDefault(x=> x.Id == countryId)?.Name,
                CountryId = countryId,
                Calculation = PriceCalculation.DaysBetween(deliveryDate, returnDate, countryId),
                TotalDay = result
            };
        }
    }
}