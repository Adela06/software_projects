
using gradinaTema1.Model;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace gradinaTema1.ViewModel.Commands
{
    public class SaveAsDOCCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public SaveAsDOCCommand(PlantVM vm, DataGridView dataGridView)
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
            saveFileDialog.Filter = "DOCX files (*.docx)|*.docx";
            saveFileDialog.Title = "Save DOCX File";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                using (DocX document = DocX.Create(saveFileDialog.FileName))
                {
                    foreach (var plant in plants)
                    {
                        document.InsertParagraph($"{plant.Id} - {plant.PlantName} - {plant.PlantType} - {plant.Species} - {plant.Carnivorous} - {plant.Location}");
                    }

                    document.Save();
                }
            }
        }
    }
}
