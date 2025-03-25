using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Kasir : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataTransaksi();
                GenerateNomorTransaksi();
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect ke halaman login jika belum login
                }
                else
                {
                    lblUsername.Text = Session["username"].ToString(); // Tampilkan username
                }
            }
        }

        private void GenerateNomorTransaksi()
        {
            Random random = new Random();
            int randomNum = random.Next(100, 999); // 3 digit angka acak
            string waktu = DateTime.Now.ToString("mmssd"); // 4 digit dari waktu (Menit, Detik, Hari)
            txtNomorTransaksi.Text = $"{randomNum}{waktu}"; // Hasil akhir: 7 digit
        }



        protected void btnCariProduk_Click(object sender, EventArgs e)
        {
            string kodeProduk = txtKodeProduk.Text.Trim();

            if (string.IsNullOrEmpty(kodeProduk))
            {
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ProductName, ProductPrice FROM dbo.Product WHERE ProductCode = @kode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kode", kodeProduk);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNamaProduk.Text = reader["ProductName"].ToString();
                        txtHargaProduk.Text = reader["ProductPrice"].ToString();
                    }
                    else
                    {
                        txtNamaProduk.Text = "Tidak ditemukan";
                        txtHargaProduk.Text = "0";
                    }
                }
            }
        }

        protected void txtJumlahPembelian_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtHargaProduk.Text, out decimal harga) && int.TryParse(txtJumlahPembelian.Text, out int jumlah))
            {
                decimal subtotal = harga * jumlah;
                txtSubtotal.Text = subtotal.ToString();
            }
            else
            {
                txtSubtotal.Text = "0";
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            string TransNumber = txtNomorTransaksi.Text.Trim();
            string ProductCode = txtKodeProduk.Text.Trim();
            int QOH;
            decimal SubTotal;
            DateTime TransDate = DateTime.Now;
            int Total;

            if (string.IsNullOrEmpty(TransNumber) ||
                string.IsNullOrEmpty(ProductCode) ||
                !int.TryParse(txtJumlahPembelian.Text, out QOH) || QOH <= 0 ||
                !decimal.TryParse(txtSubtotal.Text, out SubTotal))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Harap isi data dengan benar!');", true);
                return;
            }

            Total = Convert.ToInt32(SubTotal);

            using (SqlConnection connection = new SqlConnection(GlobalVariabel.connString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Buat objek TransHeader
                    TransHeader header = new TransHeader
                    {
                        TransNumber = TransNumber,
                        TransDate = TransDate,
                        Total = Total
                    };
                    string resultHeader = header.Create(connection, transaction);

                    // Buat objek TransDetail
                    TransDetail detail = new TransDetail
                    {
                        TransNumber = TransNumber,
                        ProductCode = ProductCode,
                        QOH = QOH,
                        SubTotal = Convert.ToInt32(SubTotal)
                    };
                    string resultDetail = detail.Create(connection, transaction);

                    if (resultHeader == "OK" && resultDetail == "OK")
                    {
                        transaction.Commit(); // Commit hanya jika semua berhasil
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Transaksi berhasil disimpan!');", true);

                        // Kosongkan form setelah transaksi berhasil
                        ClearForm();
                        GenerateNomorTransaksi(); // Buat nomor transaksi baru
                    }
                    else
                    {
                        transaction.Rollback();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Gagal menyimpan transaksi!');", true);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
        }


        private void ClearForm()
        {
            txtKodeProduk.Text = "";
            txtNamaProduk.Text = "";
            txtHargaProduk.Text = "";
            txtJumlahPembelian.Text = "";
            txtSubtotal.Text = "";
        }

        protected void GridViewTransaksi_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Hapus")
            {
                string transNumber = e.CommandArgument.ToString();

                // Buat koneksi ke database
                string connString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "DELETE FROM dbo.ProdukTransaksi WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", transNumber);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Refresh GridView setelah penghapusan
                LoadDataTransaksi();
            }
        }

        private void LoadDataTransaksi()
        {
            string connString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM dbo.ProdukTransaksi";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewTransaksi.DataSource = dt;
                    GridViewTransaksi.DataBind();
                }
            }
        }
    }
}