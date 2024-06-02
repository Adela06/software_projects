using gradinaTema1.Controller;
using Sets.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Model.Repository
{
    public class PlantRepository: Subject 
    {
        private Repository repository;
        private string dbName = "GradinaB";

        public PlantRepository(string dbName, EmployeeController o)
        {
            this.obsList = new List<Observable> { o };
            this.dbName = dbName;
            this.repository = Repository.GetInstance(dbName);
        }
        public PlantRepository(string dbName, PlantController o)
        {
            this.obsList = new List<Observable> { o };
            this.dbName = dbName;
            this.repository = Repository.GetInstance(dbName);
        }
        public bool AddPlant(Plant plant)
        {
            string command = $"INSERT INTO Plant(plant_name, plant_type, species, carnivorous, location, image) " +
                             $"VALUES('{plant.PlantName}', '{plant.PlantType}', '{plant.Species}'," +
                             $" '{plant.Carnivorous}', '{plant.Location}', '{plant.Image}')";

           
            bool f = this.repository.ExecuteCommand(command);
            Notify();
            return f;
        }

        public bool UpdatePlant(string id, Plant plant)
        {
            string command = $"UPDATE Plant SET " +
                             $"plant_name = '{plant.PlantName}', " +
                             $"plant_type = '{plant.PlantType}', " +
                             $"species = '{plant.Species}', " +
                             $"carnivorous = '{plant.Carnivorous}', " +
                             $"location = '{plant.Location}'," +
                             $"image = '{plant.Image}' " +
                             $"WHERE plant_id = {id}";
            bool f = this.repository.ExecuteCommand(command);
            Notify();
            return f;
        }

        public bool DeletePlant(string id)
        {
            string command = $"DELETE FROM Plant WHERE plant_id = {id}";
            bool f = this.repository.ExecuteCommand(command);
            Notify();
            return f;
        }

        public Plant SearchPlant(string id)
        {
            string search = $"SELECT * FROM Plant WHERE plant_id = {id}";
            DataTable table = this.repository.GetTable(search);
            Plant plant = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string plantId = row["plant_id"].ToString();
                string name = row["plant_name"].ToString();
                string species = row["species"].ToString();
                string type = row["plant_type"].ToString();
                string carnivorous = row["carnivorous"].ToString();
                string location = row["location"].ToString();
                string image = row["image"].ToString();

                plant = new Plant(plantId, name, type, species, carnivorous, location, image);
            }

            return plant;
        }

        public List<Plant> PlantList()
        {
            List<Plant> plants = new List<Plant>();

            string getPlants = "SELECT * FROM Plant";
            DataTable table = this.repository.GetTable(getPlants);

            foreach (DataRow row in table.Rows)
            {
                string plantId = row["plant_id"].ToString();
                string name = row["plant_name"].ToString();
                string type = row["plant_type"].ToString();
                string species = row["species"].ToString();
                string carnivorous = row["carnivorous"].ToString();
                string location = row["location"].ToString();
                string image = row["image"].ToString();

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location, image);
                plants.Add(plant);
            }

            return plants;
        }


        public List<Plant> SearchPlantByName(string plantName)
        {
            List<Plant> plants = new List<Plant>();

            string searchQuery = $"SELECT * FROM Plant WHERE plant_name LIKE '%{plantName}%' ";
            DataTable table = this.repository.GetTable(searchQuery);

            foreach (DataRow row in table.Rows)
            {
                string plantId = row["plant_id"].ToString();
                string name = row["plant_name"].ToString();
                string species = row["species"].ToString();
                string type = row["plant_type"].ToString();
                string carnivorous = row["carnivorous"].ToString();
                string location = row["location"].ToString();
                string image = row["image"].ToString();

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location, image);
                plants.Add(plant);
            }

            return plants;
        }


        public List<Plant> PlantListFiltered(string filterBy, string search)
        {
            List<Plant> plants = new List<Plant>();

            string getPlants = string.Empty;

            switch (filterBy)
            {
                case "Tip":
                    getPlants = $"SELECT * FROM Plant WHERE plant_type = '{search}'";
                    break;
                case "Specie":
                    getPlants = $"SELECT * FROM Plant WHERE species = '{search}'";
                    break;
                case "Carnivore":
                    getPlants = "SELECT * FROM Plant WHERE carnivorous = 'yes'";
                    break;
                case "Locatie":
                    getPlants = $"SELECT * FROM Plant WHERE location = '{search}'";
                    break;
                case "Nume":
                    getPlants = $"SELECT * FROM Plant WHERE plant_name = '{search}'";
                    break;
                default:
                    return PlantList(); //afisarea listei initiale de plante
            }

            DataTable table = this.repository.GetTable(getPlants);

            foreach (DataRow row in table.Rows)
            {
                string plantId = row["plant_id"].ToString();
                string name = row["plant_name"].ToString();
                string type = row["plant_type"].ToString();
                string species = row["species"].ToString();
                string carnivorous = row["carnivorous"].ToString();
                string location = row["location"].ToString();
                string image = row["image"].ToString();

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location, image);
                plants.Add(plant);
            }

            return plants;
        }
    }   
}
