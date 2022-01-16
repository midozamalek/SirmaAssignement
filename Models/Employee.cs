using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Models
{
   public class Employee
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalDurationInDays
        {
            get
            {
                return (EndDate - StartDate).TotalDays;
                 
            }
        }
    }
}
