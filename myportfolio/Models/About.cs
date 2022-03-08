using System;
using System.Collections.Generic;

namespace myportfolio.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string Quote { get; set; }
        public string Age { get { return GetAge(); } }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<string> LanguageList { get; set; }
        public DateTime DOB { get; set; }
        public int NoOfProjectCompleted { get; set; }
        public string SkillsOverview { get; set; }
        public List<string> OtherList { get; set; }

        public string GetAge()
        {
            var endDate = DateTime.Now;
            var startDate = this.DOB;

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

            string age = "";

            if (years > 0 && months > 0)
            {
                age = years + " years " + months + " months";
            }
            else if (years > 0 && months == 0)
            {
                age = years + " years ";
            }
            return age;
        }
    }
}
