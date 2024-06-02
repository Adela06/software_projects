using gradinaTema1.Model;

using gradinaTema1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradinaTema1.View
{
    public partial class AdminForm : Form
    {
        private UserVM uservm;
        public AdminForm()
        {
            InitializeComponent();
            this.uservm = new UserVM(this,dataGridView1);
            this.textBox2.DataBindings.Add("Text", this.uservm, "username", false, DataSourceUpdateMode.OnValidation);
            this.textBox3.DataBindings.Add("Text", this.uservm, "password", false, DataSourceUpdateMode.OnValidation);
            this.textBox1.DataBindings.Add("Text", this.uservm, "adminStatus", false, DataSourceUpdateMode.OnValidation);


            this.dataGridView1.DataSource = this.uservm.users;
            
            this.button2.Click += delegate { uservm.CreateUser.Execute(); this.uservm.ViewUsers.Execute(); };
            this.button3.Click += delegate { uservm.DeleteUser.Execute(); this.uservm.ViewUsers.Execute(); };
            this.button4.Click += delegate { uservm.UpdateUser.Execute(); this.uservm.ViewUsers.Execute(); };
            this.button1.Click += delegate { uservm.GoToGuestPage.Execute(); this.uservm.ViewUsers.Execute(); };
            this.uservm.ViewUsers.Execute();
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
