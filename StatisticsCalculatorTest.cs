using Microsoft.VisualStudio.TestTools.UnitTesting;
using SirmaTask.BAL;
using SirmaTask.Models;
using SirmaTask.Repository;
using System;
using System.Collections.Generic;

namespace SirmaTask.Test
{
    [TestClass]
    public class StatisticsCalculatorTest
    {
        [TestMethod]
        public void WhenMultipleEmployeesHaveTheLongestDuration()
        {
            //Arrange
            IProjectRepository projectRepository = new ProjectRepository(); ;
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator(projectRepository);
            projectRepository.AddProjects(new List<Project>() {
            new Project()
            {
                Id = 101,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =200,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =201,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =202,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    }
                }
            },
            new Project()
            {
                Id = 102,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =203,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =204,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    }
                }
            }
            });

            //Act
           var resultLst = statisticsCalculator.GetMostWorkedEmployeesTogetherOverallProjects();

            //Asert
            Assert.AreEqual(4, resultLst.Count);

        }

        [TestMethod]
        public void WhenOnlyPairHaveTheLongestDuration()
        {
            //Arrange
            IProjectRepository projectRepository = new ProjectRepository(); ;
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator(projectRepository);
            projectRepository.AddProjects(new List<Project>() {
            new Project()
            {
                Id = 101,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =200,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =201,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =202,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    }
                }
            },
            new Project()
            {
                Id = 102,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =203,
                        StartDate = DateTime.Now.AddDays(-200),
                        EndDate = DateTime.Now
                    },
                    new Employee()
                    {
                        Id =204,
                        StartDate = DateTime.Now.AddDays(-300),
                        EndDate = DateTime.Now
                    }
                }
            }
            });

            //Act
            var resultLst = statisticsCalculator.GetMostWorkedEmployeesTogetherOverallProjects();

            //Asert
            Assert.AreEqual(1, resultLst.Count);

        }


        [TestMethod]
        public void WhenNoEmployeesWorkedTogetherInSameProject()
        {
            //Arrange
            IProjectRepository projectRepository = new ProjectRepository(); ;
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator(projectRepository);
            projectRepository.AddProjects(new List<Project>() {
            new Project()
            {
                Id = 101,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =200,
                        StartDate = DateTime.Now.AddDays(-100),
                        EndDate = DateTime.Now
                    }
                }
            },
            new Project()
            {
                Id = 102,
                employees = new HashSet<Employee>()
                {
                    new Employee()
                    {
                        Id =203,
                        StartDate = DateTime.Now.AddDays(-200),
                        EndDate = DateTime.Now
                    }
                }
            }
            });

            //Act
            var resultLst = statisticsCalculator.GetMostWorkedEmployeesTogetherOverallProjects();

            //Asert
            Assert.AreEqual(0, resultLst.Count);

        }

    }
}
