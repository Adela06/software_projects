<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAdmin.aspx.cs" Inherits="WebApplication2.WebFormAdmin" %>

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
        padding: 8px 8px;
        font-size: 14px; 
        margin-right: 5px; 
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="buttons">
                 <asp:Button ID="btnRomana" runat="server" Text="RO" OnClick="SwitchToRomana_Click" />
 <asp:Button ID="btnEngleza" runat="server" Text="EN" OnClick="SwitchToEngleza_Click" />
 <asp:Button ID="btnGermana" runat="server" Text="DE" OnClick="SwitchToGermana_Click" />
            </div>

            <div class="buttons">
                <asp:Button ID="btnSortByType" runat="server" Text="Tip" CssClass="btn" OnClick="SortByType_Click" />
                <asp:Button ID="btnSortBySpecies" runat="server" Text="Specie" CssClass="btn" OnClick="SortBySpecies_Click" />
            </div>

            <div class="buttons">
                <asp:DropDownList ID="ddlFilterType" runat="server" CssClass="input">
                    <asp:ListItem Text="Type" Value="Type"></asp:ListItem>
                    <asp:ListItem Text="Species" Value="Species"></asp:ListItem>
                    <asp:ListItem Text="Carnivorous" Value="Carnivorous"></asp:ListItem>
                    <asp:ListItem Text="Location" Value="Location"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtFilter" runat="server" CssClass="input" placeholder="Filter Value" />
                <asp:Button ID="btnFilter" runat="server" Text="Filtrare" CssClass="btn" OnClick="Filter_Click" />
            </div>


            <div class="buttons">
                <asp:DropDownList ID="ddlUserTypeFilter" runat="server" CssClass="input">
                    <asp:ListItem Text="All Users" Value="All"></asp:ListItem>
                    <asp:ListItem Text="Admins" Value="Admins"></asp:ListItem>
                    <asp:ListItem Text="Regular Users" Value="Regular"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnFilterUsers" runat="server" Text="FiltrareUtilizatori" CssClass="btn" OnClick="FilterUsers_Click" />
            </div>


            <div class="buttons">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="input" placeholder="Search" />
                <asp:Button ID="btnSearch" runat="server" Text="Cautare" CssClass="btn" OnClick="Search_Click" />
            </div>

            <asp:GridView ID="DataGridViewUsers" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="User ID" />
        <asp:BoundField DataField="Username" HeaderText="Username" />
        <asp:BoundField DataField="Password" HeaderText="Password" />
        <asp:BoundField DataField="AdminStatus" HeaderText="Admin Status" />
    </Columns>
</asp:GridView>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="PlantName" HeaderText="Nume Plantă" />
                    <asp:BoundField DataField="PlantType" HeaderText="Tip Plantă" />
                    <asp:BoundField DataField="Species" HeaderText="Specie" />
                    <asp:BoundField DataField="Carnivorous" HeaderText="Carnivor" />
                    <asp:BoundField DataField="Location" HeaderText="Locație" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Imagine" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                </Columns>
            </asp:GridView>

            <div class="buttons">
    <asp:Button ID="btnCreateUser" runat="server" Text="Creeaza" CssClass="btn" OnClick="CreateUser_Click" />
    <asp:Button ID="btnUpdateUser" runat="server" Text="Actualizeaza" CssClass="btn" OnClick="UpdateUser_Click" />
    <asp:Button ID="btnDeleteUser" runat="server" Text="Sterge" CssClass="btn" OnClick="DeleteUser_Click" />
</div>

<asp:TextBox ID="txtUserId" runat="server" CssClass="input" placeholder="User ID (for Update/Delete)" />
<asp:TextBox ID="txtUsername" runat="server" CssClass="input" placeholder="Username" />
<asp:TextBox ID="txtPassword" runat="server" CssClass="input" placeholder="Password" />
<asp:DropDownList ID="ddlAdminStatus" runat="server" CssClass="input">
    <asp:ListItem Text="Admin" Value="yes"></asp:ListItem>
    <asp:ListItem Text="Regular" Value="no"></asp:ListItem>
</asp:DropDownList>


            <div class="save-buttons">
                <asp:Button ID="btnLoadPlants" runat="server" Text="Incarca lista cu plante" CssClass="btn" OnClick="LoadPlants_Click" />
                <asp:Button ID="btnHidePlants" runat="server" Text="Ascunde lista cu plante" CssClass="btn" OnClick="HidePlants_Click" Visible="true" />

                <asp:Button ID="btnResetList" runat="server" Text="Resetare lista" CssClass="btn" OnClick="ResetList_Click" />
            </div>

            <asp:Label ID="Label1" runat="server" Text="" CssClass="error" />
        </div>
    </form>
</body>
</html>
