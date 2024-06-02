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
    public partial class AdminForm : Form
    {
       
        public AdminForm()
        {
            InitializeComponent();
            
        }

        public void SetMessage(string title, string message)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
        public DataGridView getUsers()
        {
            return dataGridView1;
        }

        public Button getAddButton() { return button2; }
        public Button getUpdateButton() { return button4; }
        public Button getDeleteButton() { return button3; }

        public TextBox getUsernameTextBox() { return textBox2; }
        public TextBox getPasswordTextBox() { return textBox3; }
        public TextBox getAdminStatusTextBox() { return textBox1; }

        public Button getRomanaButton() { return button6; }
        public Button getEnglezaButton() { return button7; }
        public Button getGermanaButton() { return button8; }

        public CheckBox getAdminStatusCheckBox() { return checkBox1;}
        public CheckBox getEmployeeStatusCheckBox() {  return checkBox2; }

        public Label getUsernameLabel() { return label1; }
        public Label getPasswordLabel() { return label2; }
        public Label getStatusLabel() { return label3; }

        public void SetMessage(string v)
        {
         
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //create user
        }


        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
