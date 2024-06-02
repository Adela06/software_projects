using gradinaTema1.Model;
using gradinaTema1.Presenter;
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
    public partial class AdminForm : Form, IUserGUI
    {
        private UserPresenter presenter;
        public AdminForm()
        {
            InitializeComponent();
            this.presenter = new UserPresenter();
            presenter.Initialize(this);

            presenter.UserList();
        }

        public void HideForm()
        {
            this.Hide();
        }

        public void SetMessage(string title, string message)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.newPlantPage();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        public void SetMessage(string v)
        {
         
        }

        public void SetTableList(List<User> users)
        {
            foreach (User u in users)
            {
                dataGridView1.Rows.Add(u.Id,u.Password, u.Username,u.AdminStatus);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create user
            presenter.addUser();
            dataGridView1.Rows.Clear();
            presenter.UserList();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        public string getUsername()
        {
            return textBox1.Text;
        }

        public string getPassword()
        {
            return textBox2.Text;
        }

        public string getAdminStatus()
        {
            return textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            presenter.deleteUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.Rows.Clear();
            presenter.UserList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            presenter.updateUser(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.Rows.Clear();
            presenter.UserList();
        }
    }
}
