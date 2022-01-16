using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaTask.Helper
{
    public class CSVParser : ICSVParser
    {
        public DataTable ParseFile(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
               
                dt.Columns.Add(new DataColumn("EmpID"));
                dt.Columns.Add(new DataColumn("ProjectID"));
                dt.Columns.Add(new DataColumn("DateFrom"));
                dt.Columns.Add(new DataColumn("DateTo"));

                //For Data
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    
                    dr["EmpID"] = dataWords[columnIndex++];
                    dr["ProjectID"] = dataWords[columnIndex++];
                    dr["DateFrom"] = dataWords[columnIndex++];
                    dr["DateTo"] = dataWords[columnIndex++];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }


    }
}
