using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.BAL
{
    public interface IStatisticsCalculator
    {
        List<Tuple<int, int, int, double?>> GetMostWorkedEmployeesTogetherOverallProjects();
    }
}
