using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebFormAdmin : System.Web.UI.Page
    {
        private Dictionary<string, string> dict;

        private IServiceFactory plantServiceFactory;
        private IServiceFactory userServiceFactory;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize service factories
            plantServiceFactory = new PlantServiceFactory();
            userServiceFactory = new UserServiceFactory();

            try
            {//pentru a crea un serviciu de utilizatori 
                var UserService = userServiceFactory.CreateService();
               List<localhostU.User> users = ((localhostU.userService)UserService).GetUsers().ToList();

               DataGridViewUsers.DataSource = users;
               DataGridViewUsers.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadPlants()
        {
            try
            {//pentru a crea un serviciu de plante 
                localhost1.plantServiceFull webService = new localhost1.plantServiceFull();
                List<localhost1.Plant> plants = webService.GetPlants().ToList();
                GridView1.DataSource = plants;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            catch (Exception ex)
            {
                Label1.Text = "Error loading plants: " + ex.Message;
            }
        }
        protected void LoadPlants_Click(object sender, EventArgs e)
        {
            LoadPlants();
        }

        protected void HidePlants_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false; // Hide the plant list
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

        private void LoadUsers()
        {
            try
            {
                localhostU.userService webService = new localhostU.userService();
                List<localhostU.User> users = webService.GetUsers().ToList();

                // Bind the user list to a GridView or any other suitable control
                DataGridViewUsers.DataSource = users;
                DataGridViewUsers.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error loading users: " + ex.Message;
            }
        }

        protected void FilterUsers_Click(object sender, EventArgs e)
        {
            try
            {
                string filterType = ddlUserTypeFilter.SelectedValue;

                localhostU.userService webService = new localhostU.userService();

                List<localhostU.User> filteredUsers;

                if (filterType == "Admins")
                {
                    filteredUsers = webService.GetAdmins().ToList();
                }
                else if (filterType == "Regular")
                {
                    filteredUsers = webService.GetRegularUsers().ToList();
                }
                else
                {
      
                    filteredUsers = webService.GetUsers().ToList(); // For example, show all users if no filter is selected
                }

                if (filterType == "Admins")
                {
                    DataGridViewUsers.DataSource = filteredUsers;
                    DataGridViewUsers.DataBind();
                }
                else if (filterType == "Regular")
                {
                    DataGridViewUsers.DataSource = filteredUsers;
                    DataGridViewUsers.DataBind();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error filtering users: " + ex.Message;
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                localhostU.userService webService = new localhostU.userService();

                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string adminStatus = ddlAdminStatus.SelectedValue;
 
                webService.AddUser(username, password, adminStatus);

                LoadUsers();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error creating user: " + ex.Message;
            }
        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                localhostU.userService webService = new localhostU.userService();

                string userId = txtUserId.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string adminStatus = ddlAdminStatus.SelectedValue;

                webService.UpdateUser(userId, username, password, adminStatus);

                LoadUsers();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error updating user: " + ex.Message;
            }
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                localhostU.userService webService = new localhostU.userService();

                string userId = txtUserId.Text;

                webService.DeleteUser(userId);

                LoadUsers();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error deleting user: " + ex.Message;
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
                btnCreateUser.Text = GetTranslation("Create");
                btnUpdateUser.Text = GetTranslation("Update");
                btnDeleteUser.Text = GetTranslation("Delete");

                btnSortByType.Text = GetTranslation("Type");
                btnSortBySpecies.Text = GetTranslation("Species");
                btnFilter.Text = GetTranslation("Filter");
                btnSearch.Text = GetTranslation("Search");
                btnResetList.Text = GetTranslation("Reset");

                btnLoadPlants.Text = GetTranslation("Load");
                btnHidePlants.Text = GetTranslation("Hide");
                btnFilterUsers.Text = GetTranslation("FilterUsers");
            }
        }

        private string GetTranslation(string key)
        {
            return dict.ContainsKey(key) ? dict[key] : key;
        }


    }
}
