using SirmaTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Repository
{
    public interface IProjectRepository : IDisposable  
    {
        IEnumerable<Project> GetProjects();
        void FetchProjects(DataTable datatTable);
        bool UpdateProject(Project OldPRoject, Project newProject);
        Project FindProjectByID(int ID);
        void AddProjects(List<Project> projectLSt);
    }
}
