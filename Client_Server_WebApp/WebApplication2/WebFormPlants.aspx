<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormPlants.aspx.cs" Inherits="WebApplication2.WebFormPlants" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Plante</title>
    <style>
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            border: 1px solid #ccc;
            border-radius: 10px;
            position: relative;
        }
        h1 {
            text-align: center;
            color: #333;
        }
        .buttons {
            margin-bottom: 20px;
            text-align: center;
        }
        .input {
            padding: 10px;
            margin-right: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn {
            padding: 10px 15px;
            margin-right: 10px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        .grid th, .grid td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: left;
        }
        .grid th {
            background-color: #007BFF;
            color: white;
        }
        .grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .error {
            color: red;
            text-align: center;
        }
        .save-buttons {
            text-align: right;
            margin-bottom: 20px;
        }
        .btn-login {
            padding: 10px 15px;
            background-color: #28a745; /* Green color */
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn-login:hover {
            background-color: #218838; /* Darker shade of green on hover */
        }
        .language-selection {
            position: absolute;
            top: 20px;
            right: 20px;
            text-align: right;
        }
        .language-selection button {
            padding: 5px 10px;
            margin-left: 5px;
            background-color: #6c757d;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .language-selection button:hover {
            background-color: #5a6268;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="language-selection">
                <asp:Button ID="btnRomana" runat="server" Text="RO" OnClick="SwitchToRomana_Click" />
                <asp:Button ID="btnEngleza" runat="server" Text="EN" OnClick="SwitchToEngleza_Click" />
                <asp:Button ID="btnGermana" runat="server" Text="DE" OnClick="SwitchToGermana_Click" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="btn-login" OnClick="Login_Click" />

            <div class="buttons">
                <asp:Button ID="btnSortByType" runat="server" Text="Tip" CssClass="btn" OnClick="SortByType_Click" />
                <asp:Button ID="btnSortBySpecies" runat="server" Text="Specie" CssClass="btn" OnClick="SortBySpecies_Click" />
            </div>

            <div class="buttons">
                <asp:DropDownList ID="ddlFilterType" runat="server" CssClass="input">
                    <asp:ListItem Text="Tip" Value="Type"></asp:ListItem>
                    <asp:ListItem Text="Specie" Value="Species"></asp:ListItem>
                    <asp:ListItem Text="Carnivore" Value="Carnivorous"></asp:ListItem>
                    <asp:ListItem Text="Locatie" Value="Location"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtFilter" runat="server" CssClass="input" placeholder="Filter Value" />
                <asp:Button ID="btnFilter" runat="server" Text="Filtrare" CssClass="btn" OnClick="Filter_Click" />
            </div>

            <div class="buttons">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="input" placeholder="Search" />
                <asp:Button ID="btnSearch" runat="server" Text="Cautare" CssClass="btn" OnClick="Search_Click" />
            </div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="PlantName" HeaderText="Nume" />
                    <asp:BoundField DataField="PlantType" HeaderText="Tip" />
                    <asp:BoundField DataField="Species" HeaderText="Specie" />
                    <asp:BoundField DataField="Carnivorous" HeaderText="Carnivora" />
                    <asp:BoundField DataField="Location" HeaderText="Locatie" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Imagine" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                </Columns>
            </asp:GridView>

            <div class="save-buttons">
                <asp:Button ID="btnResetList" runat="server" Text="Reset List" CssClass="btn" OnClick="ResetList_Click" />
            </div>

            <asp:Label ID="Label1" runat="server" Text="" CssClass="error" />
        </div>
    </form>
</body>
</html>
