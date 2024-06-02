using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using WebApplication1.model;
using WebApplication1.model.repository;
using Xceed.Words.NET;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Xceed.Document.NET;

namespace WebApplication1.service
{
    /// <summary>
    /// Summary description for plantServiceFull
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class plantServiceFull : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Plant> GetPlants()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            return plantRepository.PlantList();
        }

        [WebMethod]
        public void AddPlant(Plant plant)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            plantRepository.AddPlant(plant);
        }

        [WebMethod]
        public void DeletePlant(int id)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            plantRepository.DeletePlant(id.ToString());
        }

        [WebMethod]
        public void UpdatePlant(int id, Plant plant)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            plantRepository.UpdatePlant(id.ToString(), plant);
        }

        /*

                [WebMethod]
                public void SaveAsCSV()
                {
                    try
                    {
                        PlantRepository plantRepository = new PlantRepository("GradinaB");
                        List<Plant> plants = plantRepository.PlantList();

                        // Get the physical path to the App_Data folder
                        string appDataPath = Server.MapPath("~/savedFiles");

                        // Combine the App_Data path with the file name
                        string filePath = Path.Combine(appDataPath, "fisier.csv");

                        using (StreamWriter sw = new StreamWriter(filePath))
                        {
                            // Write CSV header
                            sw.WriteLine("ID,Name,Tip,Specie,Carnivore,Locatie");

                            // Write plant data
                            foreach (var plant in plants)
                            {
                                // Concatenate fields with commas and write to file
                                sw.WriteLine(string.Join(";", plant.Id, plant.PlantName, plant.PlantType, plant.Species, plant.Carnivorous, plant.Location));
                            }
                        }

                        // Set the content type and headers to indicate a file download
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "application/csv";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=fisier.csv");

                        // Write the data to the response stream
                        HttpContext.Current.Response.WriteFile(filePath);

                        // End the response (send the file to the client)
                        HttpContext.Current.Response.End();
                    }
                    catch (Exception ex)
                    {
                    }
                }

                [WebMethod]
                public void SaveAsXML()
                {
                    try
                    {
                        PlantRepository plantRepository = new PlantRepository("GradinaB");
                        List<Plant> plants = plantRepository.PlantList();

                        if (plants != null && plants.Count > 0)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<Plant>));
                            using (TextWriter writer = new StreamWriter(Server.MapPath("~/savedFiles/plants.xml")))
                            {
                                serializer.Serialize(writer, plants);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                [WebMethod]
                public void SaveAsJSON()
                {
                    try
                    {
                        PlantRepository plantRepository = new PlantRepository("GradinaB");
                        List<Plant> plants = plantRepository.PlantList();

                        if (plants != null && plants.Count > 0)
                        {
                            string json = JsonConvert.SerializeObject(plants, Newtonsoft.Json.Formatting.Indented);

                            // Set the file name for the downloaded file
                            string fileName = "plants.json";

                            // Get the physical path to the App_Data folder
                            string appDataPath = Server.MapPath("~/savedFiles");

                            // Combine the App_Data path with the file name
                            string filePath = Path.Combine(appDataPath, fileName);

                            // Write JSON to file
                            File.WriteAllText(filePath, json);

                            // Set the content type and headers to indicate a file download
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.ContentType = "application/json";
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                            // Write the data to the response stream
                            HttpContext.Current.Response.WriteFile(filePath);

                            // End the response (send the file to the client)
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            // Handle case when there are no plants to serialize
                            //throw new Exception("No plants found to serialize.");
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }


                [WebMethod]
                public void SaveAsDOC()
                {
                    try
                    {
                        PlantRepository plantRepository = new PlantRepository("GradinaB");
                        List<Plant> plants = plantRepository.PlantList();

                        if (!string.IsNullOrEmpty("fisier.docx"))
                        {
                            using (DocX document = DocX.Create(Server.MapPath("~/savedFiles/fisier.docx")))
                            {
                                // Create a table with 7 columns (for ID, Name, Type, Species, Carnivorous, Location, and an empty column for spacing)
                                Table table = document.AddTable(plants.Count + 1, 7);

                                // Set the style of the table
                                table.Design = TableDesign.ColorfulList;

                                // Add header row
                                table.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                                table.Rows[0].Cells[1].Paragraphs.First().Append("Name");
                                table.Rows[0].Cells[2].Paragraphs.First().Append("Type");
                                table.Rows[0].Cells[3].Paragraphs.First().Append("Species");
                                table.Rows[0].Cells[4].Paragraphs.First().Append("Carnivorous");
                                table.Rows[0].Cells[5].Paragraphs.First().Append("Location");

                                // Fill the table with plant data
                                for (int i = 0; i < plants.Count; i++)
                                {
                                    table.Rows[i + 1].Cells[0].Paragraphs.First().Append(plants[i].Id);
                                    table.Rows[i + 1].Cells[1].Paragraphs.First().Append(plants[i].PlantName);
                                    table.Rows[i + 1].Cells[2].Paragraphs.First().Append(plants[i].PlantType);
                                    table.Rows[i + 1].Cells[3].Paragraphs.First().Append(plants[i].Species);
                                    table.Rows[i + 1].Cells[4].Paragraphs.First().Append(plants[i].Carnivorous);
                                    table.Rows[i + 1].Cells[5].Paragraphs.First().Append(plants[i].Location);
                                }

                                // Insert the table into the document
                                document.InsertTable(table);

                                // Save the document
                                document.Save();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }


                */

 

        //folosim clasa context pt salvare
            [WebMethod]
            public void SaveAsCSV()
            {
                try
                {
                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    List<Plant> plants = plantRepository.PlantList();
                    string appDataPath = Server.MapPath("~/savedFiles");
                    string filePath = Path.Combine(appDataPath, "fisier.csv");

                    FileSaveContext context = new FileSaveContext();
                    context.SetFileSaveStrategy(new CsvFileSaveStrategy());
                    context.SaveFile(plants, filePath);

                    DownloadFile(filePath, "application/csv", "fisier.csv");
                }
                catch (Exception ex)
                {
                    
                }
            }

            [WebMethod]
            public void SaveAsXML()
            {
                try
                {
                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    List<Plant> plants = plantRepository.PlantList();
                    string appDataPath = Server.MapPath("~/savedFiles");
                    string filePath = Path.Combine(appDataPath, "plants.xml");

                    FileSaveContext context = new FileSaveContext();
                    context.SetFileSaveStrategy(new XmlFileSaveStrategy());
                    context.SaveFile(plants, filePath);

                    DownloadFile(filePath, "application/xml", "plants.xml");
                }
                catch (Exception ex)
                {
                    
                }
            }

            [WebMethod]
            public void SaveAsJSON()
            {
                try
                {
                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    List<Plant> plants = plantRepository.PlantList();
                    string appDataPath = Server.MapPath("~/savedFiles");
                    string filePath = Path.Combine(appDataPath, "plants.json");

                    FileSaveContext context = new FileSaveContext();
                    context.SetFileSaveStrategy(new JsonFileSaveStrategy());
                    context.SaveFile(plants, filePath);

                    DownloadFile(filePath, "application/json", "plants.json");
                }
                catch (Exception ex)
                {
                 
                }
            }

            [WebMethod]
            public void SaveAsDOC()
            {
                try
                {
                    PlantRepository plantRepository = new PlantRepository("GradinaB");
                    List<Plant> plants = plantRepository.PlantList();
                    string appDataPath = Server.MapPath("~/savedFiles");
                    string filePath = Path.Combine(appDataPath, "fisier.docx");

                    FileSaveContext context = new FileSaveContext();
                    context.SetFileSaveStrategy(new DocFileSaveStrategy());
                    context.SaveFile(plants, filePath);

                    DownloadFile(filePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "fisier.docx");
                }
                catch (Exception ex)
                {
                
                }
            }

            private void DownloadFile(string filePath, string contentType, string fileName)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = contentType;
                HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
                HttpContext.Current.Response.WriteFile(filePath);
                HttpContext.Current.Response.End();
            }


        [WebMethod]
        public List<Plant> TypesSort()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.PlantType).ToList();

            return sortedPlants;
        }

        [WebMethod]
        public List<Plant> SpeciesSort()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.Species).ToList();

            return sortedPlants;
        }


        [WebMethod]
        public List<Plant> Search(string searchTerm)
        {

            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }
            else
            {
                PlantRepository plantRepository = new PlantRepository("GradinaB");
                List<Plant> filteredPlants = plantRepository.PlantList().Where(p => p.PlantName.ToLower().Contains(searchTerm.ToLower())).ToList();

                return filteredPlants;
            }
        }

        [WebMethod]
        public List<Plant> Filter(string selectedFilter, string filterValue)
        {
            filterValue = filterValue.Trim();

            PlantRepository plantRepository = new PlantRepository("GradinaB");
            List<Plant> filteredPlants = new List<Plant>();

            switch (selectedFilter)
            {
                case "Type":
                    filteredPlants = plantRepository.PlantList().Where(p => p.PlantType.ToLower().Contains(filterValue.ToLower())).ToList();
                    break;
                case "Species":
                    filteredPlants = plantRepository.PlantList().Where(p => p.Species.ToLower().Contains(filterValue.ToLower())).ToList();
                    break;
                case "Carnivorous":
                    filteredPlants = plantRepository.PlantList().Where(p => p.Carnivorous.ToLower().Contains(filterValue.ToLower())).ToList();
                    break;
                case "Location":
                    filteredPlants = plantRepository.PlantList().Where(p => p.Location.ToLower().Contains(filterValue.ToLower())).ToList();
                    break;
                case "Reset List":
                    // Reset the plant list
                    return null;
                default:
                    // Handle unknown filter
                    return null;
            }

            // Update the plant table with the filtered plants
            return filteredPlants;
        }

        [WebMethod]
        public void ShowStatistics(object sender, EventArgs e)
        {
            /*
            // Calculate counts of carnivorous and non-carnivorous plants
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            int carnivorousCount = plantRepository.PlantList().Count(p => p.Carnivorous.ToLower() == "yes");
            int nonCarnivorousCount = plantRepository.PlantList().Count(p => p.Carnivorous.ToLower() == "no");

            // Create and show the StatisticsForm
            Statistics statisticsForm = new Statistics();
            statisticsForm.UpdateCarnivorousChart(carnivorousCount, nonCarnivorousCount);

            // Calculate counts of plants based on their locations
            Dictionary<string, int> locationCounts = new Dictionary<string, int>();
            var plants = plantRepository.PlantList();
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
            statisticsForm.UpdateLocationChart(locationCounts);

            statisticsForm.ShowDialog();
            */
        }

        [WebMethod]
        public string GetPlantsByLocationStatistics()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            var plants = plantRepository.PlantList();

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

            return JsonConvert.SerializeObject(locationCounts);
        }

        [WebMethod]
        public string GetCarnivorousStatistics()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            var plants = plantRepository.PlantList();

            int carnivorousCount = plants.Count(p => p.Carnivorous.ToLower() == "yes");
            int nonCarnivorousCount = plants.Count(p => p.Carnivorous.ToLower() == "no");

            Dictionary<string, int> carnivorousStatistics = new Dictionary<string, int>
    {
        { "Carnivorous", carnivorousCount },
        { "Non-Carnivorous", nonCarnivorousCount }
    };

            return JsonConvert.SerializeObject(carnivorousStatistics);
        }

    }
}
