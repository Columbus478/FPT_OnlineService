using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace FPT_OnlineService.DAL
{
    public class Users
    {
        private static string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        
        public static string UserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }
        }

        public static void GetStudent()
        {
            //get User from DB
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "Select Name,Username,Email from Users where Id ='" + UserId + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                UserInfo.ID = UserId;
                UserInfo.Name = dr.GetString(0).Trim();
                UserInfo.Username = dr.GetString(1).Trim();
                UserInfo.Email = dr.GetString(2).Trim();
                UserInfo.Role = "Student";
            }
            conn.Close();
        }

        public static string GetStudent(string StudentRollNo)
        {
            //get User from DB
            string Email = "";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "Select Email from Students where StudentRollNo ='" + StudentRollNo + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Email = dr.GetString(0).Trim();
            }
            conn.Close();
            return Email;
        }

        public static void GetStaff()
        {
            //get User from DB
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "SELECT U.Name,U.Username,U.Email,R.Name FROM users u INNER JOIN "
            +"UserRoles ur ON ur.userid = u.id LEFT OUTER JOIN Roles r ON r.id = ur.roleid WHERE u.id = '" + UserId + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                UserInfo.ID = UserId;
                UserInfo.Name = dr.GetString(0).Trim();
                UserInfo.Username = dr.GetString(1).Trim();
                UserInfo.Email = dr.GetString(2).Trim();
                UserInfo.Role = dr.GetString(3).Trim();
            }
            conn.Close();
        }


        public static string GetUserRole()
        {
            //get User from DB
            string userRole = "";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select roles.Name from roles, userroles "
                            +" where roles.Id = userroles.RoleId "
                            +" and userroles.UserId = '" + UserId + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userRole = dr.GetString(0).Trim();
            }
            conn.Close();
            return userRole;
        }

        public static void SetUserNull()
        {
            UserInfo.ID = null;
            UserInfo.Name = null;
            UserInfo.Username = null;
            UserInfo.Email = null;
            UserInfo.Role = null;
        }
    }
}