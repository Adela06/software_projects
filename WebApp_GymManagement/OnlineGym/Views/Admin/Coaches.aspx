<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Coaches.aspx.cs" Inherits="OnlineGym.Views.Admin.Coaches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
            font-family: Poppins;
        }

        body {
            margin: 0;
            padding: 0;
        }

        .table-container {
            background: url("../../Assets/Images/coach.jpg");
            background-size: cover;
            padding: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div class="container-fluid">
        <div>
            <label for="ImageUpload" class="form-label">Coach's Image</label>
            <asp:FileUpload ID="ImageUpload" runat="server" />
        </div>

        <div class="row">
            <div class="col-md-3">
                <h4 class="text-primary">Coach's Details</h4>
                <div class="mb-1">
                    <label for="CNameTb" class="form-label">Coach's Name</label>
                    <input type="text" class="form-control" id="CNameTb" runat="server" autocomplete="off">
                </div>
                <div class="mb-1">
                    <label for="CGenCb" class="form-label">Coach's Gender</label>
                    <asp:DropDownList runat="server" class="form-control" ID="CGenCb">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <label for="CDOBTb" class="form-label">Coach's Date of birth</label>
                    <input type="date" class="form-control" id="CDOBTb" runat="server">
                </div>
                <div>
                    <label for="PhoneTb" class="form-label">Coach's Phone</label>
                    <input type="text" class="form-control" id="PhoneTb" runat="server" autocomplete="off">
                </div>
                <div>
                    <label for="ExpTb" class="form-label">Coach's Experience</label>
                    <input type="text" class="form-control" id="ExpTb" runat="server" autocomplete="off">
                </div>
                <div>
                    <label for="CAddTb" class="form-label">Coach's Address</label>
                    <input type="text" class="form-control" id="CAddTb" runat="server" autocomplete="off">
                </div>
                <div>
                    <label for="PasswordTb" class="form-label">Coach's Password</label>
                    <input type="text" class="form-control" id="PasswordTb" runat="server" autocomplete="off">
                </div>
                <div class="mb-1">
                    <label for="EmailTb" class="form-label">Coach's Email</label>
                    <input type="text" class="form-control" id="EmailTb" runat="server" autocomplete="off">
                </div>
                <div class="row">
                    <label runat="server" id="ErrMsg" class="text-danger"></label>
                    <div class="col d-grid">
                        <asp:Button Text="Edit" CssClass="btn btn-block btn-warning text-white-50" ID="EditBtn" runat="server" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Add" CssClass="btn btn-block btn-primary" runat="server" ID="AddBtn" OnClick="AddBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Delete" CssClass="btn btn-block btn-danger" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                    </div>
                                    <div class="mb-1">
    
    <input type="text" class="form-control" id="SearchTb" runat="server" placeholder="Search by Name" autocomplete="off">
</div>
<div class="col d-grid">
    <asp:Button Text="Search" CssClass="btn btn-block btn-primary text-white-50" runat="server" OnClick="SearchBtn_Click" />
</div>

                </div>
            </div>
            <div class="col-md-9">
                <div class="table-container">
                    <asp:GridView runat="server" ID="CoachList" class="table" OnSelectedIndexChanged="CoachList_SelectedIndexChanged" AutoGenerateSelectButton="True"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>