using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp1
{
    class AuthenticationModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int loginFunc(string username, string password)
        {
            string storeProcQuery = "EXEC Login @username='" + username + "',@password='" + password + "';";
            DataTable dt = dbcon.ExecSQL(storeProcQuery);
            if(dt != null)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
