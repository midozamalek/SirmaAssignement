using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Models
{
    public class Project
    {
        public int Id { get; set; }     
        public double? MaxDuration
        {
            get
            {
                if (employees.Count < 2)
                    return null;
                return (employees.OrderByDescending(c => c.TotalDurationInDays)).ElementAt(1).TotalDurationInDays;               
            }
        }
        public HashSet<Employee> employees { get; set; } = new HashSet<Employee>();

    }
}
