using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Admin
{
    public partial class Coaches : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {

            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowCoaches();
            }
        }


        private void ShowCoaches()
        {
            string Query = "select * from CoachT";
            CoachList.DataSource = Con.GetData(Query);
            CoachList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
         {
             try
             {
                 string CName = CNameTb.Value;
                 string CDOB = CDOBTb.Value;
                 string CExp = ExpTb.Value;
                 string CAdd = CAddTb.Value;
                 string CPhone = PhoneTb.Value;
                 string CGen = CGenCb.SelectedValue;
                 string CPass = PasswordTb.Value;
                 string CEmail = EmailTb.Value;

                 // Check if a file is uploaded
                 if (ImageUpload.HasFile)
                 {
                     // Specify the virtual path where you want to save the uploaded image
                     string virtualFolderPath = "~/PhotoUploads/";

                     // Map the virtual path to a physical path
                     string uploadFolderPath = Server.MapPath(virtualFolderPath);

                     // Get the file name
                     string fileName = Path.GetFileName(ImageUpload.FileName);

                     // Combine the physical path and file name
                     string filePath = Path.Combine(uploadFolderPath, fileName);

                     // Ensure that the directory exists; create it if not
                     if (!Directory.Exists(uploadFolderPath))
                     {
                         Directory.CreateDirectory(uploadFolderPath);
                     }

                     // Save the file to the server
                     ImageUpload.SaveAs(filePath);
                 }

                 string Query = "insert into CoachT (CName, CGen, CDOB, CPhone, CExperience, CAddress, CPass, CEmail) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                 Query = string.Format(Query, CName, CGen, CDOB, CPhone, CExp, CAdd, CPass, CEmail);
                 Con.setData(Query);
                 ShowCoaches();
                 ErrMsg.InnerText = "Coach Added";

                 CNameTb.Value = "";
                 CDOBTb.Value = "";
                 ExpTb.Value = "";
                 CAddTb.Value = "";
                 PhoneTb.Value = "";
                 PasswordTb.Value = "";
                 EmailTb.Value = "";
             }
             catch (Exception ex)
             {
                 ErrMsg.InnerText = ex.Message;
             }
         }


        //pt search

        private void ShowCoaches(string searchName = "")
        {
            string query = "SELECT * FROM CoachT";

            if (!string.IsNullOrEmpty(searchName))
            {
                query += $" WHERE CName LIKE '%{searchName}%'";
            }

            CoachList.DataSource = Con.GetData(query);
            CoachList.DataBind();
        }

        private void SearchReceptionist(string searchName)
        {
            ShowCoaches(searchName);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = SearchTb.Value.Trim();
                SearchReceptionist(searchName);
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        //pt search


        protected void CoachList_SelectedIndexChanged(object sender, EventArgs e)
           {
               CNameTb.Value = CoachList.SelectedRow.Cells[2].Text;
               CGenCb.Text = CoachList.SelectedRow.Cells[3].Text;

               PhoneTb.Value = CoachList.SelectedRow.Cells[5].Text;
               ExpTb.Value = CoachList.SelectedRow.Cells[6].Text;

               CAddTb.Value = CoachList.SelectedRow.Cells[7].Text;
               PasswordTb.Value = CoachList.SelectedRow.Cells[8].Text;
               EmailTb.Value = CoachList.SelectedRow.Cells[9].Text;
           }

        protected void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string CName = CNameTb.Value;
                string CDOB = CDOBTb.Value;
                string CExp = ExpTb.Value;
                string CAdd = CAddTb.Value;
                string CPhone = PhoneTb.Value;
                string CGen = CGenCb.SelectedValue;
                string CPass = PasswordTb.Value;
                string CEmail = EmailTb.Value;

                string Query = "update CoachT set CName='{0}',CGen='{1}',CDOB='{2}',CPhone='{3}',CExperience='{4}',CAddress='{5}',CPass='{6}',CEmail='{7}' where CId = '{8}'";
                Query = string.Format(Query, CName, CGen, CDOB, CPhone, CExp, CAdd, CPass, CEmail, CoachList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCoaches();
                ErrMsg.InnerText = "Coach Edited";

                CNameTb.Value = "";
                CDOBTb.Value = "";
                ExpTb.Value = "";
                CAddTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CName = CNameTb.Value;
                string CDOB = CDOBTb.Value;
                string CExp = ExpTb.Value;
                string CAdd = CAddTb.Value;
                string CPhone = PhoneTb.Value;
                string CGen = CGenCb.SelectedValue;
                string CPass = PasswordTb.Value;
                string CEmail = EmailTb.Value;

                string Query = "delete from CoachT where CId = '{0}'";
                Query = string.Format(Query, CoachList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCoaches();
                ErrMsg.InnerText = "Coach Deleted";

                CNameTb.Value = "";
                CDOBTb.Value = "";
                ExpTb.Value = "";
                CAddTb.Value = "";
                PhoneTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}
