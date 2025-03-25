using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Produk : System.Web.UI.Page
    {
        Product prd = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Test";
            if (!IsPostBack)
            {
                LoadProduk(); // Load data saat halaman pertama kali dibuka
                LoadDataTransaksi();
            }
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblUsername.Text = Session["username"].ToString();
            }
        }

        private void LoadProduk()
        {
            prd.lihatData();
            GridViewProduk.DataSource = prd.ds.Tables["dbo.Product"];
            GridViewProduk.DataBind();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            prd.kodePrd = txtKode.Text;
            prd.nama = txtNama.Text;
            prd.price = Convert.ToDouble(txtHarga.Text);
            prd.stock = Convert.ToDouble(txtStok.Text);

            // Simpan gambar
            if (fileUploadGambar.HasFile)
            {
                string filePath = "/Image/" + fileUploadGambar.FileName;
                fileUploadGambar.SaveAs(Server.MapPath(filePath));
                prd.gambar = filePath;
            }
            else
            {
                prd.gambar = ""; // Jika tidak ada gambar
            }

            string result = prd.insertData();
            if (result == "OK")
            {
                LoadProduk();
                ClearForm();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            prd.kodePrd = txtKode.Text;
            prd.nama = txtNama.Text;
            prd.price = Convert.ToDouble(txtHarga.Text);
            prd.stock = Convert.ToDouble(txtStok.Text);

            // Cek apakah ada gambar baru yang diupload
            if (fileUploadGambar.HasFile)
            {
                string filePath = "/Image/" + fileUploadGambar.FileName;
                fileUploadGambar.SaveAs(Server.MapPath(filePath));
                prd.gambar = filePath; // Gunakan gambar baru
            }
            else
            {
                prd.gambar = prd.GetGambarLama(prd.kodePrd); // Ambil gambar lama
            }

            // Jalankan query update data
            string result = prd.editData();
            Debug.WriteLine("Hasil Edit: " + result);

            if (result == "OK")
            {
                LoadProduk(); // Muat ulang data produk di halaman
                ClearForm();  // Bersihkan form input setelah edit
            }
        }

        private string GetGambarLama(string kodePrd)
        {
            string gambar = "";
            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                conn.Open();
                string query = "SELECT ProductImage FROM dbo.Product WHERE ProductCode = @kodePrd";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kodePrd", kodePrd);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        gambar = result.ToString();
                    }
                }
            }
            return gambar;
        }

        protected void btnHapus_Click(object sender, EventArgs e)
        {
            prd.kodePrd = txtKode.Text;
            string result = prd.hapusData();
            if (result == "OK")
            {
                LoadProduk();
                ClearForm();
            }
        }

        protected void GridViewProduk_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pilih")
            {
                prd.kodePrd = e.CommandArgument.ToString();
                ArrayList data = prd.cariData();
                if (data.Count > 0)
                {
                    txtKode.Text = data[0].ToString();
                    txtNama.Text = data[1].ToString();
                    txtHarga.Text = data[2].ToString();
                    txtStok.Text = data[3].ToString();
                }
            }
        }

        private void ClearForm()
        {
            txtKode.Text = "";
            txtNama.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
        }

        protected void GridViewProduk_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void GridViewProduk_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProduk.PageIndex = e.NewPageIndex; // Ubah ke halaman yang dipilih
            LoadProduk(); // Muat ulang data produk
        }
    }
}