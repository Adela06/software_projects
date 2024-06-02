<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="OnlineGym.Views.Admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Page</title>
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
        }

        body::before,
        body::after {
            content: '';
            position: fixed;
            top: 0;
            height: 100%;
            width: 20%;
            background-repeat: no-repeat;
        }

        body::before {
            left: 0;
            background-image: url("../../Assets/Images/admin2.png");
            background-size: 50%;
        }

        body::after {
            right: 0;
            background-image: url("../../Assets/Images/admin3.png");
            background-size: 90%;
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

        .dropdown {
            display: inline-block;
            position: relative;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: rgb(128, 128, 128);
            min-width: 200px;
            box-shadow: 0 8px 16px 0 rgb(128, 128, 128);
            z-index: 1;
            left: 0;
        }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown span {
            color: blue;
            font-size: 20px; 
            font-weight: bold;
            padding: 15px 20px;
            text-decoration: none;
            display: block;
            cursor: pointer;
        }

        .dropdown-content a {
            color: blue;
            padding: 15px 20px;
            text-decoration: none;
            display: block;
        }

        .dropdown-content a:hover {
            background-color: #f1f1f1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container">
        <h2>Welcome to the Admin Page</h2>
        <p>Now, you can create, update or delete coaches, memberships or receptionists</p>
        
        <div class="dropdown">
            <span>More Options</span>
            <div class="dropdown-content">
                <a href="Coaches.aspx">Coaches</a>
                <a href="Receptionist.aspx">Receptionists</a>
                <a href="/Views/Receptionist/Payments.aspx">Payments</a>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6">

            </div>
            <div class="col-md-6">

            </div>
        </div>
    </div>
</asp:Content>
