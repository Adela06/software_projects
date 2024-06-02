<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineGym.Views.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script>
        function SetTokenInLocalStorage(token) {
            localStorage.setItem("AuthToken", token);
        }

        function togglePasswordVisibility() {
            var passwordInput = document.getElementById('<%= PasswordTb.ClientID %>');
            passwordInput.type = passwordInput.type === 'password' ? 'text' : 'password';
        }
    </script>

    <title></title>
    <link href="../../Assets/Lib/css/bootstrap.min.css" rel="stylesheet"/>
    <style>
        *{
            font-family: Poppins;
        }
        body{
            background:url("../../Assets/Images/backgr.jpg");
            background-size: cover;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <div class="row mb-5" style="height:100px; " >

        </div>
        <div class="row mt-5">
            <div class="col-md-3">

            </div>
            <div class="col-md-6 bg-white pt-2 pb-3 rounded-3">
                <div class="row">
                    <h3 class="text-center text-primary">Gym Management System</h3>
                    <div class="col">
                        <img src="../../Assets/Images/account.png" />
                    </div>
                    <div class="col bg-white">
                        <form runat="server">
                            <div class="mb-3">
                                <label for="exampleInputEmail1" class="form-label">Email address</label>
                                <input type="email" class="form-control" runat="server" id="EmailTb" aria-describedby="emailHelp" autocomplete="off">
                                <div id="emailHelp" class="form-text">We'll never share your email.</div>
                            </div>
                            <div class="mb-3">
                                <label for="exampleInputPassword1" class="form-label">Password</label>
                                <div class="input-group">
                                    <input type="password" class="form-control" id="PasswordTb" runat="server">
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <input type="checkbox" id="ShowPasswordCheckbox" onclick="togglePasswordVisibility()" runat="server">
                                            <label class="form-check-label" for="ShowPasswordCheckbox">Show Password</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <label id="ErrMsg" runat="server" class="text-danger"></label>
                            <div class="mb-3 form-check">
                                <input type="radio" class="form-radio-input" id="AdminRadio" name="Role" runat="server">
                                <label class="form-check-label" for="AdminRadio">Admin</label>
                                <input type="radio" class="form-radio-input" id="RecRadio" name="Role" runat="server">
                                <label class="form-check-label" for="RecRadio">Receptionist</label>
                            </div>
                            <div class="mb-3 form-check">
                                <input type="checkbox" class="form-check-input" id="RememberMeCheckBox" runat="server">
                                <label class="form-check-label" for="RememberMeCheckBox">Remember Me</label>
                            </div>
                            <div class="d-grid">
                                <asp:Button Text="Login" type="submit" class="btn btn-primary btn-block" runat="server" ID="LoginBtn" OnClick="LoginBtn_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>
</body>
</html>
