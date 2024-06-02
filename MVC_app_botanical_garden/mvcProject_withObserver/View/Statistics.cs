using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gradinaTema1.View
{
    public partial class Statistics : Form
    {


        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
        public Dictionary<string, int> CarnivorousChartData { get; set; }
        public Dictionary<string, int> LocationChartData { get; set; }

        public Chart getChart1() { return chart1; }
        public Chart getChart2() {  return chart2; }
    

        // Method to update the chart with counts of carnivorous and non-carnivorous plants
          public void UpdateCarnivorousChart(int carnivorousCount, int nonCarnivorousCount)
          {
              this.chart1.Series["Carnivorous"].Points.AddXY("Carnivorous", carnivorousCount);
              this.chart1.Series["Carnivorous"].Points.AddXY("Not carnivorous", nonCarnivorousCount);
          }

          // Method to update the chart with counts of plants based on their locations
          public void UpdateLocationChart(Dictionary<string, int> locationCounts)
          {
              foreach (var location in locationCounts)
              {
                  this.chart2.Series["Location"].Points.AddXY(location.Key, location.Value);
              }
          }



        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
