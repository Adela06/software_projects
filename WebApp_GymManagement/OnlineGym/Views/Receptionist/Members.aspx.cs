using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Receptionist
{
    public partial class Members : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMembers();
                GetCoaches();
                GetMemberships();
            }
        }

        private void GetCoaches()
        {
            string Query = "select * from CoachT";
            CoachCb.DataTextField = Con.GetData(Query).Columns["CName"].ToString();
            CoachCb.DataValueField = Con.GetData(Query).Columns["CId"].ToString();
            CoachCb.DataSource = Con.GetData(Query);
            CoachCb.DataBind();
        }

        private void GetMemberships()
        {
            string Query = "select * from MembershipTbl";
            MShipCb.DataTextField = Con.GetData(Query).Columns["MName"].ToString();
            MShipCb.DataValueField = Con.GetData(Query).Columns["MShip"].ToString();
            MShipCb.DataSource = Con.GetData(Query);
            MShipCb.DataBind();
        }

        private void ShowMembers()
        {
            string Query = "select * from MembersTbl";
            MembersList.DataSource = Con.GetData(Query);
            MembersList.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            try
            {
                string MName = MNameTb.Value;
                string Gen = MGenCb.SelectedValue;
                string MDOB = MDOBTb.Value;
                string MJD = MJDateTb.Value;
                string MShip = MShipCb.SelectedValue;
                string MCoach = CoachCb.SelectedValue;
                string MPhone = PhoneTb.Value;
                string Timing = TimingCb.SelectedValue;
                string Status = StatusCb.SelectedValue;

                string Query = "insert into MembersTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
                Query = string.Format(Query, MName, Gen, MDOB, MJD, MShip, MCoach, MPhone, Timing,Status);
                Con.setData(Query);
                ShowMembers();
                ErrMsg.InnerText = "Member Added";

                MNameTb.Value = "";
                MDOBTb.Value = "";
                PhoneTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string MName = MNameTb.Value;
                string Gen = MGenCb.SelectedValue;
                string MDOB = MDOBTb.Value;
                string MJD = MJDateTb.Value;
                string MShip = MShipCb.SelectedValue;
                string MCoach = CoachCb.SelectedValue;
                string MPhone = PhoneTb.Value;
                string Timing = TimingCb.SelectedValue;
                string Status = StatusCb.SelectedValue;

                string Query = "update MembersTbl set MName='{0}',MGen='{1}',MDOB='{2}',MDate='{3}',MMembership='{4}',MCoach='{5}',MPhone='{6}',MTiming='{7}',Status='{8}' where MId='{9}'";
                Query = string.Format(Query, MName, Gen, MDOB, MJD, MShip, MCoach, MPhone, Timing, Status, MembersList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowMembers();
                ErrMsg.InnerText = "Member Edited";

                MNameTb.Value = "";
                MDOBTb.Value = "";
                PhoneTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void MembersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MNameTb.Value = MembersList.SelectedRow.Cells[2].Text;
            MGenCb.Text = MembersList.SelectedRow.Cells[3].Text;

            MDOBTb.Value = MembersList.SelectedRow.Cells[4].Text;
            MJDateTb.Value = MembersList.SelectedRow.Cells[5].Text;

            MShipCb.SelectedValue = MembersList.SelectedRow.Cells[6].Text;
            CoachCb.SelectedValue = MembersList.SelectedRow.Cells[7].Text;

            PhoneTb.Value = MembersList.SelectedRow.Cells[8].Text;
            StatusCb.SelectedValue = MembersList.SelectedRow.Cells[9].Text;
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string MName = MNameTb.Value;
                string Gen = MGenCb.SelectedValue;
                string MDOB = MDOBTb.Value;
                string MJD = MJDateTb.Value;
                string MShip = MShipCb.SelectedValue;
                string MCoach = CoachCb.SelectedValue;
                string MPhone = PhoneTb.Value;
                string Timing = TimingCb.SelectedValue;
                string Status = StatusCb.SelectedValue;

                string Query = "delete from MembersTbl where MId='{0}'";
                Query = string.Format(Query, MembersList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowMembers();
                ErrMsg.InnerText = "Member Deleted";

                MNameTb.Value = "";
                MDOBTb.Value = "";
                PhoneTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        //search
        private void ShowReceptionist(string searchName = "")
        {
            string query = "SELECT * FROM MembersTbl";

            if (!string.IsNullOrEmpty(searchName))
            {
                query += $" WHERE MName LIKE '%{searchName}%'";
            }

            MembersList.DataSource = Con.GetData(query);
            MembersList.DataBind();
        }

        private void SearchReceptionist(string searchName)
        {
            ShowReceptionist(searchName);
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = MeSearchTb.Value.Trim();
                SearchReceptionist(searchName);
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }


        //search
    }
}