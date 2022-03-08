using myportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myportfolio.Database
{
    public interface IStoreWorkExperience
    {
        List<MilestoneModel> GetWorkExperienceList(Guid uid);

        void UpdateCurrentWorkExperience(DateTime now);
    }

    public class StoreWorkExperience : IStoreWorkExperience
    {
        List<MilestoneModel> _workExperienceList = new List<MilestoneModel>();

        public StoreWorkExperience()
        {
            DateTime now = DateTime.Now;

            _workExperienceList = new List<MilestoneModel>() {
            new MilestoneModel() {  Company = "Recogine Technology Sdn Bhd", Position = "Software Programmer", Description = "Maintain current projects by doing bug fixes and implementing modules to existing.", YearFrom = new DateTime(2012, 2, 21), YearTo = new DateTime(2013, 7, 31), PointFormList = new List<string>(){ "Maintain current projects by doing bug fixes and implementing modules to existing." } },

            new MilestoneModel() { Company = "Recogine Technology Sdn Bhd", Position = "Software Engineer", YearFrom = new DateTime(2013, 7, 31), YearTo = new DateTime(2015, 7, 31), Description = "Study project/business requirements and translating it to technical specifications. Taking more responsibility by embracing the role of becoming key person in projects." , PointFormList = new List<string>(){ "Study project/business requirements and translating it to technical specifications.", "Taking more responsibility by embracing the role of becoming key person in projects." } },

            new MilestoneModel() { Company = "Recogine Technology Sdn Bhd", Position = "Senior Software Engineer", YearFrom = new DateTime(2015, 7, 31), YearTo = new DateTime(2017, 7, 31) , Description = "Migrate from desktop applications to web applications. Introduce process and flow to reduce resource engineering works. Manage and mentored juniors on the “know how” on doing things.", PointFormList = new List<string>(){ "Migrate from desktop applications to web applications.", "Introduce process and flow to reduce resource engineering works.", "Manage and mentored juniors on the “know how” on doing things." } },

            new MilestoneModel() {  Company = "Recogine Technology Sdn Bhd", Position = "Lead Software Engineer", YearFrom = new DateTime(2017, 7, 31), YearTo = new DateTime(2021, 7, 31), Description = "Lead the team in delivering the project and at the same time product building in mind. Lead the design proposal by working with various parties on defining and implementing the requirements.", PointFormList = new List<string>(){ "Lead the team in delivering the project and at the same time product building in mind.", " Lead the design proposal by working with various parties on defining and implementing the requirements." } },

            new MilestoneModel() {  Company = "Recogine Technology Sdn Bhd", Position = "Assistant Manager (Applications)", YearFrom = new DateTime(2021, 7, 31), YearTo = new DateTime(now.Year, now.Month, now.Day) , Description = "Lead the team in product design using SAAS.", PointFormList = new List<string>(){ "Lead the team in product design using SAAS." }, IsCurrent = true  }};

            foreach (var item in _workExperienceList)
            {
                item.Init();
            }

            //_workExperienceList.Reverse();
            _workExperienceList = _workExperienceList.OrderBy(t => t.YearFrom).ToList();
        }

        public List<MilestoneModel> GetWorkExperienceList(Guid uid)
        {
            return _workExperienceList.Where(t => t.ProfileId == uid).ToList();
        }

        public void UpdateCurrentWorkExperience(DateTime now)
        {
            var tmp = _workExperienceList.Where(t => t.IsCurrent).FirstOrDefault();
            tmp.YearTo = new DateTime(now.Year, now.Month, now.Day);
            tmp.Init();
        }
    }
}
