using System;
using System.Collections.Generic;
using System.Globalization;

namespace myportfolio.Models
{
    public class MilestoneModel
    {
        public string Year { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public List<string> PointFormList { get; set; } = new List<string>();
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public string RelativeDate { get; set; }
        public bool IsCurrent { get; set; } = false;
        public Guid ProfileId { get; set; }

        public void Init()
        {
            DateTime now = DateTime.Now;
            string monthFrom = YearFrom.ToString("MMM", CultureInfo.InvariantCulture);
            string monthTo = YearTo.ToString("MMM", CultureInfo.InvariantCulture);

            //Feb 2012 – Jul 2013
            if (YearTo.Date == new DateTime(now.Year, now.Month, now.Day).Date)
            {
                Year = string.Format("{0} {1} - Present", monthFrom, YearFrom.Year);
            }
            else
            {
                Year = string.Format("{0} {1} - {2} {3}", monthFrom, YearFrom.Year, monthTo, YearTo.Year);
            }


            DateTime endDate = YearTo;
            DateTime startDate = YearFrom;

            TimeSpan timeSpan = endDate - startDate;
            int years = endDate.Year - startDate.Year;
            int months = 12 - startDate.Month + (years - 1) * 12 + endDate.Month;
            if (startDate.AddYears(years) > endDate)
                years--;
            startDate = startDate.AddYears(years);

            if (startDate.Year == endDate.Year)
                months = endDate.Month - startDate.Month;
            else months = 12 - startDate.Month + endDate.Month;
            if (startDate.AddMonths(months) > endDate)
                months--;
            string message = string.Empty;
            int weeks = timeSpan.Days / 7;
            int extraDay = timeSpan.Days % 7;
            startDate = startDate.AddDays(weeks * 7 + extraDay);

            timeSpan = endDate.Subtract(startDate);
            int days = timeSpan.Days;
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            if (years > 0 && months > 0 && days > 0)
            {
                message = years + " years " + months + " months " + days + " days";
            }
            else if (years > 0 && months > 0)
            {
                message = years + " years " + months + " months";
            }
            else if (years > 0 && months == 0)
            {
                message = years + " years ";
            }
            else if (months > 0 && days > 0)
            {
                message = months + " months " + days + " days";
            }
            else if (months > 0)
            {
                message = months + " months";
            }

            RelativeDate = message;
        }
    }
}
