using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gradinaTema1.ViewModel.Commands
{
    public class SortSpeciesCommand : ICommand
    {
        private PlantVM plantVM;
        private PlantRepository plantRepository;

        public SortSpeciesCommand(PlantVM plantVM)
        {
            this.plantVM = plantVM;
            plantRepository = new PlantRepository("GradinaB");
        }

        public void Execute()
        {
            List<Plant> plants = plantRepository.PlantList();

            if (plants != null && plants.Any())
            {
                plants = plants.OrderBy(p => p.Species).ToList();
                SetTableList(plants);
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "", "") };
                SetTableList(plants);
            }
        }

        private void SetTableList(List<Plant> plants)
        {
            plantVM.plants.Rows.Clear();

            foreach (Plant p in plants)
            {
                plantVM.plants.Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location);
            }
        }
    }
}
