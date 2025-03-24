using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;

namespace Project2
{
    public class Product
    {
        public string kodePrd, nama, gambar;
        public double price, stock;
        SqlConnection myConnection = new SqlConnection(GlobalVariabel.connString);
        string flag;
        public DataSet ds = new DataSet();
            
        public string insertData()
        {
            try
            {
                myConnection.ConnectionString = GlobalVariabel.connString;
                myConnection.Open();
                string query = "INSERT INTO dbo.Product (ProductCode, ProductName, ProductPrice, ProductStock, ProductImage) " +
                               "VALUES (@kode, @nama, @price, @stock, @gambar)";
                SqlCommand com = new SqlCommand(query, myConnection);
                com.Parameters.AddWithValue("@kode", kodePrd);
                com.Parameters.AddWithValue("@nama", nama);
                com.Parameters.AddWithValue("@price", price);
                com.Parameters.AddWithValue("@stock", stock);
                com.Parameters.AddWithValue("@gambar", gambar); // Tambahkan gambar
                int i = com.ExecuteNonQuery();
                flag = (i > 0) ? "OK" : "fail";
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myConnection = null;
                }
            }
            return flag;
        }
        public string editData()
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE dbo.Product SET ProductName = @nama, ProductPrice = @price, ProductStock = @stock, ProductImage = @gambar WHERE ProductCode = @kode";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kodePrd);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@gambar", gambar); // Menyimpan gambar baru atau lama

                        int rowsAffected = cmd.ExecuteNonQuery();
                        result = (rowsAffected > 0) ? "OK" : "fail";
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
            return result;
        }

        public string GetGambarLama(string kodePrd)
        {
            string gambarLama = "";
            using (SqlConnection conn = new SqlConnection(GlobalVariabel.connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProductImage FROM dbo.Product WHERE ProductCode = @kode";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kodePrd);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            gambarLama = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error GetGambarLama: " + ex.Message);
                }
            }
            return gambarLama;
        }
        public string hapusData()
        {
            try
            {
                myConnection.ConnectionString = GlobalVariabel.connString;
                myConnection.Open();
                string query = "DELETE FROM dbo.Product WHERE ProductCode = @kode";
                SqlCommand com = new SqlCommand(query, myConnection);
                com.Parameters.AddWithValue("@kode", kodePrd);
                int i = com.ExecuteNonQuery();
                flag = (i > 0) ? "OK" : "fail";
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myConnection = null;
                }
            }
            return flag;
        }
        public string lihatData()
        {
            try
            {
                myConnection = new SqlConnection(GlobalVariabel.connString);
                myConnection.Open();
                string query = "SELECT ProductCode, ProductName, ProductPrice, ProductStock, ProductImage FROM dbo.Product";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds, "dbo.Product");
                flag = "OK";
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myConnection = null;
                }
            }
            return flag;
        }
        public ArrayList cariData()
        {
            ArrayList data = new ArrayList();
            SqlDataReader dr = null;
            try
            {
                myConnection.ConnectionString = GlobalVariabel.connString;
                myConnection.Open();
                string query = "SELECT * FROM dbo.Product WHERE ProductCode = @kode";
                SqlCommand com = new SqlCommand(query, myConnection);
                com.Parameters.AddWithValue("@kode", kodePrd);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    data.Add(dr["ProductCode"].ToString());
                    data.Add(dr["ProductName"].ToString());
                    data.Add(dr["ProductPrice"].ToString());
                    data.Add(dr["ProductStock"].ToString());
                    data.Add(dr["ProductImage"].ToString()); // Ambil gambar
                }
                dr.Close();
            }
            catch (Exception)
            {
                dr = null;
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myConnection = null;
                }
            }
            return data;
        }

    }
}