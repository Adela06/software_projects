using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class SaveAsCSVCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public SaveAsCSVCommand(PlantVM vm, DataGridView dataGridView)
        {
            this.vm = vm;
            this.dataGridView = dataGridView;
        }

        public void Execute()
        {
            List<Plant> plants = new List<Plant>();
            foreach (DataRow row in vm.plants.Rows)
            {
                plants.Add(new Plant
                {
                    Id = row["ID"].ToString(),
                    PlantName = row["Name"].ToString(),
                    PlantType = row["Tip"].ToString(),
                    Species = row["Specie"].ToString(),
                    Carnivorous = row["Carnivore"].ToString(),
                    Location = row["Locatie"].ToString()
                });
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine("ID;Name;Tip;Specie;Carnivore;Locatie");

                    foreach (var plant in plants)
                    {
                        sw.WriteLine($"{plant.Id},{plant.PlantName},{plant.PlantType},{plant.Species},{plant.Carnivorous},{plant.Location}");
                    }
                }
            }
        }
    }
}
