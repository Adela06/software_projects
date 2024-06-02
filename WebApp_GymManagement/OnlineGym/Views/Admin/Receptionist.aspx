<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Receptionist.aspx.cs" Inherits="OnlineGym.Views.Admin.Receptionist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function RemoveTokenFromLocalStorage() {
        localStorage.removeItem("AuthToken");
    }
    </script>

<style>
    * {
        font-family: 'Poppins', sans-serif;
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        position: relative;
        height: 100vh;
        text-align: center;
        background: url("../../Assets/Images/recep.png") right top no-repeat;
        background-size: 18%;
        background-position: right top 100px;
    }

    .container {
        max-width: 800px;
        margin: 0 auto;
    }

    h2, p {
        color: #333;
    }

    h2 {
        margin-top: 100px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
      <div class="container-fluid">
        <div class="row">
        <div class ="col-md-3">
            <h4 class="text-primary">Receptionist's Details</h4>
             <div class="mb-1">
   <label for="RecTb" class="form-label">Receptionist's Name</label>
   <input type="text" class="form-control" id="RecTb" runat="server" autocomplete="off">
 </div>
            <div class="mb-1">
  <label for="RGenCb" class="form-label">Receptionist's Gender</label>
  <asp:DropDownList runat="server" class="form-control" ID="RGenCb">
      <asp:ListItem>Male</asp:ListItem>
      <asp:ListItem>Female</asp:ListItem>
  </asp:DropDownList>
</div>
            <div>
  <label for="RDOBTb" class="form-label">Receptionist's Date of birth</label>
  <input type="date" class="form-control" id="RDOBTb" runat="server">
</div>
            <div>
  <label for="RecAddTb" class="form-label">Receptionist's Address</label>
  <input type="text" class="form-control" id="RecAddTb" runat="server" autocomplete="off">
</div>
            <div>
  <label for="PhoneTb" class="form-label">Receptionist's Phone</label>
  <input type="text" class="form-control" id="PhoneTb" runat="server" autocomplete="off">
            <div class="mb-1">
  <label for="PasswordTb" class="form-label">Receptionist's Password</label>
  <input type="text" class="form-control" id="PasswordTb" runat="server" autocomplete="off">
</div>
            <div class="mb-1">
  <label for="EmailTb" class="form-label">Receptionist's Email</label>
  <input type="text" class="form-control" id="EmailTb" runat="server" autocomplete="off">
</div>
            <div class="row">
                <label id="ErrMsg" runat="server" class="text-danger"></label>
                <div class="col d-grid">
                    <asp:Button Text="Edit" CssClass="btn btn-block btn-warning text-white-50" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                </div>
                <div class="col d-grid">
                    <asp:Button Text="Add" CssClass="btn btn-block btn-primary text-white-50" runat="server" OnClick="Unnamed2_Click" ID="AddBtn" />
                </div>
                <div class="col d-grid">
                    <asp:Button Text="Delete" CssClass="btn btn-block btn-danger text-white-50" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                </div>

                <div class="mb-1">
    <input type="text" class="form-control" id="SearchTb" runat="server" placeholder="Search by Name" autocomplete="off">
</div>
<div class="col d-grid">
    <asp:Button Text="Search" CssClass="btn btn-block btn-primary text-white-50" runat="server" OnClick="SearchBtn_Click" />
</div>

                <div>

                </div>

            </div>
        </div>
            <div class="col-md-9">
                <asp:GridView runat="server" ID="ReceptionistList" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ReceptionistList_SelectedIndexChanged"></asp:GridView>
            </div>

        </div>
    </div>
</div>
</asp:Content>
