// SearchPlantNameCommand.cs
using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using System;

namespace gradinaTema1.ViewModel.Commands
{
    public class SearchPlantNameCommand : ICommand
    {
        private PlantVM plantVM;
        private PlantRepository plantRepository;
        private string plantName;

        public SearchPlantNameCommand(PlantVM plantVM, PlantRepository plantRepository)
        {
            this.plantVM = plantVM;
            this.plantRepository = plantRepository;
        }
        public void SetPlantName(string plantName)
        {
            this.plantName = plantName;
        }

        public void Execute()
        {
            try
            {
                var searchedPlants = plantRepository.SearchPlantByName(plantName);

                if (searchedPlants != null && searchedPlants.Count > 0)
                {
                    plantVM.plants.Rows.Clear();
                    foreach (var searchedPlant in searchedPlants)
                    {
                        plantVM.plants.Rows.Add(searchedPlant.Id, searchedPlant.PlantName, searchedPlant.PlantType, searchedPlant.Species, searchedPlant.Carnivorous, searchedPlant.Location);
                    }

                    //Console.WriteLine("Found plants:");
                    foreach (var plant in searchedPlants)
                    {
                        Console.WriteLine(plant.PlantName);
                    }
                }
                else
                {
                   // Console.WriteLine("No plants found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during plant search: " + ex.Message);
                throw;
            }
        }

    }
}
