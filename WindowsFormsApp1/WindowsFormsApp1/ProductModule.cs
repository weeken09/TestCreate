using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AccountingSoft
{
    class ProductModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int addProductFunc(string productCode, string productName, string productDesc,double productPrice, string remark, int taxable, int taxid,int status)
        {
            try
            {
                string storeProcQuery = @"EXEC InsertProduct @productcode='" + productCode + "', @productname='" + productName + "', @productdesc='" + productDesc + "', " +
                                        "@productprice=" + productPrice + ", @remark='" + remark + "', @taxable=" + taxable +
                                        ", @taxid=" + taxid + ", @status=" + status + ",@createdby=" + Setting.getCurrentUserId() + ";";
                dbcon.ExecNonSQL(storeProcQuery);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }            
        }

        public DataTable getProductFunc()
        {
            string storeProcQuery = "EXEC GetProducts;";
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

        public DataTable getProductFunc(string id)
        {
            string storeProcQuery = "EXEC GetProductWithId @id=" + id + ";";
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
