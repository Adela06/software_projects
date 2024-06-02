using gradinaTema1.Model;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace gradinaTema1.ViewModel.Commands
{
    public class SaveAsXMLCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public SaveAsXMLCommand(PlantVM vm, DataGridView dataGridView)
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
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = "Save XML File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Plant>));
                using (TextWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    serializer.Serialize(writer, plants.ToList());
                }
            }
        }
    }
}
