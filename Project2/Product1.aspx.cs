using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Product1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
                // Cek apakah session "username" ada
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect ke halaman login jika belum login
                }
                else
                {
                    lblUsername.Text = "Welcome, " + Session["username"].ToString(); // Tampilkan username
                }
            }
        }

        private void LoadProducts()
        {
            string connString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM dbo.Product";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptProducts.DataSource = dt;
                rptProducts.DataBind();
            }
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            Button btn = (Button)sender;
            string productCode = btn.CommandArgument;
            string username = Session["username"].ToString();

            // Cari parent control untuk mendapatkan input jumlah
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
            int quantity = int.Parse(txtQuantity.Text);

            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO ProdukTransaksi (Username, ProductCode, Quantity, TransDate) VALUES (@username, @productCode, @quantity, @date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@productCode", productCode);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Produk berhasil dibeli!');", true);
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
                }
            }
        }


    }
}
