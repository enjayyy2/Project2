using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

}