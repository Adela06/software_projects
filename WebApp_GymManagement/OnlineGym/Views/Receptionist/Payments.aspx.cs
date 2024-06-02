using OnlineGym.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Receptionist
{
    public partial class Payments : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowPayments();
                GetMembers();
            }
        }
        private void ShowPayments()
        {
            string Query = "select * from FinanceTbl";
            PaymentList.DataSource = Con.GetData(Query);
            PaymentList.DataBind();
        }
        private void GetMembers()
        {
            string Query = "select * from MembersTbl";
            MemberCb.DataTextField = Con.GetData(Query).Columns["MName"].ToString();
            MemberCb.DataValueField = Con.GetData(Query).Columns["MId"].ToString();
            MemberCb.DataSource = Con.GetData(Query);
            MemberCb.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Member = MemberCb.SelectedValue.ToString();
                string PDate = PaymentDateTb.Value;
                string Agent = Admin.Login.AgentId;
                string Amount = AmountTb.Value;

                string Query = "insert into FinanceTbl values('{0}','{1}','{2}','{3}')";
                Query = string.Format(Query, Agent, Member, PDate, Amount);
                Con.setData(Query);
                ShowPayments();
                ErrMsg.InnerText = "Payment Added";

                AmountTb.Value = "";
                MemberCb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void PaymentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MemberCb.Text = PaymentList.SelectedRow.Cells[2].Text;
            Admin.Login.AgentId = PaymentList.SelectedRow.Cells[2].Text;
            PaymentDateTb.Value = PaymentList.SelectedRow.Cells[3].Text; 
            AmountTb.Value = PaymentList.SelectedRow.Cells[4].Text;
           
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

