using gradinaTema1.Model;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace gradinaTema1.View
{

    public partial class PlantForm : Form
    {

        public PlantForm()
        {
            InitializeComponent();
           

        }


        public Button getTipButton() { return button1; }
        public Button getSpecieButton() { return button2; }
        public Button getSearchButton() { return button3; }
        public Button getFilterButton() { return button5; }
        public Button getLoginButton() { return button4; }
        public Button getRomanaButton() { return button6;}
        public Button getEnglezaButton() { return button7; }
        public Button getGermanaButton() { return button8; }

        public ComboBox GetCombo() { return comboBox1; }

        public TextBox getName() { return textBox2; }
        public TextBox getFiltrare() { return textBox1; }

        public Label getSortLabel() { return label2; }
        public Label getSelectLabel() { return label3; }
        public Label getEnterLabel() { return label4; }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public DataGridView getPlants()
        {
            return dataGridView1;
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

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

