<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="Kasir.aspx.cs" Inherits="Project2.Kasir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Manajemen Produk -
            <asp:Label ID="lblUsername" runat="server" CssClass="text-black"></asp:Label>
            <a href="Logout.aspx" class="btn btn-danger">Logout</a>
        </h2>

        <!-- Form Nomor Transaksi -->
        <div class="card p-4 mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label>Nomor Transaksi:</label>
                    <asp:TextBox ID="txtNomorTransaksi" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>

        <!-- Form Kode Produk -->
        <div class="card p-4 mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label>Kode Produk:</label>
                    <asp:TextBox ID="txtKodeProduk" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label>&nbsp;</label><br />
                    <asp:Button ID="btnCariProduk" runat="server" Text="Cari" CssClass="btn btn-primary" OnClick="btnCariProduk_Click" />
                </div>
                <div class="col-md-6">
                    <label>Nama Produk:</label>
                    <asp:TextBox ID="txtNamaProduk" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-6">
                    <label>Harga Produk:</label>
                    <asp:TextBox ID="txtHargaProduk" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>

        <!-- Form Jumlah Pembelian -->
        <div class="card p-4 mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label>Jumlah Pembelian:</label>
                    <asp:TextBox ID="txtJumlahPembelian" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtJumlahPembelian_TextChanged" />
                </div>
                <div class="col-md-6">
                    <label>Subtotal:</label>
                    <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>

            <div class="mt-3 text-center">
                <asp:Button ID="btnFinish" runat="server" Text="Finish" CssClass="btn btn-success" OnClick="btnFinish_Click" />
            </div>
        </div>
        <h3 class="mt-5">Riwayat Transaksi</h3>
        <asp:GridView ID="GridViewTransaksi" runat="server" CssClass="table table-bordered table-striped"
            AutoGenerateColumns="False" OnRowCommand="GridViewTransaksi_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="ProductCode" HeaderText="Kode Produk" />
                <asp:BoundField DataField="Quantity" HeaderText="Jumlah" />
                <asp:BoundField DataField="TransDate" HeaderText="Tanggal Transaksi" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:TemplateField HeaderText="Aksi">
                    <ItemTemplate>
                        <asp:Button ID="btnHapusTransaksi" runat="server" Text="Hapus" CssClass="btn btn-danger btn-sm"
                            CommandName="Hapus" CommandArgument='<%# Eval("ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


