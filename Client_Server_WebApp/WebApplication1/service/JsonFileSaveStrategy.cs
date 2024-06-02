using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO; // Add this using directive
using System.Linq;
using System.Web;
using static WebApplication1.service.plantServiceFull;
using WebApplication1.model;

namespace WebApplication1.service
{
    public class JsonFileSaveStrategy : IFileSaveStrategy
    {
        public void Save(List<Plant> plants, string filePath)
        {
            string json = JsonConvert.SerializeObject(plants, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
