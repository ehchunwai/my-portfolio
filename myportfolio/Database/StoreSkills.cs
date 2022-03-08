using myportfolio.Models;
using System;
using System.Collections.Generic;

namespace myportfolio.Database
{
    public interface IStoreSkills
    {
        List<SkillModel> GetSkillsList();
    }

    public class StoreSkills : IStoreSkills
    {
        List<SkillModel> _skillList = new List<SkillModel>();

        public StoreSkills()
        {
            //dummy data
            _skillList = new List<SkillModel>() {
            new SkillModel() {Language = "HTML", Level = 75 },
             new SkillModel() {Language = "CSS", Level = 50 },
            new SkillModel() {Language = "Javascript, jQuery, TypeScript ", Level = 75 },
            new SkillModel() {Language = "C#", Level = 75 },
            new SkillModel() {Language = "VB.NET", Level = 75 },
            new SkillModel() {Language = "Microsoft SQL Server", Level = 75, Type = TypeValues.Database },
            new SkillModel() {Language = "PostgreSQL", Level = 50 , Type = TypeValues.Database},};
        }

        public List<SkillModel> GetSkillsList()
        {
            try
            {
                return _skillList;
            }
            catch (Exception ex)
            {
                return new List<SkillModel>();
            }
        }
    }
}
