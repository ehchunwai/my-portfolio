using myportfolio.Database;
using myportfolio.Models;
using System;
using System.Collections.Generic;

namespace myportfolio.Modules
{
    public class SkillsService
    {
        IStoreSkills _storeSkills = null;

        public SkillsService(IStoreSkills storeSkills)
        {
            _storeSkills = storeSkills;
        }

        public List<SkillModel> GetSkillList()
        {
            try
            {
                var result = _storeSkills.GetSkillsList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<SkillModel>();
            }
        }
    }
}
