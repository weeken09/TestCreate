using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingSoft
{
    class UserModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int addUserFunc(string fullname, string email, string username, string password, int userCat)
        {
            string storeProcQuery = "EXEC AddUser @username='" + username + "',@password='" + password + "';";
            return 0;
        }
    }
}
