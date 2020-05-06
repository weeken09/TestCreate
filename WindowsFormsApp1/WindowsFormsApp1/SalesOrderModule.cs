using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace AccountingSoft
{
    class SalesOrderModule
    {
        DatabaseConnection dbcon = new DatabaseConnection();
        public int addSalesOrderFunc(int customerId,double subTotal, double tax, double discount, double grandTotal, int createdBy,string remarks, List<OrderDetail> orderDetails)
        {
            try
            {
                try
                {
                    string storeProcQuery = "DECLARE @PD ProductDetails;INSERT @PD VALUES ";
                    for(int i = 0; i < orderDetails.Count; i++){
                        OrderDetail od = orderDetails.ElementAt(i);
                        storeProcQuery += "(1," + od.productId + "," + od.amount + "," + od.quantity + "," + od.tax + "," + od.discount +")";
                        if(i < orderDetails.Count - 1)
                        {
                            storeProcQuery += ",";
                        }
                    }
                    storeProcQuery += ";EXEC InsertSalesOrder @customerid=" + customerId + ",@subtotal=" + subTotal + ",@tax=" + tax + ",@discount=" + discount + ",@grandtotal=" + grandTotal + ",@createdby=" + createdBy + ",@Produt_Detils=@PD,@remarks=" + remarks + ";";
                    dbcon.ExecNonSQL(storeProcQuery);
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public DataTable getSalesOrderListFunc()
        {
            try
            {
                string storeProcQuery = "EXEC GetSalesOrderList;";
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
