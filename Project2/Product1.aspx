<%@ Page Title="Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Product1.aspx.cs" Inherits="Project2.Product1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
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
                                <a href="#" class="btn btn-success mt-auto">Buy Now</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <style>
        /* Ukuran card seragam */
        .equal-card {
            width: 100%;
            max-width: 280px;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
        }

        /* Efek hover pada card */
        .hover-zoom:hover {
            transform: scale(1.05); /* Zoom in */
            box-shadow: 0px 8px 16px rgba(0, 0, 0, 0.2); /* Tambahkan shadow */
        }

        /* Atur gambar agar tidak terpotong */
        .image-container {
            height: 220px;
            display: flex;
            align-items: center;
            justify-content: center;
            background-color: #f8f9fa; /* Background untuk gambar */
        }

        .product-img {
            width: 100%;
            height: 100%;
            object-fit: contain; /* Gambar tidak terpotong */
        }

        /* Mengurangi jarak antar card */
        .row > div {
            display: flex;
        }

        /* Padding antar card */
        .col-lg-3, .col-md-6, .col-sm-12 {
            padding: 8px;
        }
    </style>
</asp:Content>




