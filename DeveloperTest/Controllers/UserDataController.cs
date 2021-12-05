using System;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    public class UserDataController : Controller
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        //Get: User/AddUser
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        
        // POST: UserData/AddUser
        [HttpPost]
        public ActionResult AddUser(UserDataModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AddUserToDataBase(data))
                    {
                        ViewBag.Message = "UserData details added successfully";
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                string mes = e.Message;
                return View();
            }
        }
           
        /// <summary>
        /// Add User to Data base
        /// The users password is hashed before being stored in the database
        /// </summary>
        /// <param name="userData">Data user entered on web page</param>
        /// <returns>True if data added to data base, false if it failed.</returns>
        public bool AddUserToDataBase(UserDataModel userData)
        {
            string hasedPassword = EncryptPassword.HashPassword(userData.Password);

            connection();
            SqlCommand com = new SqlCommand("AddNewUserData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", userData.Email);
            com.Parameters.AddWithValue("@Passowrd", hasedPassword);
            
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}