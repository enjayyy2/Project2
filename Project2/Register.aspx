<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project2.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #121212;
            color: white;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .register-container {
            background-color: #1e1e1e;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
            text-align: center;
            width: 400px;
        }

        .form-control {
            background-color: transparent;
            border: 1px solid #007bff;
            color: white;
        }

            .form-control::placeholder {
                color: rgba(255, 255, 255, 0.7);
            }

            .form-control:focus {
                background-color: transparent;
                color: white;
                border-color: #00ff00;
                box-shadow: none;
            }

        .btn-register {
            background-color: transparent;
            border: 2px solid #00ff00;
            color: white;
        }

            .btn-register:hover {
                background-color: #00ff00;
                color: black;
            }

        .dropdown {
            background-color: transparent;
            color: white;
            border: 1px solid #007bff;
            width: 100%;
            padding: 8px;
            border-radius: 5px;
        }

            .dropdown option {
                background-color: #1e1e1e;
                color: white;
            }

        .show-password {
            display: flex;
            align-items: center;
            gap: 5px;
            font-size: 14px;
            margin-top: 10px;
            cursor: pointer;
        }

            .show-password input {
                cursor: pointer;
            }
    </style>
</head>
<body>
    <div class="register-container">
        <h2>REGISTER</h2>
        <p>Create your account</p>
        <form runat="server" id="registerForm">
            <div class="mb-3">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Username"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Confirm Password"></asp:TextBox>
            </div>
            <div class="show-password">
                <input type="checkbox" id="chkShowPassword" onclick="togglePassword()">
                <label for="chkShowPassword">Show Password</label>
            </div>
            <div class="mb-3">
                <asp:DropDownList ID="ddlAkses" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="User" Value="User" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-register w-100" OnClientClick="return validateForm()" OnClick="btnRegister_Click" />
        </form>
        <a href="Login.aspx" class="d-block mt-3 text-decoration-none text-white">Sudah punya akun? <span class="text-primary">Login</span></a>
    </div>

    <script>
        function togglePassword() {
            var password = document.getElementById('<%= txtPassword.ClientID %>');
            var confirmPassword = document.getElementById('<%= txtConfirmPassword.ClientID %>');
            var checkBox = document.getElementById("chkShowPassword");

            if (checkBox.checked) {
                password.type = "text";
                confirmPassword.type = "text";
            } else {
                password.type = "password";
                confirmPassword.type = "password";
            }
        }

        function validateForm() {
            var username = document.getElementById('<%= txtUsername.ClientID %>').value.trim();
            var email = document.getElementById('<%= txtEmail.ClientID %>').value.trim();
            var password = document.getElementById('<%= txtPassword.ClientID %>').value.trim();
            var confirmPassword = document.getElementById('<%= txtConfirmPassword.ClientID %>').value.trim();
            var role = document.getElementById('<%= ddlAkses.ClientID %>').value.trim();

            if (username === "" || email === "" || password === "" || confirmPassword === "" || role === "") {
                alert("Semua kolom wajib diisi!");
                return false;
            }

            if (!email.endsWith("@gmail.com")) {
                alert("Masukkan email yang benar");
                return false;
            }

            if (password !== confirmPassword) {
                alert("Password dan Confirm Password harus sama!");
                return false;
            }

            return true;
        }
    </script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
