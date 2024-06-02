using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using Sets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using Xceed.Document.NET;
using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;

namespace gradinaTema1.Controller
{
    public class EmployeeController: Observable
    {
        private EmployeeForm form;
        private Dictionary<string, string> dict;

        public EmployeeController()
        {
            form = new EmployeeForm();

            dict = new Dictionary<string, string>();

            form.getCreateButton().Click += new EventHandler(Create);
            form.getDeleteButton().Click += new EventHandler(Delete);
            form.getUpdateButton().Click += new EventHandler(Update);
            form.getSearchButton().Click += new EventHandler(Search);
            form.getTip().Click += new EventHandler(TypesSort);
            form.getSpecie().Click += new EventHandler(SpeciesSort);
            form.getStatistici().Click += new EventHandler(ShowStatistics);
            form.getFiltered().Click += new EventHandler(Filter);
       

            form.getTipButton().Click += new EventHandler(TypesSort); 
            form.getSpecieButton().Click += new EventHandler(SpeciesSort);

            form.getCSVButton().Click += new EventHandler(SaveAsCSV);
            form.getDOCButton().Click += new EventHandler(SaveAsDOC);
            form.getJSONButton().Click += new EventHandler(SaveAsJSON);
            form.getXMLButton().Click += new EventHandler(SaveAsXML);


            form.getRomanaButton().Click += new EventHandler(SwitchToRomana);
            form.getEnglezaButton().Click += new EventHandler(SwitchToEngleza);
            form.getGermanaButton().Click += new EventHandler(SwitchToGermana);


            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            this.getEmployeeForm().getPlants().Rows.Clear();

            List<Plant> plants = plantRepository.PlantList();

            if (plants != null && plants.Count != 0)
            {
                setTableList(plants);
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "", "", "") };
                setTableList(plants);
            }

        }



        private void SwitchToRomana(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\romana.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getCreateButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];
            form.getStatistici().Text = dict["Statistics"];
            form.getTipButton().Text = dict["Type"];
            form.getSpecieButton().Text = dict["Species"];
            form.getSearchButton().Text = dict["Search"];
            form.getFiltered().Text = dict["Filter"];

            form.getName1().Text = dict["Name"];
            form.getTip1().Text = dict["Type"];
            form.getSpecie1().Text = dict["Species"];
            form.getLocatie1().Text = dict["Location"];
            form.getCarnivora1().Text = dict["Carnivorous"];

            form.getSelectLabel().Text = dict["Select"];
            form.getSaveLabel().Text = dict["Save"];
            form.getEnterLabel().Text = dict["Enter"];
            form.getSortLabel().Text = dict["Sort"];
        }


        private void SwitchToEngleza(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\engleza.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getCreateButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];
            form.getStatistici().Text = dict["Statistics"];
            form.getTipButton().Text = dict["Type"];
            form.getSpecieButton().Text = dict["Species"];
            form.getSearchButton().Text = dict["Search"];
            form.getFiltered().Text = dict["Filter"];

            form.getName1().Text = dict["Name"];
            form.getTip1().Text = dict["Type"];
            form.getSpecie1().Text = dict["Species"];
            form.getLocatie1().Text = dict["Location"];
            form.getCarnivora1().Text = dict["Carnivorous"];

            form.getSelectLabel().Text = dict["Select"];
            form.getSaveLabel().Text = dict["Save"];
            form.getEnterLabel().Text = dict["Enter"];
            form.getSortLabel().Text = dict["Sort"];
        }


        private void SwitchToGermana(object sender, EventArgs e)
        {
            String line;
            dict = new Dictionary<string, string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("D:\\AN3_SEM2\\PS\\Laborator\\Tema3\\germana.csv");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    string[] word = line.Split(';');
                    dict.Add(word[0], word[1]);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            form.getEnglezaButton().Text = dict["English"];
            form.getRomanaButton().Text = dict["Romanian"];
            form.getGermanaButton().Text = dict["German"];

            form.getCreateButton().Text = dict["Create"];
            form.getDeleteButton().Text = dict["Delete"];
            form.getUpdateButton().Text = dict["Update"];
            form.getStatistici().Text = dict["Statistics"];
            form.getTipButton().Text = dict["Type"];
            form.getSpecieButton().Text = dict["Species"];
            form.getSearchButton().Text = dict["Search"];
            form.getFiltered().Text = dict["Filter"];

            form.getName1().Text = dict["Name"];
            form.getTip1().Text = dict["Type"];
            form.getSpecie1().Text = dict["Species"];
            form.getLocatie1().Text = dict["Location"];
            form.getCarnivora1().Text = dict["Carnivorous"];

            form.getSelectLabel().Text = dict["Select"];
            form.getSaveLabel().Text = dict["Save"];
            form.getEnterLabel().Text = dict["Enter"];
            form.getSortLabel().Text = dict["Sort"];

        }



        public void Delete(object sender, EventArgs e)
        {
            if (form.getPlants().SelectedRows.Count > 0)
            {
                string plantID = form.getPlants().SelectedRows[0].Cells["ID"].Value.ToString();

                if (!string.IsNullOrEmpty(plantID))
                {
                    PlantRepository plantRepository = new PlantRepository("GradinaB", this);
                    plantRepository.DeletePlant(plantID);
                }
                else
                {
                    //form.ShowDialog(form, "Selectati o planta pentru a fi stearsa!");
                }
            }
            else
            {
                //MessageBox.Show("Selectati o planta pentru a fi stearsa!");
            }
        }

        public void Update(object sender, EventArgs e)
        {
            try
            {
                if (form.getPlants().SelectedRows.Count > 0)
                {
                    string plantID = form.getPlants().SelectedRows[0].Cells["ID"].Value.ToString();

                    if (!string.IsNullOrEmpty(plantID))
                    {
                        // Prompt the user to select an image file
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                        openFileDialog.Title = "Select Image File";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string imagePath = openFileDialog.FileName;

                            // Proceed with updating the plant using the imagePath
                            Plant updatedPlant = new Plant
                            {
                                PlantName = form.getName().Text,
                                PlantType = form.getTip().Text,
                                Species = form.getSpecie().Text,
                                Carnivorous = form.getCarnivora().Text,
                                Location = form.getLocatie().Text,
                                Image = imagePath // Set the image path
                            };

                            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
                            plantRepository.UpdatePlant(plantID, updatedPlant);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception
                MessageBox.Show($"Error occurred while updating plant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePlantTable(List<Plant> plants)
        {
            form.getPlants().Rows.Clear();

            foreach (Plant p in plants)
            {
                form.getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, System.Drawing.Image.FromFile(p.Image));
            }
        }

        public void Search(object sender, EventArgs e)
        {
            string searchTerm = form.getCautare().Text.Trim(); // Get the search term from textBox7
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, show all plants
                UpdatePlantTable();
            }
            else
            {
                // Otherwise, filter the plants by the search term
                PlantRepository plantRepository = new PlantRepository("GradinaB", this);
                List<Plant> filteredPlants = plantRepository.PlantList().Where(p => p.PlantName.ToLower().Contains(searchTerm.ToLower())).ToList();
                UpdatePlantTable(filteredPlants);
            }
        }
        public void Filter(object sender, EventArgs e)
        {
            string selectedFilter = form.GetCombo().SelectedItem.ToString();
            string filterValue = form.getFiltrare().Text.Trim();

            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
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
                    UpdatePlantTable(); // Reset the plant list
                    return;
                default:
                    // Handle unknown filter
                    return;
            }

            // Update the plant table with the filtered plants
            UpdatePlantTable(filteredPlants);
        }
        public void TypesSort(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.PlantType).ToList();
            UpdatePlantTable(sortedPlants);

        }


        public void SpeciesSort(object sender, EventArgs e)
        {

            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.Species).ToList();
            UpdatePlantTable(sortedPlants);

        }
        private void UpdatePlantTable()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();
            form.getPlants().Rows.Clear();
            foreach (Plant p in plants)
            {
                int v = form.getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, System.Drawing.Image.FromFile(p.Image));
            }
        }


        /* public void Create(object sender, EventArgs e)
         {
             PlantRepository plantRepository = new PlantRepository("GradinaB", this);

             Plant newPlant = new Plant
             {
                 PlantName = form.getName().Text,
                 PlantType = form.getTip().Text,
                 Species = form.getSpecie().Text,
                 Carnivorous = form.getCarnivora().Text,
                 Location = form.getLocatie().Text,
             };
             plantRepository.AddPlant(newPlant);
         }
        */
        public void Create(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Proceed with creating the plant using the imagePath
                PlantRepository plantRepository = new PlantRepository("GradinaB", this);

                Plant newPlant = new Plant
                {
                    PlantName = form.getName().Text,
                    PlantType = form.getTip().Text,
                    Species = form.getSpecie().Text,
                    Carnivorous = form.getCarnivora().Text,
                    Location = form.getLocatie().Text,
                    Image = imagePath // Set the image path
                };

                plantRepository.AddPlant(newPlant);
            }
        }
        public EmployeeForm getEmployeeForm()
        {
            return this.form;
        }

        public void Update(Subject obs)
        {
            PlantRepository plantRepository = (PlantRepository)obs;

            this.getEmployeeForm().getPlants().Rows.Clear();

            List<Plant> plants = plantRepository.PlantList();

            if (plants != null && plants.Count != 0)
            {
                setTableList(plants);
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "", "", "") };
                setTableList(plants);
            }
        }
        private void setTableList(List<Plant> plants)
        {
            foreach (Plant p in plants)
            {//plantId, name, type, species, carnivorous, location
                this.getEmployeeForm().getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, System.Drawing.Image.FromFile(p.Image));
            }
        }

        public void SaveAsXML(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = "Save XML File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Plant>));
                using (TextWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    serializer.Serialize(writer, plants);
                }
            }
        }

        public void SaveAsJSON(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                string json = JsonConvert.SerializeObject(plants, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }


        public void SaveAsCSV(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
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
            }
        }

        public void SaveAsDOC(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DOCX files (*.docx)|*.docx";
            saveFileDialog.Title = "Save DOCX File";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                using (DocX document = DocX.Create(saveFileDialog.FileName))
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

        private void ShowStatistics(object sender, EventArgs e)
        {
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
        }



    }
}
