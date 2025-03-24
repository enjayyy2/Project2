<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project2.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
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
        .login-container {
            background-color: #1e1e1e;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
            text-align: center;
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
        .btn-login {
            background-color: transparent;
            border: 2px solid #00ff00;
            color: white;
        }
        .btn-login:hover {
            background-color: #00ff00;
            color: black;
        }
        .show-password {
            display: flex;
            align-items: center;
            gap: 5px;
            font-size: 14px;
        }
        .show-password input{
            cursor:pointer;
        }
        .show-password label {
            cursor:pointer;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <h2>LOGIN</h2>
        <p>Please enter your login and password!</p>
        <form runat="server">
            <div class="mb-3">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <div class="mb-3 show-password">
                <input type="checkbox" id="showPassword"> 
                <label for="showPassword">Show Password</label>
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label><br>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-login w-100" OnClick="btnLogin_Click" />
        </form>
        <a href="Register.aspx" class="d-block mt-3 text-decoration-none text-white">Belum Punya Akun? <span class="text-primary">Register</span></a>
    </div>

    <script>
        document.getElementById("showPassword").addEventListener("change", function () {
            let passwordInput = document.getElementById("<%= txtPassword.ClientID %>");
            if (this.checked) {
                passwordInput.type = "text";
            } else {
                passwordInput.type = "password";
            }
        });
    </script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
