using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project2.Model;

namespace Project2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;

                string query = "SELECT username, akses FROM users WHERE username = @username AND password = @pass";

                using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read()) // Jika data ditemukan
                            {
                                string role = dr["akses"].ToString();
                                Session["username"] = dr["username"].ToString();
                                Session["role"] = dr["akses"].ToString();
                                Session["username"] = txtUsername.Text; // Simpan session

                                // Redirect sesuai role
                                if (role == "Admin")
                                {
                                    Response.Redirect("Produk.aspx");
                                }
                                else if (role == "Cashier")
                                {
                                    Response.Redirect("Kasir.aspx");
                                }
                                else if (role == "User")
                                {
                                    Response.Redirect("Home.aspx");
                                }
                                else
                                {
                                    lblMessage.Text = "Unknown role detected!";
                                }
                            }
                            else
                            {
                                lblMessage.Text = "Incorrect Username or Password!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}