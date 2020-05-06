using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingSoft
{
    class OrderDetail
    {
        public int productId;
        public double amount;
        public double quantity;
        public double tax;
        public double discount;

        public OrderDetail(int productId,double amount,double quantity,double tax, double discount)
        {
            this.productId = productId;
            this.amount = amount;
            this.quantity = quantity;
            this.tax = tax;
            this.discount = discount;
        }
    }
}
