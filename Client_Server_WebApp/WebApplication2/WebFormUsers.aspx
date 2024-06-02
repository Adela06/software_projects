<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUsers.aspx.cs" Inherits="WebApplication2.WebFormUsers" %>

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

            <asp:TextBox ID="txtPlantId" runat="server" CssClass="input" placeholder="Plant ID (for Update/Delete)" />
            <asp:TextBox ID="txtPlantName" runat="server" CssClass="input" placeholder="Plant Name" />
            <asp:TextBox ID="txtPlantType" runat="server" CssClass="input" placeholder="Plant Type" />
            <asp:TextBox ID="txtSpecies" runat="server" CssClass="input" placeholder="Species" />
            <asp:TextBox ID="txtCarnivorous" runat="server" CssClass="input" placeholder="Carnivorous (Yes/No)" />
            <asp:TextBox ID="txtLocation" runat="server" CssClass="input" placeholder="Location" />

            <div class="buttons">
                <asp:Button ID="btnCreatePlant" runat="server" Text="Creeaza" CssClass="btn" OnClick="CreatePlant_Click" />
                <asp:Button ID="btnUpdatePlant" runat="server" Text="Actualizeaza" CssClass="btn" OnClick="UpdatePlant_Click" />
                <asp:Button ID="btnDeletePlant" runat="server" Text="Sterge" CssClass="btn" OnClick="DeletePlant_Click" />
            </div>

            <div class="save-buttons">
                <asp:Button ID="btnSaveAsXML" runat="server" Text="XML" CssClass="btn" OnClick="SaveAsXML_Click" />
                <asp:Button ID="btnSaveAsJSON" runat="server" Text="JSON" CssClass="btn" OnClick="SaveAsJSON_Click" />
                <asp:Button ID="btnSaveAsCSV" runat="server" Text="CSV" CssClass="btn" OnClick="SaveAsCSV_Click" />
                <asp:Button ID="btnSaveAsDOC" runat="server" Text="DOC" CssClass="btn" OnClick="SaveAsDOC_Click" />
                <asp:Button ID="btnResetList" runat="server" Text="Resetare lista" CssClass="btn" OnClick="ResetList_Click" />
            </div>
            <div class="buttons">
                <asp:DropDownList ID="ddlStatisticsType" runat="server" CssClass="input">
                    <asp:ListItem Text="Plants by Location" Value="Location"></asp:ListItem>
                    <asp:ListItem Text="Carnivorous vs Non-Carnivorous" Value="Carnivorous"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnShowStatistics" runat="server" Text="Statistici" CssClass="btn" OnClick="ShowStatistics_Click" />
            </div>
            <canvas id="plantStatisticsChart" width="400" height="400"></canvas>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>

            <asp:Label ID="Label1" runat="server" Text="" CssClass="error" />
        </div>
    </form>
</body>
</html>
