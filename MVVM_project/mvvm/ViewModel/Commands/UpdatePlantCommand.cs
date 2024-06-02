using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class UpdatePlantCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public UpdatePlantCommand(PlantVM vm, DataGridView dataGridView)
        {
            this.vm = vm;
            this.dataGridView = dataGridView;
        }

        public void Execute()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                string plantID = dataGridView.SelectedRows[0].Cells["ID"].Value.ToString();

                if (!string.IsNullOrEmpty(plantID))
                {
                    Plant updatedPlant = new Plant
                    {
                        PlantName = vm.PlantName,
                        PlantType = vm.PlantType,
                        Species = vm.Species,
                        Carnivorous = vm.Carnivorous,
                        Location = vm.Location
                    };

                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    plantRepository.UpdatePlant(plantID, updatedPlant);
                }
            }
        }
    }
}
