using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gradinaTema1.ViewModel.Commands
{
    public class FilterPlantsCommand : ICommand
    {
        private PlantVM plantVM;
        private PlantRepository plantRepository;

        public string FilterBy { get; set; }
        public string SearchText { get; set; }

        public FilterPlantsCommand(PlantVM plantVM)
        {
            this.plantVM = plantVM;
            this.plantRepository = new PlantRepository("GradinaB");
        }

        public void Execute()
        {
            var filteredPlants = plantVM.plantRepository.PlantListFiltered(FilterBy, SearchText);
            plantVM.plants.Rows.Clear();

            foreach (Plant p in filteredPlants)
            {
                plantVM.plants.Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location);
            }
        }
    }
}
