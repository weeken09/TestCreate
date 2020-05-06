using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSoft
{
    public partial class ViewSalesOrder : Form
    {
        SalesOrderModule salesOrderModule = new SalesOrderModule();
        public ViewSalesOrder()
        {
            InitializeComponent();
        }

        private void ViewSalesOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = salesOrderModule.getSalesOrderListFunc();
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
