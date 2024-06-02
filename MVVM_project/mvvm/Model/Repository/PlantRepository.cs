using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Model.Repository
{
    public class PlantRepository
    {
        private Repository repository;
        private string dbName = "GradinaB";

        public PlantRepository(string dbName)
        {
            this.dbName = dbName;
            this.repository = new Repository(dbName);
        }

        public bool AddPlant(Plant plant)
        {
            string command = $"INSERT INTO Plant(plant_name, plant_type, species, carnivorous, location) " +
                             $"VALUES('{plant.PlantName}', '{plant.PlantType}', '{plant.Species}'," +
                             $" '{plant.Carnivorous}', '{plant.Location}')";


            return this.repository.ExecuteCommand(command);
        }

        public bool UpdatePlant(string id, Plant plant)
        {
            string command = $"UPDATE Plant SET " +
                             $"plant_name = '{plant.PlantName}', " +
                             $"plant_type = '{plant.PlantType}', " +
                             $"species = '{plant.Species}', " +
                             $"carnivorous = '{plant.Carnivorous}', " +
                             $"location = '{plant.Location}' " +
                             $"WHERE plant_id = {id}";

            return this.repository.ExecuteCommand(command);
        }

        public bool DeletePlant(string id)
        {
            string command = $"DELETE FROM Plant WHERE plant_id = {id}";

            return this.repository.ExecuteCommand(command);
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

                plant = new Plant(plantId, name, type, species, carnivorous, location);
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

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location);
                plants.Add(plant);
            }

            return plants;
        }


        /*public Plant SearchPlantByName(string plantName)
        {
            string searchQuery = $"SELECT * FROM Plant WHERE plant_name LIKE '%{plantName}%' "; 
            DataTable table = this.repository.GetTable(searchQuery);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string plantId = row["plant_id"].ToString();
                string name = row["plant_name"].ToString();
                string species = row["species"].ToString();
                string type = row["plant_type"].ToString();
                string carnivorous = row["carnivorous"].ToString();
                string location = row["location"].ToString();

                return new Plant(plantId, name, type, species, carnivorous, location);
            }

            return null; 
        }*/

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

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location);
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

                Plant plant = new Plant(plantId, name, type, species, carnivorous, location);
                plants.Add(plant);
            }

            return plants;
        }
    }   
}
