using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccountingSoft
{
    class TaxModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public DataTable getTaxCategoryFunc()
        {
            try
            {
                string storeProcQuery = "EXEC GetTaxCategory;";
                return dbcon.ExecSQL(storeProcQuery);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public double getTaxRateFunc(string productId)
        {
            DataTable dt = new DataTable();
            try
            {
                string storeProcQuery = "EXEC GetTaxRateWithProductId @id=" + productId + ";";
                dt = dbcon.ExecSQL(storeProcQuery);
                if(dt.Rows.Count > 0)
                {
                    return double.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
