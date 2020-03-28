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
    public partial class AddCustomer : Form
    {
        CustomerModule customerModule = new CustomerModule();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customerId = textBox1.Text.ToString().Trim();
            string customerName = textBox2.Text.ToString().Trim();
            string address = richTextBox1.Text.ToString().Trim();
            string hphone = textBox3.Text.ToString().Trim();
            string email = textBox4.Text.ToString().Trim();
            string ophone = textBox5.Text.ToString().Trim();
            int active = (checkBox1.Checked) ? 1 : 0;
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Please fill in all the blank!");
            }
            else
            {
                int result = customerModule.addCustomerFunc(customerId, customerName, address, hphone,ophone, email, active);
                if(result == 1)
                {
                    MessageBox.Show("Customer successfully added!");
                }
                else
                {
                    MessageBox.Show("Fail to add customer!");
                }
            }
        }
    }
}
