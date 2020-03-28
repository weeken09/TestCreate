using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccountingSoft
{
    class UserModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int checkUsernameFunc(string username)
        {
            try
            {
                string storeProcQuery = "EXEC GetUserWithUsername @username='" + username + "';";
                DataTable dt = dbcon.ExecSQL(storeProcQuery);
                return (dt.Rows.Count > 0) ? 0 : 1;               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public int addUserFunc(string fullname,int age, string email, string username, string password, int userCat)
        {   
            try
            {
                string storeProcQuery = "EXEC InsertUser @fullname='" + fullname + "',@age=" + age + ",@email='" + email + "',@username='" + username + "',@password='" + password + "',@usercategory=" + userCat + ";";
                dbcon.ExecNonSQL(storeProcQuery);
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public DataTable getUserFunc()
        {
            string storeProcQuery = "EXEC GetUsers;";
            DataTable dt = dbcon.ExecSQL(storeProcQuery);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable getUserCategoryFunc()
        {
            string storeProcQuery = "EXEC GetUserCategory;";
            DataTable dt = dbcon.ExecSQL(storeProcQuery);
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}
