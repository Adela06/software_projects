using gradinaTema1.Model;
using gradinaTema1.Presenter;
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
    public partial class EmployeeForm : Form, IPlantGUI
    {
        private EmployeePresenter presenter;
        public EmployeeForm()
        {
            InitializeComponent();
            presenter = new EmployeePresenter();
            presenter.Initialize(this);

            presenter.PlantList("");
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create plant
            presenter.addPlant();
            dataGridView1.Rows.Clear();
            presenter.PlantList("");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
        public string getName()
        {
            return textBox2.Text;
        }

        public string getTip()
        {
            return textBox3.Text;
        }
        public string getSpecie()
        {
            return textBox4.Text;
        }
        public string getLocatie()
        {
            return textBox5.Text;
        }
        public string getCarnivore()
        {
            return textBox6.Text;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            presenter.deletePlant(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.Rows.Clear();
            presenter.PlantList("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("Tip");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("Specie");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presenter.PlantList("");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        public string GetSelectedFilter()
        {
            Console.Write(comboBox1.GetItemText(comboBox1.SelectedIndex));
            if (comboBox1.SelectedItem != null)
            {
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                return "No item selected";
            }
        }


        void IPlantGUI.SetTableList(List<Plant> plants)
        {
            foreach (Plant p in plants)
            {
                dataGridView1.Rows.Add(p.Id, p.PlantName, p.Species, p.PlantType, p.Location, p.Carnivorous);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//update plant
            presenter.updatePlant(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.Rows.Clear();
            presenter.PlantList("");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
