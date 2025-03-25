<%@ Page Title="Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Product1.aspx.cs" Inherits="Project2.Product1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Selamat Berbelanja -
        <asp:Label ID="lblUsername" runat="server" CssClass="text-black"></asp:Label>
            <a href="Logout.aspx" class="btn btn-danger">Logout</a>
        </h2>
    </div>

    <div class="container mt-5">
        <div class="text-center mb-4">
            <h2 class="fw-bold">This Is Our Product</h2>
            <p class="text-muted">Find the best products with the best price!</p>
        </div>

        <form id="productForm" runat="server">
            <div class="row justify-content-center">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6 col-sm-12 mb-3 d-flex justify-content-center">
                            <div class="card equal-card hover-zoom">
                                <div class="image-container">
                                    <img src='<%# Eval("ProductImage") %>' class="card-img-top product-img" alt='<%# Eval("ProductName") %>'>
                                </div>
                                <div class="card-body text-center d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("ProductName") %></h5>
                                    <p class="card-text"><%# Eval("ProductPrice", "{0:N2}") %></p>
                                    <div class="d-flex justify-content-center align-items-center mb-2">
                                        <asp:Button ID="btnMinus" runat="server" CssClass="btn btn-outline-secondary btn-sm me-2"
                                            Text="-" OnClientClick="decreaseQuantity(this); return false;" />
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control text-center"
                                            Text="1" Width="50px" />
                                        <asp:Button ID="btnPlus" runat="server" CssClass="btn btn-outline-secondary btn-sm ms-2"
                                            Text="+" OnClientClick="increaseQuantity(this); return false;" />
                                    </div>
                                    <asp:Button ID="btnBuyNow" runat="server" CssClass="btn btn-success"
                                        Text="Buy Now" CommandArgument='<%# Eval("ProductCode") %>'
                                        OnClick="btnBuyNow_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </form>
    </div>

    <script>
        function increaseQuantity(button) {
            var input = button.previousElementSibling;
            var currentValue = parseInt(input.value);
            if (!isNaN(currentValue)) {
                input.value = currentValue + 1;
            }
        }

        function decreaseQuantity(button) {
            var input = button.nextElementSibling;
            var currentValue = parseInt(input.value);
            if (!isNaN(currentValue) && currentValue > 1) {
                input.value = currentValue - 1;
            }
        }
    </script>

    <style>
        .equal-card {
            width: 100%;
            max-width: 280px;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
        }

        .hover-zoom:hover {
            transform: scale(1.05);
            box-shadow: 0px 8px 16px rgba(0, 0, 0, 0.2);
        }

        .image-container {
            height: 220px;
            display: flex;
            align-items: center;
            justify-content: center;
            background-color: #f8f9fa;
        }

        .product-img {
            width: 100%;
            height: 100%;
            object-fit: contain;
        }
    </style>
</asp:Content>
