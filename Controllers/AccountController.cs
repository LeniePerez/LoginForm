using System.Data.SqlClient;
using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //getaccount
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = @"data source =USER-PC\SQLEXPRESS; database=WPF; integrated security = SSPI;";
        }
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from login where Identification_No='"+acc.Identification_No+"' and Password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }

            
            
        }
    }
}
