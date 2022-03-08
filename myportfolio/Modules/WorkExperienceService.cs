using myportfolio.Database;
using myportfolio.Models;
using System;
using System.Collections.Generic;

namespace myportfolio.Modules
{
    public class WorkExperienceService
    {
        private IStoreWorkExperience _storeWorkExperience = null;

        public WorkExperienceService(IStoreWorkExperience storeWorkExperience)
        {
            _storeWorkExperience = storeWorkExperience;
        }

        public List<MilestoneModel> GetWorkExperienceList(Guid uid)
        {
            var result = _storeWorkExperience.GetWorkExperienceList(uid);
            return result;
        }

        public void UpdateCurrentWorkExperience()
        {
            DateTime now = DateTime.Now;
            //now = now.AddYears(1);
            _storeWorkExperience.UpdateCurrentWorkExperience(now);
        }
    }
}
