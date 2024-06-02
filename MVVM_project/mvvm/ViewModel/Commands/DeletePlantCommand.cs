using gradinaTema1.Model.Repository;
using System.Windows.Forms;

namespace gradinaTema1.ViewModel.Commands
{
    public class DeletePlantCommand : ICommand
    {
        private PlantVM vm;
        private DataGridView dataGridView;

        public DeletePlantCommand(PlantVM vm, DataGridView dataGridView)
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
                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    plantRepository.DeletePlant(plantID);
                }
                else
                {
                    MessageBox.Show("Selectati o planta pentru a fi stearsa!");
                }
            }
            else
            {
                MessageBox.Show("Selectati o planta pentru a fi stearsa!");
            }
        }
    }
}
