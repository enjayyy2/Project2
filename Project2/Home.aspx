<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project2.Home" %>


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
        <style>
            .carousel-inner img {
                max-height: 450px; /* Sesuaikan tinggi maksimum */
                width: 100%;
                object-fit: contain; /* Menampilkan seluruh gambar tanpa pemotongan */
                background-color: #f8f9fa;
            }
        </style>
        <div class="container mt-4">
            <!-- Kontainer Carousel -->
            <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="image/carousel1.jpeg" class="d-block w-100" alt="Slide 1">
                    </div>
                    <div class="carousel-item">
                        <img src="image/carousel2.jpeg" class="d-block w-100" alt="Slide 2">
                    </div>
                    <div class="carousel-item">
                        <img src="image/carousel3.jpeg" class="d-block w-100" alt="Slide 3">
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                </button>
            </div>
        </div>

        <!-- Kontainer Produk -->
        <div class="container mt-5 mb-4">
            <h2 class="text-center mb-4">Produk Unggulan</h2>
            <!-- CSS untuk efek zoom out dan gambar tidak crop -->
            <style>
                /* Agar gambar tidak terpotong */
                .product-img {
                    max-height: 250px; /* Sesuaikan tinggi maksimum gambar */
                    width: 100%;
                    object-fit: contain; /* Pastikan gambar tetap utuh */
                    background-color: #f8f9fa; /* Latar belakang jika ada ruang kosong */
                }

                /* Efek zoom out saat hover */
                .custom-card {
                    transition: transform 0.3s ease-in-out;
                }

                    .custom-card:hover {
                        transform: scale(0.95); /* Efek zoom out */
                    }
            </style>
            <!-- Judul Produk -->

            <div class="row">
                <!-- Baris pertama -->
                <div class="col-md-4">
                    <div class="card custom-card">
                        <img src="image/nikeair.jpeg" class="card-img-top product-img" alt="Nike Air T-Shirt">
                        <div class="card-body">
                            <h5 class="card-title">Nike Air T-Shirt</h5>
                            <p class="card-text">Deskripsi singkat produk 1.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card custom-card">
                        <img src="image/adidashoodie.jpeg" class="card-img-top product-img" alt="Adidas Hoodie">
                        <div class="card-body">
                            <h5 class="card-title">Adidas Hoodie</h5>
                            <p class="card-text">Deskripsi singkat produk 2.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card custom-card">
                        <img src="image/northface.jpeg" class="card-img-top product-img" alt="The North Face Jacket">
                        <div class="card-body">
                            <h5 class="card-title">The North Face Jacket</h5>
                            <p class="card-text">Deskripsi singkat produk 3.</p>
                        </div>
                    </div>
                </div>

                <!-- Baris kedua -->
                <div class="col-md-4 mt-4">
                    <div class="card custom-card">
                        <img src="image/snapback.jpeg" class="card-img-top product-img" alt="Snapback Supreme">
                        <div class="card-body">
                            <h5 class="card-title">Snapback Supreme</h5>
                            <p class="card-text">Deskripsi singkat produk 4.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <div class="card custom-card">
                        <img src="image/sweatpants.jpeg" class="card-img-top product-img" alt="SweatPants Uniqlo">
                        <div class="card-body">
                            <h5 class="card-title">SweatPants Uniqlo</h5>
                            <p class="card-text">Deskripsi singkat produk 5.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <div class="card custom-card">
                        <img src="image/baggypants.jpeg" class="card-img-top product-img" alt="Baggy Pants H&M">
                        <div class="card-body">
                            <h5 class="card-title">Baggy Pants H&M</h5>
                            <p class="card-text">Deskripsi singkat produk 6.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
