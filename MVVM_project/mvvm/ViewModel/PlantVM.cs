using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using gradinaTema1.View;
using gradinaTema1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICommand = gradinaTema1.ViewModel.Commands.ICommand;

namespace gradinaTema1.ViewModel
{
    public class PlantVM
    {
        public PlantRepository plantRepository;

        public string id;
        public string plantName;
        public string plantType;
        public string species;
        public string carnivorous;
        public string location;
        public DataTable plants;

        public ICommand AddPlant;
        public ICommand ViewPlants;
        public ICommand DeletePlants;
        public ICommand UpdatePlants;
        public ICommand SortSpecies;
        public ICommand SortTypes;
        public ICommand SaveAsCSV;
        public ICommand SaveAsDOC;

        public ICommand SaveAsJSON;
        public ICommand SaveAsXML;

        public ICommand GoToLoginPage;

        public FilterPlantsCommand FilterPlants { get; private set; }
        public SearchPlantNameCommand SearchPlantName { get; private set; }

    public PlantVM(PlantForm plantForm, DataGridView dataGridView)
        {
            this.id = "";
            this.plantType = "";
            this.plantName = "";
            this.species = "";
            this.carnivorous = "";
            this.location = "";
            this.AddPlant = new CreatePlantCommand(this);
            this.DeletePlants = new DeletePlantCommand(this, dataGridView);
            this.UpdatePlants = new UpdatePlantCommand(this, dataGridView);
            this.ViewPlants = new ViewPlantsCommand(this);
            this.SortSpecies = new SortSpeciesCommand(this);
            this.SortTypes = new SortTypeCommand(this);
            this.plantRepository = new PlantRepository("GradinaB"); 
            this.FilterPlants = new FilterPlantsCommand(this);
            this.SearchPlantName = new SearchPlantNameCommand(this, this.plantRepository);
            this.GoToLoginPage = new GoToLoginPage(plantForm);
            this.SaveAsCSV = new SaveAsCSVCommand(this, dataGridView);
            this.SaveAsDOC = new SaveAsDOCCommand(this, dataGridView);  
            this.SaveAsJSON = new SaveAsJSONCommand(this, dataGridView);  
            this.SaveAsXML = new SaveAsXMLCommand(this, dataGridView);  


            this.plants = new DataTable();

            plants.Columns.Add("ID");
            plants.Columns.Add("Name");
            plants.Columns.Add("Tip");
            plants.Columns.Add("Specie");
            plants.Columns.Add("Carnivore");
            plants.Columns.Add("Locatie");
           
        }


        public PlantVM(DataGridView dataGridView)
        {
            this.id = "";
            this.plantType = "";
            this.plantName = "";
            this.species = "";
            this.carnivorous = "";
            this.location = "";
            this.AddPlant = new CreatePlantCommand(this);
            this.DeletePlants = new DeletePlantCommand(this,dataGridView);
            this.UpdatePlants = new UpdatePlantCommand(this, dataGridView);
            this.ViewPlants = new ViewPlantsCommand(this);
            this.SortSpecies = new SortSpeciesCommand(this);
            this.SortTypes = new SortTypeCommand(this);
            this.plantRepository = new PlantRepository("GradinaB");
            this.FilterPlants = new FilterPlantsCommand(this);
            this.SearchPlantName = new SearchPlantNameCommand(this, this.plantRepository);
            this.SaveAsCSV = new SaveAsCSVCommand(this, dataGridView);
            this.SaveAsDOC = new SaveAsDOCCommand(this, dataGridView);
            this.SaveAsJSON = new SaveAsJSONCommand(this, dataGridView);
            this.SaveAsXML = new SaveAsXMLCommand(this, dataGridView);

            this.plants = new DataTable();

            plants.Columns.Add("ID");
            plants.Columns.Add("Name");
            plants.Columns.Add("Tip");
            plants.Columns.Add("Specie");
            plants.Columns.Add("Carnivore");
            plants.Columns.Add("Locatie");

        }
        public string Id
        { get { return this.id; } set { this.id = value; } }

        public string PlantName
        {  get { return this.plantName; }set { this.plantName = value; }
        }

        public void InitializeSaveAsCSVCommand(DataGridView dataGridView)
        {
            this.SaveAsCSV = new SaveAsCSVCommand(this, dataGridView);
        }

        public void InitializeSaveAsDOCCommand(DataGridView dataGridView)
        {
            this.SaveAsDOC = new SaveAsDOCCommand(this, dataGridView);
        }

        public void InitializeSaveAsJSONCommand(DataGridView dataGridView)
        {
            this.SaveAsJSON = new SaveAsJSONCommand(this, dataGridView);
        }

        public void InitializeSaveAsXMLCommand(DataGridView dataGridView)
        {
            this.SaveAsXML = new SaveAsXMLCommand(this, dataGridView);
        }

        public string Species {  get { return this.species; } set { this.species = value; } }
        public string Carnivorous { get {  return this.carnivorous; } set { this.carnivorous = value; } }
        public string Location { get { return this.location; } set { this.location = value; } } 
        public string PlantType {  get { return this.plantType; } set { this.plantType = value; } }
    }
}
