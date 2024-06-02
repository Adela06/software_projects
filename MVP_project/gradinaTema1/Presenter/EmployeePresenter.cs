using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Presenter
{
    public class EmployeePresenter
    {
        private IPlantGUI iPlantGUI;
        private PlantRepository plantRepository;

        internal void Initialize(EmployeeForm employeeForm)
        {
            this.iPlantGUI = employeeForm;
            this.plantRepository = new PlantRepository("GradinaB");
        }
        public void PlantList(string criteriu)
        {
            string sortBy = criteriu;
            string filterBy = iPlantGUI.GetSelectedFilter();
            string search = iPlantGUI.GetSearchedInformation();

            List<Plant> plants = plantRepository.PlantListFiltered(filterBy, search);

            if (sortBy.Equals("Tip", StringComparison.OrdinalIgnoreCase))
            {
                plants.Sort((p1, p2) => p1.PlantType.CompareTo(p2.PlantType));
            }
            else if (sortBy.Equals("Specie", StringComparison.OrdinalIgnoreCase))
            {
                plants.Sort((p1, p2) => p1.Species.CompareTo(p2.Species));
            }
            // else -> no list modification

            if (plants != null && plants.Count != 0)
            {
                iPlantGUI.SetTableList(plants);
                ResetFields();

                //Console.WriteLine("Current sorting:");
                //foreach (Plant p in plants)
                //{
                   // Console.Write(p.PlantType + " ");
                   // Console.WriteLine(p.Species);
                //}
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "", "") };
                iPlantGUI.SetTableList(plants);
                ResetFields();
                iPlantGUI.SetMessage("Empty list!");
            }
        }

        private void ResetFields()
        {

        }
        public void addPlant()
        {
            string name = iPlantGUI.getName();
            string tip = iPlantGUI.getTip();
            string specie = iPlantGUI.getSpecie();
            string locatie = iPlantGUI.getLocatie();
            string carnivore = iPlantGUI.getCarnivore();
            Plant p = new Plant("1",name, tip, specie, carnivore,locatie);
            bool res = plantRepository.AddPlant(p);

            Console.WriteLine(res);
        }

        public void deletePlant(string id)
        {
            plantRepository.DeletePlant(id);
        }

        public void updatePlant(string id)
        {
            string name = iPlantGUI.getName();
            string tip = iPlantGUI.getTip();
            string specie = iPlantGUI.getSpecie();
            string locatie = iPlantGUI.getLocatie();
            string carnivore = iPlantGUI.getCarnivore();
            Plant p = new Plant("1", name, tip, specie, carnivore, locatie);
            
            bool res = plantRepository.UpdatePlant(id, p);
        }
    }
}
