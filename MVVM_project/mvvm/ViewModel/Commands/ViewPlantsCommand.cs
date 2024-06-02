using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace gradinaTema1.ViewModel.Commands
{
    public class ViewPlantsCommand : ICommand
    {
        private PlantRepository plantRepository;
        private PlantVM plantVM;

        public ViewPlantsCommand(PlantVM plantVM)
        {
            this.plantVM = plantVM;
        }

        public void Execute()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");

            this.plantVM.plants.Rows.Clear();

            List<Plant> plants = plantRepository.PlantList();

            if (plants != null && plants.Count != 0)
            {
                setTableList(plants);
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "","") };
                setTableList(plants);
            }
        }
        private void setTableList(List<Plant> plants)
        {
            foreach (Plant p in plants)
            {//plantId, name, type, species, carnivorous, location
                this.plantVM.plants.Rows.Add(p.Id, p.PlantName, p.PlantType,p.Species,p.Carnivorous, p.Location);
            }
        }
    }
}
