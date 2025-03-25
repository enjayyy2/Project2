using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project2
{
    internal class TransDetail
    {
        public string TransNumber, ProductCode;
        public int QOH, SubTotal;

        SqlConnection myConnection = new SqlConnection(GlobalVariabel.connString);
        string flag;

        public string Create(SqlConnection connection, SqlTransaction transaction)
        {
            string flag;
            try
            {
                string query = "INSERT INTO dbo.TransDetail (TransNumber, ProductCode, QOH, SubTotal) " +
                               "VALUES (@number, @kodeproduk, @qoh, @subtotal)";
                using (SqlCommand com = new SqlCommand(query, connection, transaction))
                {
                    com.Parameters.AddWithValue("@number", TransNumber);
                    com.Parameters.AddWithValue("@kodeproduk", ProductCode);
                    com.Parameters.AddWithValue("@qoh", QOH);
                    com.Parameters.AddWithValue("@subtotal", SubTotal);
                    int i = com.ExecuteNonQuery();
                    flag = (i > 0) ? "OK" : "fail";
                }
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            return flag;
        }

    }
}