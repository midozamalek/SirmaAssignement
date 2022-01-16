using SirmaTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Repository
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private HashSet<Project> projects;

        public ProjectRepository()
        {
            this.projects = new HashSet<Project>();
        }

        public IEnumerable<Project> GetProjects()
        {
            return projects.ToList();
        }

        public void FetchProjects(DataTable datatTable)
        {
            for (int index = 0; index < datatTable.Rows.Count; index++)
            {
                var row = datatTable.Rows[index];
                Employee employee = FillEmployee(row);
                int projectId = Convert.ToInt32(row["ProjectID"]);
                Project existProject = FindProjectByID(projectId);
                Project currentProject = existProject == null ? new Project() : existProject;
                currentProject.Id = projectId;
                currentProject.employees.Add(employee);
                UpdateProject(existProject, currentProject);
            }
        }

        public void AddProjects(List<Project> projectLSt)
        {
            foreach (var project in projectLSt)
                projects.Add(project);
        }

        public bool UpdateProject (Project OldPRoject,Project newProject)
        {
            projects.Remove(OldPRoject);
           return projects.Add(newProject);
        }

        public Project FindProjectByID(int ID)
        {
            return projects.Where(c => c.Id == ID).FirstOrDefault(); ;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.projects.GetEnumerator().Dispose();
                }
            }
            this.disposed = true;
        }

        private Employee FillEmployee(DataRow row)
        {
            DateTime parsedDate;
            return new Employee()
            {
                Id = Convert.ToInt32(row["EmpID"]),
                StartDate = DateTime.Parse(row["DateFrom"].ToString()),
                EndDate = DateTime.TryParse(row["DateTo"]?.ToString(), out parsedDate) ? parsedDate : DateTime.Now,
            };
        }
       
    }
}