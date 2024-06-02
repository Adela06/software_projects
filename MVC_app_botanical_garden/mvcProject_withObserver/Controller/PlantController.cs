using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using gradinaTema1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sets.Model;
using System.Drawing;
using System.IO;

namespace gradinaTema1.Controller
{
    public class PlantController : Observable
    {
        private PlantForm plantForm;
        private LoginForm logInForm;
        private Dictionary<string, string> dict;

        public PlantController()
        {
            this.plantForm = new PlantForm();
            dict = new Dictionary<string, string>();

            plantForm.getSearchButton().Click += new EventHandler(Search);
            plantForm.getFilterButton().Click += new EventHandler(Filter);
            plantForm.getTipButton().Click += new EventHandler(TypesSort);
            plantForm.getSpecieButton().Click += new EventHandler(SpeciesSort);
            plantForm.getLoginButton().Click += new EventHandler(ShowLogInForm);


            plantForm.getRomanaButton().Click += new EventHandler(SwitchToRomana);
            plantForm.getEnglezaButton().Click += new EventHandler(SwitchToEngleza);
            plantForm.getGermanaButton().Click += new EventHandler(SwitchToGermana);


            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            this.getPlantForm().getPlants().Rows.Clear();

            List<Plant> plants = plantRepository.PlantList();

            if (plants != null && plants.Count != 0)
            {
                setTableList(plants);
            }
            else
            {
                plants = new List<Plant> { new Plant("", "", "", "", "", "","") };
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

               plantForm.getLoginButton().Text = dict["Log"];
               plantForm.getFilterButton().Text = dict["Filter"];
               plantForm.getSortLabel().Text = dict["Sort"];
               plantForm.getTipButton().Text = dict["Type"];
               plantForm.getSpecieButton().Text = dict["Species"];
               plantForm.getEnterLabel().Text = dict["Enter"];
               plantForm.getSearchButton().Text = dict["Search"];
               plantForm.getEnglezaButton().Text = dict["English"];
               plantForm.getRomanaButton().Text = dict["Romanian"];
               plantForm.getGermanaButton().Text = dict["German"];
               plantForm.getSelectLabel().Text = dict["Select"];
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

            plantForm.getLoginButton().Text = dict["Log"];
            plantForm.getFilterButton().Text = dict["Filter"];
            plantForm.getSortLabel().Text = dict["Sort"];
            plantForm.getTipButton().Text = dict["Type"];
            plantForm.getSpecieButton().Text = dict["Species"];
            plantForm.getEnterLabel().Text = dict["Enter"];
            plantForm.getSearchButton().Text = dict["Search"];
            plantForm.getEnglezaButton().Text = dict["English"];
            plantForm.getRomanaButton().Text = dict["Romanian"];
            plantForm.getGermanaButton().Text = dict["German"];
            plantForm.getSelectLabel().Text = dict["Select"];
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

            plantForm.getLoginButton().Text = dict["Log"];
            plantForm.getFilterButton().Text = dict["Filter"];
            plantForm.getSortLabel().Text = dict["Sort"];
            plantForm.getTipButton().Text = dict["Type"];
            plantForm.getSpecieButton().Text = dict["Species"];
            plantForm.getEnterLabel().Text = dict["Enter"];
            plantForm.getSearchButton().Text = dict["Search"];
            plantForm.getEnglezaButton().Text = dict["English"];
            plantForm.getRomanaButton().Text = dict["Romanian"];
            plantForm.getGermanaButton().Text = dict["German"];
            plantForm.getSelectLabel().Text = dict["Select"];
        }


        private void Search(object sender, EventArgs e)
        {
            string searchTerm = plantForm.getName().Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                UpdatePlantTable();
            }
            else
            {
                PlantRepository plantRepository = new PlantRepository("GradinaB", this);
                List<Plant> filteredPlants = plantRepository.PlantList().Where(p => p.PlantName.ToLower().Contains(searchTerm.ToLower())).ToList();
                UpdatePlantTable(filteredPlants);
            }
        }

        public void Filter(object sender, EventArgs e)
        {
            string selectedFilter = plantForm.GetCombo().SelectedItem.ToString();
            string filterValue = plantForm.getFiltrare().Text.Trim();

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

        private void TypesSort(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.PlantType).ToList();
            UpdatePlantTable(sortedPlants);
        }

        private void SpeciesSort(object sender, EventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> sortedPlants = plantRepository.PlantList().OrderBy(p => p.Species).ToList();
            UpdatePlantTable(sortedPlants);
        }

        private void UpdatePlantTable(List<Plant> plants)
        {
            plantForm.getPlants().Rows.Clear();

            foreach (Plant p in plants)
            {
                plantForm.getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, Image.FromFile(p.Image));
            }
        }
        private void UpdatePlantTable()
        {
            PlantRepository plantRepository = new PlantRepository("GradinaB", this);
            List<Plant> plants = plantRepository.PlantList();
            plantForm.getPlants().Rows.Clear();
            foreach (Plant p in plants)
            {
                plantForm.getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, Image.FromFile(p.Image));
            }
        }
        private void setTableList(List<Plant> plants)
        {
            foreach (Plant p in plants)
            {//plantId, name, type, species, carnivorous, location
                this.getPlantForm().getPlants().Rows.Add(p.Id, p.PlantName, p.PlantType, p.Species, p.Carnivorous, p.Location, Image.FromFile(p.Image));
            }
        }
        public void Update(Subject obs)
        {
           // throw new NotImplementedException();
        }
        public PlantForm getPlantForm()
        {
            return this.plantForm;
        }

        private void ShowLogInForm1(object sender, EventArgs e)
        {
            // Check if the login form is already created
            if (logInForm == null)
            {
                logInForm = new LoginForm();
                //logInForm.Login().Click += new EventHandler(AuthenticateUser);
            }
            plantForm.Hide();
            logInForm.Show();
        }
        private void ShowLogInForm(object sender, EventArgs e)
        {
            if (logInForm == null)
            {
                logInForm = new LoginForm();
                logInForm.Login().Click += (s, ev) =>
                {
                    string username = logInForm.GetUsername().Text;
                    string password = logInForm.GetPassword().Text;
                    AuthenticationService.AuthenticateUser(logInForm, username, password);
                };
            }
            plantForm.Hide();
            logInForm.Show();
        }
    }

}

