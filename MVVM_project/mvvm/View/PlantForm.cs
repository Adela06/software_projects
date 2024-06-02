using gradinaTema1.Model;
using gradinaTema1.Model.Repository;
using gradinaTema1.ViewModel;
using gradinaTema1.ViewModel.Commands;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace gradinaTema1.View
{

    public partial class PlantForm : Form
    {

        private PlantVM plantVM;

        public PlantForm()
        {
            InitializeComponent();
            this.plantVM = new PlantVM(this, dataGridView1);
            this.dataGridView1.DataSource = this.plantVM.plants;

            //sortare dupa specie
            this.button2.Click += delegate { plantVM.SortSpecies.Execute(); };
          
            //sortare dupa tip
             this.button1.Click += delegate { plantVM.SortTypes.Execute();  };

            //filtrare
            //binding pentru ComboBox
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            //search
            this.button3.Click += delegate {
                plantVM.SearchPlantName.SetPlantName(textBox2.Text);
                plantVM.SearchPlantName.Execute();
            };
            //login
            this.button4.Click += delegate { plantVM.GoToLoginPage.Execute(); this.plantVM.ViewPlants.Execute(); };


            this.plantVM.ViewPlants.Execute();

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBox1.SelectedItem.ToString();
            string searchText = textBox1.Text;

            plantVM.FilterPlants.FilterBy = selectedFilter;
            plantVM.FilterPlants.SearchText = searchText;

            plantVM.FilterPlants.Execute();
        }

        public void SetMessage(string v)
        {
            
        }

        public void SetMessage(string title, string message)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void PlantForm_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // dataGridView1.Rows.Clear();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
 
        }
    }
}

