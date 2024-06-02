using gradinaTema1.Model;
using gradinaTema1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradinaTema1.View
{
    public partial class EmployeeForm : Form
    {
        private PlantVM plantvm;
        public EmployeeForm()
        {
            InitializeComponent();
            this.plantvm = new PlantVM(dataGridView1);

            this.textBox2.DataBindings.Add("Text", this.plantvm, "plantName", false, DataSourceUpdateMode.OnValidation);
            this.textBox3.DataBindings.Add("Text", this.plantvm, "plantType", false, DataSourceUpdateMode.OnValidation);
            this.textBox4.DataBindings.Add("Text", this.plantvm, "species", false, DataSourceUpdateMode.OnValidation);
            this.textBox5.DataBindings.Add("Text", this.plantvm, "location", false, DataSourceUpdateMode.OnValidation);
            this.textBox6.DataBindings.Add("Text", this.plantvm, "carnivorous", false, DataSourceUpdateMode.OnValidation);



            this.dataGridView1.DataSource = this.plantvm.plants;
            this.button1.Click += delegate { plantvm.AddPlant.Execute(); this.plantvm.ViewPlants.Execute(); };
            this.button2.Click += delegate { plantvm.UpdatePlants.Execute(); this.plantvm.ViewPlants.Execute(); };
            this.button3.Click += delegate { plantvm.DeletePlants.Execute(); this.plantvm.ViewPlants.Execute(); };

            //sortare dupa specie
            this.button5.Click += delegate { plantvm.SortSpecies.Execute(); };

            //sortare dupa tip
            this.button4.Click += delegate { plantvm.SortTypes.Execute(); };

            //filtrare
            //binding pentru ComboBox
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            //search
            this.button6.Click += delegate {
                plantvm.SearchPlantName.SetPlantName(textBox7.Text);
                plantvm.SearchPlantName.Execute();
            };

            this.plantvm.ViewPlants.Execute();

            //salvare csv
            this.button7.Click += delegate {
                this.plantvm.InitializeSaveAsCSVCommand(dataGridView1);
                this.plantvm.SaveAsCSV.Execute();
            };

            //salvare doc
            this.button10.Click += delegate {
                this.plantvm.InitializeSaveAsDOCCommand(dataGridView1);
                this.plantvm.SaveAsDOC.Execute();
            };

            //salvare json
            this.button8.Click += delegate {
                this.plantvm.InitializeSaveAsJSONCommand(dataGridView1);
                this.plantvm.SaveAsJSON.Execute();
            };

            //salvare xml
            this.button9.Click += delegate {
                this.plantvm.InitializeSaveAsXMLCommand(dataGridView1);
                this.plantvm.SaveAsXML.Execute();
            };

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
        
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {//update plant
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboBox1.SelectedItem.ToString();
            string searchText = textBox1.Text;

            // Set filterBy and searchText properties of FilterPlantsCommand instance
            plantvm.FilterPlants.FilterBy = selectedFilter;
            plantvm.FilterPlants.SearchText = searchText;

            plantvm.FilterPlants.Execute();
        }
    }
}
