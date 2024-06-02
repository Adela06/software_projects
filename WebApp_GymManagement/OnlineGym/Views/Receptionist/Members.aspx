<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="OnlineGym.Views.Receptionist.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
            <div class="container-fluid">
        <div class="row">
        <div class ="col-md-3">
            <h4 class="text-primary">Member's Details</h4>
             <div class="mb-1">
   <label for="MNameTb" class="form-label">Member's Name</label>
   <input type="text" class="form-control" id="MNameTb" runat="server" autocomplete="off">
 </div>
            <div class="mb-1">
  <label for="MGenCb" class="form-label">Member's Gender</label>
  <asp:DropDownList runat="server" class="form-control" ID="MGenCb">
      <asp:ListItem>Male</asp:ListItem>
      <asp:ListItem>Female</asp:ListItem>
  </asp:DropDownList>
</div>
            <div>
  <label for="MDOBTb" class="form-label">Member's Date of birth</label>
  <input type="date" class="form-control" id="MDOBTb" runat="server">
</div>

                        <div>
  <label for="MJDateTb" class="form-label">Member's Joining Date</label>
  <input type="date" class="form-control" id="MJDateTb" runat="server">
</div>
            <div>
  <label for="MShipCb" class="form-label">Membership</label>
    <asp:DropDownList runat="server" class="form-control" ID="MShipCb">
        
  </asp:DropDownList>
</div>
                        <div>
  <label for="CoachCb" class="form-label">Coach</label>
    <asp:DropDownList runat="server" class="form-control" ID="CoachCb">
        
  </asp:DropDownList>
</div>
            <div>
  <label for="PhoneTb" class="form-label">Member's Phone</label>
  <input type="text" class="form-control" id="PhoneTb" runat="server" autocomplete="off">
            <div class="mb-1">
  <label for="TimingCb" class="form-label">Timing</label>
      <asp:DropDownList runat="server" class="form-control" ID="TimingCb">
      <asp:ListItem>6AM - 8AM</asp:ListItem>
      <asp:ListItem>8AM - 10AM</asp:ListItem>
      <asp:ListItem>10AM - 12PM</asp:ListItem>
      <asp:ListItem>12PM - 2PM</asp:ListItem>
      <asp:ListItem>2PM - 4PM</asp:ListItem>
      <asp:ListItem>4PM - 6PM</asp:ListItem>
      <asp:ListItem>6PM - 8PM</asp:ListItem>
      <asp:ListItem>8PM - 10PM</asp:ListItem>
  </asp:DropDownList>
</div>
            <div class="mb-1">
  <label for="StatusCb" class="form-label">Status</label>
      <asp:DropDownList runat="server" class="form-control" ID="StatusCb">
      <asp:ListItem>Pending</asp:ListItem>
      <asp:ListItem>Cancelled</asp:ListItem>
  </asp:DropDownList>
</div>
            <div class="row">
                <label id="ErrMsg" runat="server" class="text-danger"></label>
                <div class="col d-grid">
                    <asp:Button Text="Edit" CssClass="btn btn-block btn-warning text-white-50" runat="server" ID="EditBtn" OnClick="EditBtn_Click"/>
                </div>
                <div class="col d-grid">
                    <asp:Button Text="Add" CssClass="btn btn-block btn-primary text-white-50" runat="server" OnClick="Unnamed2_Click" ID="AddBtn" />
                </div>
                <div class="col d-grid">
                    <asp:Button Text="Delete" CssClass="btn btn-block btn-danger text-white-50" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                </div>

            </div>
        </div>
            <div class="col-md-9">
                <div class="mb-1">
    <input type="text" class="form-control" id="MeSearchTb" runat="server" placeholder="Search by Name" autocomplete="off">
</div>
<div class="col d-grid">
    <asp:Button Text="Search" CssClass="btn btn-block btn-primary text-white-50" runat="server" OnClick="SearchBtn_Click" />
</div>
                <asp:GridView runat="server" ID="MembersList" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="MembersList_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </div>
                </div>
</asp:Content>
