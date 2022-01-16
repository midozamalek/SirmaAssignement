using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Helper
{
    public interface ICSVParser
    {
        DataTable ParseFile(string filePath);
    }
}
