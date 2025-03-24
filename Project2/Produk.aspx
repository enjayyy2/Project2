<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="Produk.aspx.cs" Inherits="Project2.Produk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">
            Manajemen Produk - <asp:Label ID="lblUsername" runat="server" CssClass="text-black"></asp:Label>
            <a href="Logout.aspx" class="btn btn-danger">Logout</a>
        </h2>

        <!-- Form Tambah/Edit Produk -->
        <div class="card p-4 mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label>Kode Produk:</label>
                    <asp:TextBox ID="txtKode" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label>Nama Produk:</label>
                    <asp:TextBox ID="txtNama" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label>Gambar Produk:</label>
                    <asp:FileUpload ID="fileUploadGambar" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-6">
                    <label>Harga:</label>
                    <asp:TextBox ID="txtHarga" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label>Stok:</label>
                    <asp:TextBox ID="txtStok" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="mt-3 text-center">
                <asp:Button ID="btnTambah" runat="server" Text="Tambah" CssClass="btn btn-success" OnClick="btnTambah_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="btnEdit_Click" />
                <asp:Button ID="btnHapus" runat="server" Text="Hapus" CssClass="btn btn-danger" OnClick="btnHapus_Click" />
            </div>
        </div>

        <!-- GridView untuk Menampilkan Data -->
        <asp:GridView ID="GridViewProduk" runat="server" CssClass="table table-bordered table-striped"
            AutoGenerateColumns="False" OnRowCommand="GridViewProduk_RowCommand" OnSelectedIndexChanged="GridViewProduk_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ProductCode" HeaderText="Kode Produk" />
                <asp:BoundField DataField="ProductName" HeaderText="Nama Produk" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                    <asp:Image ID="imgProduct" runat="server" 
                               ImageUrl='<%# Eval("ProductImage") %>' 
                               Width="80px" Height="80px" 
                               AlternateText="Gambar Produk" 
                               onerror="this.onerror=null; this.src='/Images/default.png';" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProductPrice" HeaderText="Harga" />
                <asp:BoundField DataField="ProductStock" HeaderText="Stok" />
                <asp:TemplateField HeaderText="Aksi">
                    <ItemTemplate>
                        <asp:Button ID="btnPilih" runat="server" Text="Pilih" CssClass="btn btn-primary btn-sm"
                            CommandName="Pilih" CommandArgument='<%# Eval("ProductCode") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>