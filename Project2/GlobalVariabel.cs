using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Project2
{
    public class GlobalVariabel
    {
        public static string connString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    }
}