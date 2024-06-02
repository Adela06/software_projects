using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.model
{
    public class Plant
    {
            protected string id;
            protected string plantName;
            protected string plantType;
            protected string species;
            protected string carnivorous;
            protected string location;
            protected string image;


            public Plant() { }

            public Plant(string id, string plantName, string plantType, string species, string carn, string location, string image)
            {
                this.id = id;
                this.plantName = plantName;
                this.plantType = plantType;
                this.species = species;
                this.carnivorous = carn;
                this.location = location;
                this.image = image;
            }


            public string Id { get { return this.id; } set { this.id = value; } }
            public string PlantName { get { return this.plantName; } set { this.plantName = value; } }
            public string Species { get { return this.species; } set { this.species = value; } }
            public string PlantType { get { return this.plantType; } set { this.plantType = value; } }
            public string Carnivorous { get { return this.carnivorous; } set { this.carnivorous = value; } }
            public string Location { get { return this.location; } set { this.location = value; } }
            public string Image { get { return this.image; } set { this.image = value; } }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Plant p = (Plant)obj;

                return plantName == p.plantName &&
                    plantType == p.plantType &&
                    species == p.species;
            }

            public int GetCarnivorousPlantCount(List<Plant> plants)
            {
                // Count the number of carnivorous plants
                return plants.Count(p => p.Carnivorous.ToLower() == "yes");
            }

            public int GetNonCarnivorousPlantCount(List<Plant> plants)
            {
                // Count the number of non-carnivorous plants
                return plants.Count(p => p.Carnivorous.ToLower() == "no");
            }
            public Dictionary<string, int> GetPlantLocationCounts(List<Plant> plants)
            {
                // Count plants based on their locations
                Dictionary<string, int> locationCounts = new Dictionary<string, int>();

                foreach (var plant in plants)
                {
                    if (!locationCounts.ContainsKey(plant.Location))
                    {
                        locationCounts[plant.Location] = 1;
                    }
                    else
                    {
                        locationCounts[plant.Location]++;
                    }
                }

                return locationCounts;
            }
        }
}