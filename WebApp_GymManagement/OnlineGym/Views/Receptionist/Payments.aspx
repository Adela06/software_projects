<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="OnlineGym.Views.Receptionist.Payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">

        </div>

        <div class="row">
            <div class="col-md-4">
                <h4>Payments Details</h4>
                        <div>
  <label for="MemberCb" class="form-label">Member</label>
    <asp:DropDownList runat="server" class="form-control" ID="MemberCb">
        
  </asp:DropDownList>
</div>

            <div class="mb-1">
  <label for="PaymentDateTb" class="form-label">Payment's Date</label>
  <input type="date" class="form-control" id="PaymentDateTb" runat="server">
</div>
            </div>
            <div class="mb-1">
  <label for="AmountTb" class="form-label">Amount</label>
  <input type="text" class="form-control" id="AmountTb" runat="server" autocomplete="off">
</div>

            <div class="row">
                <label id="ErrMsg" runat="server" class="text-danger"></label>
                <div class="col d-grid">
                </div>
                <div class="col d-grid">
                    <asp:Button Text="Add" class="btn btn-block btn-primary" runat="server" ID="AddBtn" OnClick="AddBtn_Click" />
                </div>
                <div class="col d-grid">
                </div>

            </div>

            </div>
            <div class="col-md-8">
                <div class="col-md-9">
                    <asp:GridView runat="server" ID="PaymentList" class="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="PaymentList_SelectedIndexChanged" ></asp:GridView>
                </div>
            </div>
        </div>

</asp:Content>
