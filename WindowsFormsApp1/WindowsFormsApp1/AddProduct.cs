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
    public partial class AddProduct : Form
    {
        TaxModule taxModule = new TaxModule();
        ProductModule productModule = new ProductModule();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            DataTable dt = taxModule.getTaxCategoryFunc();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = dt.Columns["TaxCode"].ToString();
                comboBox1.ValueMember = dt.Columns["Id"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float price;
            float tempOut;
            string productCode = textBox1.Text.ToString().Trim();
            string productName = textBox2.Text.ToString().Trim();
            string productDesc = textBox3.Text.ToString().Trim();
            string remark = richTextBox1.Text.ToString().Trim();
            int taxable = checkBox1.Checked ? 1 : 0;
            int tax = int.Parse(comboBox1.SelectedValue.ToString());
            int status = checkBox2.Checked ? 1 : 0;
            bool priceCheck = float.TryParse(textBox4.Text.ToString().Trim(), out tempOut);
            if (priceCheck)
            {
                price = tempOut;
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please fill in all the blank!");
                }
                else
                {
                    try
                    {
                        if (productModule.addProductFunc(productCode, productName, productDesc, price, remark, taxable, tax, status) == 1)
                        {
                            MessageBox.Show("Product successfully added!");
                        }
                        else
                        {
                            MessageBox.Show("Fail to add product!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        MessageBox.Show("Fatal Error when insert user. Please contact administrator!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value for product price!");
            }
        }
    }
}
