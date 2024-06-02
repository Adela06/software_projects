using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.ViewModel.Commands
{
    public class CreatePlantCommand : ICommand
    {
        private PlantVM vm;
      

        public CreatePlantCommand(PlantVM vm)
        {
            this.vm = vm;
        }
        public void Execute()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");

            Plant newPlant= new Plant
            {
               PlantName = vm.PlantName,
               PlantType = vm.PlantType,
               Species = vm.Species,
               Carnivorous = vm.Carnivorous,
               Location = vm.Location,
            };
            plantRepository.AddPlant(newPlant);
        }

    }
}
