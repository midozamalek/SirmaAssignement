using SirmaTask.Models;
using SirmaTask.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.BAL
{
    public class StatisticsCalculator : IStatisticsCalculator
    {
        private IProjectRepository projectRepository { get; set; }
        public StatisticsCalculator(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public List<Tuple<int, int, int, double?>> GetMostWorkedEmployeesTogetherPerProject(double? top2MaxDuration, HashSet<Employee> employees, int projectId)
        {
            var mostWorkedEmployeesTogetherLst = new List<Tuple<int, int, int, double?>>();
            if (top2MaxDuration != null)
            {

                List<Employee> mostWorkedEmployeesTogether = employees.Where(c => c.TotalDurationInDays >= top2MaxDuration).Select(c => c).ToList();
                for (int emp1 = 0; emp1 < mostWorkedEmployeesTogether.Count; emp1++)
                {
                    for (int emp2 = emp1; emp2 < mostWorkedEmployeesTogether.Count; emp2++)
                    {
                        if (emp1 == emp2)
                            continue;
                        mostWorkedEmployeesTogetherLst.Add(Tuple.Create(mostWorkedEmployeesTogether[emp1].Id, mostWorkedEmployeesTogether[emp2].Id, projectId, top2MaxDuration));
                    }
                }

                return mostWorkedEmployeesTogetherLst;
            }
            return null;
        }

        public List<Tuple<int, int, int, double?>> GetMostWorkedEmployeesTogetherOverallProjects()
        {
            List<Tuple<int, int, int, double?>> MostWorkedEmployeesTogetherOverallProjects = new List<Tuple<int, int, int, double?>>();
            var projects = this.projectRepository.GetProjects();
            double? maxDurationOverallProjects = projects.Max(c => c.MaxDuration);
            var maxDurationProjects = projects.Where(c => c.MaxDuration == maxDurationOverallProjects).ToList();
            foreach (var project in maxDurationProjects)
            {
                var mosetWorkedPerProject = GetMostWorkedEmployeesTogetherPerProject(maxDurationOverallProjects, project.employees, project.Id);
                if(mosetWorkedPerProject != null)
                    MostWorkedEmployeesTogetherOverallProjects.AddRange(mosetWorkedPerProject);
            }
            return MostWorkedEmployeesTogetherOverallProjects;
        }

        
    }
}
