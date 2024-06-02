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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gradinaTema1.View
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            

        }
        public DataGridView getPlants()
        {
            return dataGridView1;
        }

        public Button getCreateButton()
        {
            return button1;
        }

        public Button getDeleteButton() { return button3;}
        public Button getUpdateButton() { return button2;}
        public Button getTipButton() { return button4;}
        public Button getSpecieButton() { return button5; }
        public Button getSearchButton() { return button6; }
        public Button getStatistici() { return button11;}
        public Button getFiltered() { return button12;}

        public Button getCSVButton() { return button7; }
        public Button getJSONButton() { return button8; }
        public Button getXMLButton() { return button9; }
        public Button getDOCButton() { return button10; }
        public ComboBox GetCombo() { return comboBox1; }

        public TextBox getName() {  return textBox2; }
        public TextBox getTip() { return textBox3;}
        public TextBox getSpecie() {  return textBox4; }
        public TextBox getLocatie() {  return textBox5; }
        public TextBox getCarnivora() {  return textBox6; }

        public TextBox getFiltrare() { return textBox1; }
        public TextBox getCautare() { return textBox7; }

        public Button getRomanaButton() { return button15; }
        public Button getEnglezaButton() { return button14; }
        public Button getGermanaButton() { return button13; }

        public Label getSelectLabel() { return label2; }
        public Label getSortLabel() { return label1; }
        public Label getEnterLabel() { return label8; }
        public Label getSaveLabel() { return label9; }

        public Label getName1() { return label3; }
        public Label getTip1() { return label4; }
        public Label getSpecie1() { return label5; }
        public Label getLocatie1() { return label6; }
        public Label getCarnivora1() { return label7; }



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
           
        }
    }
}
