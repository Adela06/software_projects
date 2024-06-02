using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebFormUsers : System.Web.UI.Page
    {
        private Dictionary<string, string> dict;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPlants();
            }
        }

        private void LoadPlants()
        {
            try
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                List<localhost1.Plant> plants = webService.GetPlants().ToList();
                GridView1.DataSource = plants;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error loading plants: " + ex.Message;
            }
        }

        protected void SortByType_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                List<localhost1.Plant> sortedPlants = webService.TypesSort().ToList();
                GridView1.DataSource = sortedPlants;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error sorting plants by type: " + ex.Message;
            }
        }

        protected void SortBySpecies_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                List<localhost1.Plant> sortedPlants = webService.SpeciesSort().ToList();
                GridView1.DataSource = sortedPlants;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error sorting plants by species: " + ex.Message;
            }
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            try
            {
                string filterValue = txtFilter.Text;
                string selectedFilter = ddlFilterType.SelectedValue;
                if (!string.IsNullOrEmpty(filterValue))
                {
                    localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                    List<localhost1.Plant> filteredPlants = webService.Filter(selectedFilter, filterValue).ToList();
                    GridView1.DataSource = filteredPlants;
                    GridView1.DataBind();
                }
                else
                {
                    LoadPlants(); // Reload the full list if no filter is applied
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error filtering plants: " + ex.Message;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text;
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                    List<localhost1.Plant> searchResults = webService.Search(searchTerm).ToList();
                    GridView1.DataSource = searchResults;
                    GridView1.DataBind();
                }
                else
                {
                    LoadPlants(); // Reload the full list if no search term is provided
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error searching plants: " + ex.Message;
            }
        }


        protected void ResetList_Click(object sender, EventArgs e)
        {
            LoadPlants();
        }


        //template dp
        // Template method for saving plants in different formats
        protected void SavePlants(Action saveMethod)
        {
            try
            {
                saveMethod.Invoke(); // Invoke the provided save method
            }
            catch (Exception ex)
            {
                
                // Label1.Text = "Error saving plants: " + ex.Message;
            }
        }


        protected void SaveAsXML_Click(object sender, EventArgs e)
        {
            SavePlants(() =>
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.SaveAsXML();
            });
        }

        protected void SaveAsCSV_Click(object sender, EventArgs e)
        {
            SavePlants(() =>
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.SaveAsCSV();
            });
        }

        protected void SaveAsDOC_Click(object sender, EventArgs e)
        {
            SavePlants(() =>
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.SaveAsDOC();
            });
        }

        protected void SaveAsJSON_Click(object sender, EventArgs e)
        {
            SavePlants(() =>
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.SaveAsJSON();
            });
        }

        protected void ShowStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                Dictionary<string, int> statistics = null;

                if (ddlStatisticsType.SelectedValue == "Location")
                {
                    string locationStatisticsJson = webService.GetPlantsByLocationStatistics();
                    statistics = JsonConvert.DeserializeObject<Dictionary<string, int>>(locationStatisticsJson);
                }
                else if (ddlStatisticsType.SelectedValue == "Carnivorous")
                {
                    string carnivorousStatisticsJson = webService.GetCarnivorousStatistics();
                    statistics = JsonConvert.DeserializeObject<Dictionary<string, int>>(carnivorousStatisticsJson);
                }

                // Render chart using JavaScript
                string script = @"<script>
                            var ctx = document.getElementById('plantStatisticsChart').getContext('2d');
                            var chart = new Chart(ctx, {
                                type: 'bar',
                                data: {
                                    labels: " + JsonConvert.SerializeObject(statistics.Keys) + @",
                                    datasets: [{
                                        label: 'Statistics',
                                        data: " + JsonConvert.SerializeObject(statistics.Values) + @",
                                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                        borderColor: 'rgba(75, 192, 192, 1)',
                                        borderWidth: 1
                                    }]
                                },
                                options: {
                                    scales: {
                                        y: {
                                            beginAtZero: true
                                        }
                                    }
                                }
                            });
                        </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "PlantStatisticsChart", script);
            }
            catch (Exception ex)
            {
                Label1.Text = "Error displaying statistics: " + ex.Message;
            }
        }

        //CREATE, UPDATE, DELETE on plants
        protected void CreatePlant_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input from TextBoxes
                string plantName = txtPlantName.Text;
                string plantType = txtPlantType.Text;
                string species = txtSpecies.Text;
                string carnivorous = txtCarnivorous.Text;
                string location = txtLocation.Text;

                // Create a new Plant object
                localhost1.Plant newPlant = new localhost1.Plant();
                newPlant.PlantName = plantName;
                newPlant.PlantType = plantType;
                newPlant.Species = species;
                newPlant.Carnivorous = carnivorous;
                newPlant.Location = location;

                // Call the AddPlant method from the web service to add the new plant
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.AddPlant(newPlant);

                // Reload the grid view to reflect the changes
                LoadPlants();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error creating plant: " + ex.Message;
            }
        }

        protected void UpdatePlant_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input from TextBoxes
                int plantId = Convert.ToInt32(txtPlantId.Text);
                string plantName = txtPlantName.Text;
                string plantType = txtPlantType.Text;
                string species = txtSpecies.Text;
                string carnivorous = txtCarnivorous.Text;
                string location = txtLocation.Text;

                // Create a new Plant object
                localhost1.Plant updatedPlant = new localhost1.Plant();
                updatedPlant.Id = txtPlantId.Text;
                updatedPlant.PlantName = plantName;
                updatedPlant.PlantType = plantType;
                updatedPlant.Species = species;
                updatedPlant.Carnivorous = carnivorous;
                updatedPlant.Location = location;

                // Call the UpdatePlant method from the web service to update the plant
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.UpdatePlant(plantId, updatedPlant);

                // Reload the grid view to reflect the changes
                LoadPlants();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error updating plant: " + ex.Message;
            }
        }

        protected void DeletePlant_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve plant ID from TextBox
                int plantId = Convert.ToInt32(txtPlantId.Text);

                // Call the DeletePlant method from the web service to delete the plant
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                webService.DeletePlant(plantId);

                // Reload the grid view to reflect the changes
                LoadPlants();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error deleting plant: " + ex.Message;
            }
        }

        protected void SwitchToRomana_Click(object sender, EventArgs e)
        {
            LoadTranslations(Server.MapPath("~/romana.csv"));
            ApplyTranslations();
        }

        protected void SwitchToEngleza_Click(object sender, EventArgs e)
        {
            LoadTranslations(Server.MapPath("~/engleza.csv"));
            ApplyTranslations();
        }

        protected void SwitchToGermana_Click(object sender, EventArgs e)
        {
            LoadTranslations(Server.MapPath("~/germana.csv"));
            ApplyTranslations();
        }

        private void LoadTranslations(string filePath)
        {
            try
            {
                dict = new Dictionary<string, string>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 2)
                        {
                            dict[parts[0]] = parts[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error loading translations: " + ex.Message;
            }
        }

        private void ApplyTranslations()
        {
            if (dict != null && dict.Count > 0)
            {
                btnCreatePlant.Text = GetTranslation("Create");
                btnUpdatePlant.Text = GetTranslation("Update");
                btnDeletePlant.Text = GetTranslation("Delete");
                btnSortByType.Text = GetTranslation("Type");
                btnSortBySpecies.Text = GetTranslation("Species");
                btnFilter.Text = GetTranslation("Filter");
                btnSearch.Text = GetTranslation("Search");
                btnResetList.Text = GetTranslation("Reset");
                btnShowStatistics.Text = GetTranslation("Statistics");
            }
        }

        private string GetTranslation(string key)
        {
            return dict.ContainsKey(key) ? dict[key] : key;
        }
    }
}
