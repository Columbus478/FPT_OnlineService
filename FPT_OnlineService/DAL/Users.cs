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
            string sql = "Select Name,RollNo,Email from Students where UserId ='" + UserId + "'";
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

        public static void GetStaff()
        {
            //get User from DB
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "Select Name,Username,Email,StaffRole from Staffs where UserId ='" + UserId + "'";
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
    }
}