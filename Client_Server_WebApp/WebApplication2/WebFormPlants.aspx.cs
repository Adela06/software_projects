using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebFormPlants : System.Web.UI.Page
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
                    LoadPlants(); 
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
                    LoadPlants(); 
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

        protected void Login_Click(object sender, EventArgs e)
        {
      
            Response.Redirect("~/Login.aspx");
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
                btnLogin.Text = GetTranslation("Log");
                btnSortByType.Text = GetTranslation("Type");
                btnSortBySpecies.Text = GetTranslation("Species");
                btnFilter.Text = GetTranslation("Filter");
                btnSearch.Text = GetTranslation("Search");
                btnResetList.Text = GetTranslation("Reset");

            }
        }

        private string GetTranslation(string key)
        {
            return dict.ContainsKey(key) ? dict[key] : key;
        }
    }
}
