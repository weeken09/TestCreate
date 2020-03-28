using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AccountingSoft
{
    class AuthenticationModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int loginFunc(string username, string password)
        {
            string storeProcQuery = "EXEC Login @username='" + username + "',@password='" + password + "';";
            DataTable dt = dbcon.ExecSQL(storeProcQuery);
            if(dt != null && dt.Rows.Count > 0)
            {
                string id = dt.Rows[0]["Id"].ToString();
                storeProcQuery = "EXEC UpdateLoginTime @id=" + id + ";";
                dbcon.ExecNonSQL(storeProcQuery);
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
