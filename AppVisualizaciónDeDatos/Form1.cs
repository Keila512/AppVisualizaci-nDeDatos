using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace AppVisualizaciónDeDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files CSV (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Year");
                    dataTable.Columns.Add("Sales");

                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            dataTable.Rows.Add(rows);
                        }
                    }
                    dataGridView1.DataSource = dataTable;

                    // Create a New Series for the COLUMN Chart
                    var columnSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnSeries.Points.AddXY(row["Year"].ToString(), Convert.ToDouble(row["Sales"]));
                    }

                    chart1.Series.Add(columnSeries);

                    chart1.Titles.Add("SALES PER YEAR");

                    // Create a New Series for the PIE Chart
                    var pieSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        pieSeries.Points.AddXY(row["Year"].ToString(), Convert.ToDouble(row["Sales"]));
                    }

                    chart2.Series.Add(pieSeries);

                    chart2.Titles.Add("SALES PER YEAR");

                    // Create a New Series for the AREA Chart
                    var areaSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        areaSeries.Points.AddXY(row["Year"].ToString(), Convert.ToDouble(row["Sales"]));
                    }

                    chart3.Series.Add(areaSeries);

                    chart3.Titles.Add("SALES PER YEAR");

                    // Create a New Series for the LINE Chart
                    var lineSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        lineSeries.Points.AddXY(row["Year"].ToString(), Convert.ToDouble(row["Sales"]));
                    }

                    chart4.Series.Add(lineSeries);

                    chart4.Titles.Add("SALES PER YEAR");

                    // Create a New Series for the BAR Chart
                    var barSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Sales",
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        barSeries.Points.AddXY(row["Year"].ToString(), Convert.ToDouble(row["Sales"]));
                    }

                    chart5.Series.Add(barSeries);

                    chart5.Titles.Add("SALES PER YEAR");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
        }
    }
}

    

