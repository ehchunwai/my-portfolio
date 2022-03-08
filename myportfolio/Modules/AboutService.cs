using myportfolio.Database;
using myportfolio.Models;
using System;
using System.Linq;

namespace myportfolio.Modules
{
    public class AboutService
    {
        IStoreProfile _storeProfile = null;
        IStoreWorkExperience _storeWorkExperience = null;

        public AboutService(IStoreProfile storeProfile, IStoreWorkExperience storeWorkExperience)
        {
            _storeProfile = storeProfile;
            _storeWorkExperience = storeWorkExperience;
        }

        public Profile GetProfileByUid(Guid uid)
        {
            var result = _storeProfile.GetProfile(uid);

            return result;
        }

        public int GetYearsInService(Guid uid)
        {
            var now = DateTime.Now;

            var result = _storeWorkExperience.GetWorkExperienceList(uid);
            var tmp = result.OrderBy(t => t.YearFrom).FirstOrDefault();

            var yearsInService = GetYearsInService(tmp.YearFrom, now);
            return yearsInService;
        }

        private int GetYearsInService(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            int years = endDate.Year - startDate.Year;
            int months = 12 - startDate.Month + (years - 1) * 12 + endDate.Month;
            if (startDate.AddYears(years) > endDate)
                years--;
            return years;
        }
    }
}
