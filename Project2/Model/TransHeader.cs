using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project2
{
    public class TransHeader
    {
        public string TransNumber;
        public DateTime TransDate;
        public int Total;

        SqlConnection myConnection = new SqlConnection(GlobalVariabel.connString);

        public string Create(SqlConnection connection, SqlTransaction transaction)
        {
            string flag;
            try
            {
                string query = "INSERT INTO dbo.TransHeader (TransNumber, TransDate, Total) " +
                               "VALUES (@number, @tanggal, @total)";
                using (SqlCommand com = new SqlCommand(query, connection, transaction))
                {
                    com.Parameters.AddWithValue("@number", TransNumber);
                    com.Parameters.AddWithValue("@tanggal", TransDate);
                    com.Parameters.AddWithValue("@total", Total);
                    int i = com.ExecuteNonQuery();
                    flag = (i > 0) ? "OK" : "Data Gagal Dimasukkan";
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