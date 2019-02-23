using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PenaltyCalculation.Infrastructure.Calculation;
using PenaltyCalculation.Infrastructure.Dto;
using PenaltyCalculation.Models;

namespace PenaltyCalculation.Controllers
{
    public class HomeController : Controller
    {
 
        public DaysCalculation DaysCalculation = new DaysCalculation();
        private PenaltyContext _context = new PenaltyContext();

        public ActionResult Index()
        {
            return View();
        }

        [Route("calculation")]
        public ActionResult Calculation(CalculationDto data)
        {
            data.HolidaysDate = new List<DateTime>();
            var holidayList = _context.Holiday.Where(x => x.CountryId == data.CountryId).AsNoTracking().ToList();
            foreach (var i in holidayList)
            {
                data.HolidaysDate.Add(Convert.ToDateTime(i.Date));
            }

            var enums = new List<string>();
            foreach (var i in _context.WorkDay.Where(x => x.CountryId == data.CountryId).AsNoTracking().ToList())
            {
                enums.Add(i.Day);
            }
            var ofDay1 = enums[0];
            var ofDay2 = enums[1];

            var getDays = DaysCalculation.GetDays(data.DeliveryDate, data.ReturnedDate, data.HolidaysDate, data.CountryId, ofDay1, ofDay2);

            return Json(new { data = getDays }, JsonRequestBehavior.AllowGet);
        }

    }
}