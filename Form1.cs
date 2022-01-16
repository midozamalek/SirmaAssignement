using SirmaTask.BAL;
using SirmaTask.Helper;
using SirmaTask.Models;
using SirmaTask.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirmaTask
{
    public partial class Form1 : Form
    {
        ICSVParser parser;
        IProjectRepository projectRepository;
        IStatisticsCalculator statisticsCalculator;
        public Form1()
        {
            InitializeComponent();
            parser = new CSVParser();
            projectRepository = new ProjectRepository();
            statisticsCalculator = new StatisticsCalculator(projectRepository);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFile.Text = openFileDialog1.FileName;
            BindData(txtFile.Text);
        }

        private void BindData(string filePath)
        {
            DataTable datatable;
            try
            {
                datatable = parser.ParseFile(filePath);
                projectRepository.FetchProjects(datatable);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to parse file ,please ensure data in right format.");
            }
            var MostWorkedEmployeesTogetherOverallProjects = statisticsCalculator.GetMostWorkedEmployeesTogetherOverallProjects();
            datatable = FormatResult(MostWorkedEmployeesTogetherOverallProjects);
            if (datatable.Rows.Count > 0)
                dataGridView1.DataSource = datatable;
            else
                MessageBox.Show("All employees didn`t work together in same project.");

        }

        private DataTable FormatResult(List<Tuple<int, int, int, double?>> mostEmployessWorkedTogether)
        {
            DataTable dt = new DataTable();

            if (mostEmployessWorkedTogether.Count > 0)
            {

                dt.Columns.Add(new DataColumn("Employee ID #1"));
                dt.Columns.Add(new DataColumn("Employee ID #2"));
                dt.Columns.Add(new DataColumn("Project ID"));
                dt.Columns.Add(new DataColumn("Days worked"));

                //For Data
                for (int i = 0; i < mostEmployessWorkedTogether.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Employee ID #1"] = mostEmployessWorkedTogether[i].Item1;
                    dr["Employee ID #2"] = mostEmployessWorkedTogether[i].Item2;
                    dr["Project ID"] = mostEmployessWorkedTogether[i].Item3;
                    dr["Days worked"] = mostEmployessWorkedTogether[i].Item4;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

    }
}
