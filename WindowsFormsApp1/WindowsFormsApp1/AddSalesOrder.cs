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
    public partial class AddSalesOrder : Form
    {
        CustomerModule customerModule = new CustomerModule();
        ProductModule productModule = new ProductModule();
        TaxModule taxModule = new TaxModule();
        DataTable dtSO;
        double total = 0;
        double taxTotal = 0;
        double grandTotal = 0;
        double discountTotal = 0;
        string productName;
        double taxRate;
        public AddSalesOrder()
        {
            InitializeComponent();
        }

        private void AddSalesOrder_Load(object sender, EventArgs e)
        {
            DataTable dt = customerModule.getCustomerFunc();
            DataTable dtPro = productModule.getProductFunc();
            dtSO = new DataTable();
            dtSO.Columns.Add("Product", typeof(string));
            dtSO.Columns.Add("Unit Price(RM)", typeof(double));
            dtSO.Columns.Add("Quantity", typeof(double));
            dtSO.Columns.Add("Amount(RM)", typeof(string));
            dtSO.Columns.Add("Remark", typeof(string));
            dtSO.Columns.Add("Tax(%)", typeof(double));
            dtSO.Columns.Add("Discount(RM)", typeof(double));
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if(dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = dt.Columns["CusName"].ToString();
                comboBox1.ValueMember = dt.Columns["Id"].ToString();
            }
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (dtPro != null)
            {
                comboBox2.DataSource = dtPro;
                comboBox2.DisplayMember = dtPro.Columns["ProductName"].ToString();
                comboBox2.ValueMember = dtPro.Columns["Id"].ToString();
            }          
            dataGridView1.DataSource = dtSO;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "0.00##";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "0.0##";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "0.00##";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "0.00##";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "0.00##";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedValue.ToString();
            DataTable dt = customerModule.getCustomerFunc(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                richTextBox1.Text = dt.Rows[0]["CusAddress"].ToString();
                textBox1.Text = (string.IsNullOrWhiteSpace(dt.Rows[0]["CusOfficePhone"].ToString()) ? dt.Rows[0]["CusHandPhone"].ToString() : dt.Rows[0]["CusOfficePhone"].ToString());
                textBox2.Text = dt.Rows[0]["CusEmail"].ToString();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = comboBox2.SelectedValue.ToString();
            DataTable dt = productModule.getProductFunc(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                textBox3.Text = string.Format("{0:0.00}", double.Parse(dt.Rows[0]["ProductPrice"].ToString()));
                productName = dt.Rows[0]["ProductName"].ToString();
                taxRate = taxModule.getTaxRateFunc(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double tempQuantity;
            double quantity = 0;
            double tempDiscountPercentage;
            double tempDiscountRM;
            double discount = 0;
            bool discountValidPercent = double.TryParse(textBox7.Text, out tempDiscountPercentage);
            bool discountValidRM = double.TryParse(textBox5.Text, out tempDiscountRM);
            
            if (double.TryParse(textBox4.Text.ToString(), out tempQuantity))
            {
                quantity = tempQuantity;
                if(string.IsNullOrEmpty(textBox3.Text.ToString()) || string.IsNullOrEmpty(textBox4.Text.ToString()))
                {
                    MessageBox.Show("Please fill in all the blank!");
                }
                else if(quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity!");
                }
                else if(!discountValidPercent && radioButton1.Checked)
                {
                    MessageBox.Show("Please enter a valid discount!");
                }
                else if (!discountValidRM && radioButton2.Checked)
                {
                    MessageBox.Show("Please enter a valid discount!");
                }
                else
                {                   
                    bool found = false;
                    double price = double.Parse(textBox3.Text.ToString());
                    double amount = price * quantity;
                    double tax = amount * taxRate / 100.0;
                    string remark = textBox6.Text.ToString();
                    if (radioButton1.Checked)
                    {
                        discount = amount * tempDiscountPercentage / 100;
                    }
                    else if (radioButton2.Checked)
                    {
                        discount = tempDiscountRM;
                    }
                    discountTotal += discount;
                    taxTotal += tax;
                    total += amount;
                    grandTotal = total + taxTotal - discountTotal;
                    if(dtSO.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if(row.Cells[0].Value != null)
                            {
                                if (row.Cells[0].Value.ToString().Equals(productName) && double.Parse(row.Cells[1].Value.ToString()) == price)
                                {
                                    quantity += double.Parse(row.Cells[2].Value.ToString());
                                    discount += double.Parse(row.Cells[6].Value.ToString());
                                    row.Cells[2].Value = quantity;
                                    row.Cells[3].Value = quantity * price;
                                    row.Cells[6].Value = discount;
                                    found = true;
                                }
                            }
                        }
                    }                    
                    if (!found)
                    {
                        dtSO.Rows.Add(productName, price, quantity, amount, remark, taxRate, discount);
                    }                  
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                    }
                    label9.Text = string.Format("{0:0.00}", total);
                    label15.Text = string.Format("{0:0.00}", taxTotal);
                    label13.Text = string.Format("{0:0.00}", discountTotal);
                    label16.Text = string.Format("{0:0.00}", grandTotal);
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity!");
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox2.SelectedValue != null)
                {
                    string id = comboBox2.SelectedValue.ToString();
                    DataTable dt = productModule.getProductFunc(id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        textBox3.Text = string.Format("{0:0.00}", double.Parse(dt.Rows[0]["ProductPrice"].ToString()));
                        productName = dt.Rows[0]["ProductName"].ToString();
                        taxRate = taxModule.getTaxRateFunc(id);
                    }
                }
                else
                {
                    MessageBox.Show("No product found!");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    taxTotal -= double.Parse(row.Cells[3].Value.ToString()) * taxRate / 100.0;
                    total -= double.Parse(row.Cells[3].Value.ToString());
                    discountTotal -= double.Parse(row.Cells[6].Value.ToString());
                    grandTotal = total + taxTotal - discountTotal;
                    dataGridView1.Rows.RemoveAt(row.Index);                   
                }
                label9.Text = string.Format("{0:0.00}", total);
                label15.Text = string.Format("{0:0.00}", taxTotal);
                label16.Text = string.Format("{0:0.00}", grandTotal);
                label13.Text = string.Format("{0:0.00}", discountTotal);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }
            }           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
                {
                    string id = comboBox1.SelectedValue.ToString();
                    DataTable dt = customerModule.getCustomerFunc(id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        richTextBox1.Text = dt.Rows[0]["CusAddress"].ToString();
                        textBox1.Text = (string.IsNullOrWhiteSpace(dt.Rows[0]["CusOfficePhone"].ToString()) ? dt.Rows[0]["CusHandPhone"].ToString() : dt.Rows[0]["CusOfficePhone"].ToString());
                        textBox2.Text = dt.Rows[0]["CusEmail"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No customer found!");
                }
            }
        }      
    }
}
