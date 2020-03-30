using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccountingSoft
{
    class CustomerModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int addCustomerFunc(string id, string name, string address, string hphone, string ophone, string email, int status)
        {
            try
            {
                string storeProcQuery = @"EXEC InsertCustomer @customerid='" + id + "',@customername='" + 
                    name + "',@customeraddress='" + address + "',@hphone='" + hphone + "',@ophone='" + ophone + "',@email='" + email + "'" +
                    ",@status=" + status + ";";
                dbcon.ExecNonSQL(storeProcQuery);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public DataTable getCustomerFunc(string id)
        {
            string storeProcQuery = "EXEC GetCustomerWithId @id=" + id + ";";
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

        public DataTable getCustomerFunc()
        {
            string storeProcQuery = "EXEC GetCustomers;";
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
