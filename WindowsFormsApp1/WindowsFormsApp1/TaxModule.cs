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
    }
}
