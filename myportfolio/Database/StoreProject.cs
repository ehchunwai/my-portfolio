using myportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myportfolio.Database
{
    public interface IStoreProject
    {
        public List<Project> GetProjectList(Guid uid);
    }

    public class StoreProject : IStoreProject
    {
        List<Project> _projectList = new List<Project>();

        public StoreProject()
        {
            _projectList = new List<Project>() {
            new Project() {Name = "Railway", ImagePath = "/media/railway/mrt.jpg", Description = "Developed passenger information display system (PIDS) and public announcement systems (PAS) for KTMB's IPBDT and KVMRT's Line 2 (SSP).", ProfileId = System.Guid.Empty },
            new Project(){ Name = "Highway", ImagePath = "/media/highway/thai.jpg", Description = "Developed a total solution which integrates all systems inside a highway control room into one system.", ProfileId = System.Guid.Empty },
            new Project(){ Name = "Guard and gated", ImagePath ="/media/guard-gated/software.jpg", Description = "Developed a total solution which integrates all systems inside a guard and gated control room into one system.", ProfileId = System.Guid.Empty } };
        }

        public List<Project> GetProjectList(Guid uid)
        {
            return _projectList.Where(t => t.ProfileId == uid).ToList();
        }
    }
}
