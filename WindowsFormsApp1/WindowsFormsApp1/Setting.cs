using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccountingSoft
{
    class Setting
    {
        private static UserModule userModule = new UserModule();
        private static string username;

        public static string getCurrentUsername()
        {
            return username;
        }

        public static int getCurrentUserId()
        {
            DataTable dt = userModule.getUserFunc(username);
            if(dt != null)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        public static void setCurrentUsername(string usernameC)
        {
            username = usernameC; 
        }
    }
}
