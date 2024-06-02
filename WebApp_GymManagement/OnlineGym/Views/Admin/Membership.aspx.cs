using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Admin
{
    public partial class Membership : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMembership();
            }
        }

        private void ShowMembership()
        {
            string Query = "select * from MembershipTbl";
            MembershipList.DataSource = Con.GetData(Query);
            MembershipList.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                string MName = MNameTb.Value;
                string MDuration = DurationTb.Value;
                string MGoal = GoalTb.Value;
                string MCost = CostTb.Value;

                string Query = "insert into MembershipTbl values('{0}','{1}','{2}','{3}')";
                Query = string.Format(Query, MName, MDuration, MGoal, MCost);
                Con.setData(Query);
                ShowMembership();
                ErrMsg.InnerText = "Membership Added";

                MNameTb.Value = "";
                DurationTb.Value = "";
                GoalTb.Value = "";
                CostTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try {
                string MName = MNameTb.Value;
                string MDuration = DurationTb.Value;
                string MGoal = GoalTb.Value;
                string MCost = CostTb.Value;

                string Query = "update MembershipTbl set MName='{0}',MDuration='{1}',MGoal='{2}',MCost='{3}' where MShip='{4}'";
                Query = string.Format(Query, MName, MDuration, MGoal, MCost, MembershipList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowMembership();
                ErrMsg.InnerText = "Membership Updated";

                MNameTb.Value = "";
                DurationTb.Value = "";
                GoalTb.Value = "";
                CostTb.Value = "";
            }
            catch (Exception Ex){
            ErrMsg.InnerText = Ex.Message;
            }
            
        }

        protected void MembershipList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MNameTb.Value = MembershipList.SelectedRow.Cells[2].Text;
            DurationTb.Value = MembershipList.SelectedRow.Cells[3].Text;

            GoalTb.Value = MembershipList.SelectedRow.Cells[4].Text;
            CostTb.Value = MembershipList.SelectedRow.Cells[5].Text;

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "Delete from MembershipTbl where MShip = {0}";
                Query = string.Format(Query, MembershipList.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowMembership();
                ErrMsg.InnerText = "Membership Deleted";

                MNameTb.Value = "";
                DurationTb.Value = "";
                GoalTb.Value = "";
                CostTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}