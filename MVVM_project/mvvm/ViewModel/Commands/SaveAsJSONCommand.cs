using gradinaTema1.Model;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace gradinaTema1.ViewModel.Commands
{
    public class SaveAsJSONCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public SaveAsJSONCommand(PlantVM vm, DataGridView dataGridView)
        {
            this.vm = vm;
            this.dataGridView = dataGridView;
        }

        public void Execute()
        {
            var plants = vm.plants.AsEnumerable().Select(row =>
                new Plant
                {
                    Id = row.Field<string>("ID"),
                    PlantName = row.Field<string>("Name"),
                    PlantType = row.Field<string>("Tip"),
                    Species = row.Field<string>("Specie"),
                    Carnivorous = row.Field<string>("Carnivore"),
                    Location = row.Field<string>("Locatie")
                });

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                string json = JsonConvert.SerializeObject(plants, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
    }
}
