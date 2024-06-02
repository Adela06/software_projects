using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Model
{
    public class Plant
    {
        protected string id;
        protected string plantName;
        protected string plantType;
        protected string species;
        protected string carnivorous;
        protected string location;

        public Plant() { }

        public Plant(string id, string plantName, string plantType, string species, string carn, string location)
        {
            this.id = id;
            this.plantName = plantName;
            this.plantType = plantType;
            this.species = species;
            this.carnivorous = carn;
            this.location = location;   
        }


        public string Id { get { return this.id; } }
        public string PlantName { get { return this.plantName; } }
        public string Species { get { return this.species; } }
        public string PlantType { get { return this.plantType; } }
        public string Carnivorous { get { return this.carnivorous; } }
        public string Location { get { return this.location; } }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Plant p = (Plant)obj;

            return plantName == p.plantName &&
                   species == p.species &&
                   plantType == p.plantType;
        }


    }
}
