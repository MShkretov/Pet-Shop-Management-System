using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Data.SqlClient;

namespace Pet_Shop_Managament_System
{
    public class dbConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        private string con;

        public string connection()
        {
            con = @"Data Source=localhost;Initial Catalog=dbPetShop;Integrated Security=True;";
            return con;
        }
    }
}
