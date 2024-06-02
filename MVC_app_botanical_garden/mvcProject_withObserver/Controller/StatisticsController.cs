using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gradinaTema1.Model;
using gradinaTema1.View;

namespace gradinaTema1.Controller
{
    public class StatisticsController
    {
        private readonly Statistics _view;
        private readonly List<Plant> _plants; // Add a field to store the list of plants

        public StatisticsController(Statistics view, List<Plant> plants)
        {
            _view = view;
            _plants = plants; // Store the list of plants
           // _view.UpdateCarnivorousChartRequested += UpdateCarnivorousChart;
            //_view.UpdateLocationChartRequested += UpdateLocationChart;
        }

        private void UpdateCarnivorousChart()
        {
            Plant plantModel = new Plant(); // Create an instance of the Plant model
            int carnivorousCount = plantModel.GetCarnivorousPlantCount(_plants); // Pass the list of plants
            int nonCarnivorousCount = plantModel.GetNonCarnivorousPlantCount(_plants); // Pass the list of plants
            var carnivorousChartData = new Dictionary<string, int>
            {
                { "Carnivorous", carnivorousCount },
                { "Not carnivorous", nonCarnivorousCount }
            };
            _view.CarnivorousChartData = carnivorousChartData;
            // Update the chart in the view here
            UpdateChartInUI(_view.CarnivorousChartData, _view.getChart1().Series["Carnivorous"]);
        }

        private void UpdateLocationChart()
        {
            Plant plantModel = new Plant(); // Create an instance of the Plant model
            Dictionary<string, int> locationCounts = plantModel.GetPlantLocationCounts(_plants); // Pass the list of plants
            _view.LocationChartData = locationCounts;
            // Update the chart in the view here
            UpdateChartInUI(_view.LocationChartData, _view.getChart2().Series["Location"]);
        }

        // Method to update the chart in the UI
        private void UpdateChartInUI(Dictionary<string, int> data, System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            series.Points.Clear();
            foreach (var dataPoint in data)
            {
                series.Points.AddXY(dataPoint.Key, dataPoint.Value);
            }
        }
    }
}
