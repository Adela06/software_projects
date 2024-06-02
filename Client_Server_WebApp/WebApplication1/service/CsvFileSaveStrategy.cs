using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static WebApplication1.service.plantServiceFull;
using WebApplication1.model;

namespace WebApplication1.service
{
    //implementarea strategiilor de salvare in cele 4 formate 
    public class CsvFileSaveStrategy : IFileSaveStrategy
    {
        public void Save(List<Plant> plants, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("ID;Name;Tip;Specie;Carnivore;Locatie");
                foreach (var plant in plants)
                {
                    sw.WriteLine($"{plant.Id};{plant.PlantName};{plant.PlantType};{plant.Species};{plant.Carnivorous};{plant.Location}");
                }
            }
        }
    }
}