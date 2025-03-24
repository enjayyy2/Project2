using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project2.Model;

namespace Project2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.username = txtUsername.Text;
            user.email = txtEmail.Text;
            user.password = txtPassword.Text;
            user.akses = ddlAkses.SelectedValue;
            user.created_at = Convert.ToString(DateTime.Now);

            string result = user.insertData();
            if (result == "OK")
            {
                ClearForm();
                Response.Redirect("Login.aspx");
                Response.Write("<script>alert('Registrasi berhasil!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Error: " + result + "');</script>");
            }
        }
        private void ClearForm()
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            ddlAkses.SelectedIndex = 0;
        }
    }
}