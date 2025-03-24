using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Project2;

namespace Project2.Model
{
    public class Users
    {
        public string username, email, password, akses, created_at;

        // 🔹 Registrasi Pengguna
        public string insertData()
        {
            string flag = "";
            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.Users (Username, Email, Password, Akses, created_at) VALUES (@username, @email, @password, @akses, @date)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@akses", akses);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        flag = (rowsAffected > 0) ? "OK" : "fail";
                    }
                }
                catch (Exception ex)
                {
                    flag = ex.Message;
                }
            }
            return flag;
        }
        public bool checkLogin()
        {
            bool isAuthenticated = false;
            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM dbo.Users WHERE Username = @username AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isAuthenticated = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error checkLogin: " + ex.Message);
                }
            }
            return isAuthenticated;
        }
    }
}