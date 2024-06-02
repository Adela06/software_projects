using gradinaTema1.Model;
using gradinaTema1.Presenter;
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

    public partial class PlantForm : Form, IPlantGUI
    {

        private PlantPresenter presenter;

        public PlantForm()
        {
            InitializeComponent();
            presenter = new PlantPresenter();
            presenter.Initialize(this);

            presenter.PlantList("");

        }

        public string GetSearchedInformation()
        {
            Console.WriteLine(textBox1.Text);
            return textBox1.Text;
        }

        public void HideForm()
        {
           this.Hide();
        }

        public void SetMessage(string v)
        {
            
        }

        public void SetMessage(string title, string message)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("Tip");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void PlantForm_Load(object sender, EventArgs e)
        {

        }

        void IPlantGUI.SetTableList(List<Plant> plants)
        {
           foreach (Plant p in plants)
            {
                dataGridView1.Rows.Add(p.Id, p.PlantName, p.Species, p.PlantType, p.Location, p.Carnivorous);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("Specie");
        }

        public string GetSelectedFilter()
        {
            Console.Write(comboBox1.GetItemText(comboBox1.SelectedIndex));
            //string selectedItem = comboBox1.SelectedItem.ToString();
            //return comboBox1.GetItemText(selectedItem);
            //return comboBox1.GetItemText(comboBox1.SelectedIndex);
            if (comboBox1.SelectedItem != null)
            {
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                return "No item selected";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            presenter.newLoginForm();
        }

        public string getName()
        {
            throw new NotImplementedException();
        }

        public string getTip()
        {
            throw new NotImplementedException();
        }

        public string getSpecie()
        {
            throw new NotImplementedException();
        }

        public string getLocatie()
        {
            throw new NotImplementedException();
        }

        public string getCarnivore()
        {
            throw new NotImplementedException();
        }
    }
}

