<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="OnlineGym.Views.Admin.Membership" %>
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
            background: url("../../Assets/Images/money5.jpg");
            background-size: cover;
            padding: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <h4 class="text-primary">Membership's Details</h4>
                <div class="mb-1">
                    <label for="MNameTb" class="form-label">Membership's Name</label>
                    <input type="text" class="form-control" id="MNameTb" runat="server" autocomplete="off">
                </div>
                <div class="mb-1">
                    <label for="DurationTb" class="form-label">Membership's Duration</label>
                    <input type="text" class="form-control" id="DurationTb" runat="server">
                </div>
                <div class="mb-1">
                    <label for="GoalTb" class="form-label">Membership's Goal</label>
                    <input type="text" class="form-control" id="GoalTb" runat="server">
                </div>
                <div class="mb-1">
                    <label for="CostTb" class="form-label">Membership's Cost</label>
                    <input type="text" class="form-control" id="CostTb" runat="server" autocomplete="off">
                </div>
                <div class="row">
                    <label id="ErrMsg" runat="server" class="text-danger"></label>
                    <div class="col d-grid">
                        <asp:Button Text="Edit" CssClass="btn btn-block btn-warning" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Add" CssClass="btn btn-block btn-primary" runat="server" ID="AddBtn" OnClick="Unnamed2_Click" />
                    </div>
                    <div class="col d-grid">
                        <asp:Button Text="Delete" CssClass="btn btn-block btn-danger" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <div class="table-container">
                    <asp:GridView runat="server" ID="MembershipList" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="MembershipList_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
