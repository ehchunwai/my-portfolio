using myportfolio.Database;
using myportfolio.Models;
using System;
using System.Collections.Generic;

namespace myportfolio.Modules
{
    public class ProjectService
    {
        IStoreProject _storeProject = null;

        public ProjectService(IStoreProject storeProject)
        {
            _storeProject = storeProject;
        }

        public List<Project> GetProjectListByUid(Guid uid)
        {
            var result = _storeProject.GetProjectList(uid);
            return result;
        }
    }
}
