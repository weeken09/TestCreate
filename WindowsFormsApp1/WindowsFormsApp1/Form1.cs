using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSoft
{
    public partial class Form1 : Form
    {
        AuthenticationModule auth;
        Form2 mainForm = new Form2();
        public Form1()
        {
            auth = new AuthenticationModule();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToLower();
            string password = textBox2.Text.ToString();
            if (auth.loginFunc(username, password) > 0)
            {
                
                
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login Fail!");
            }
        }
    }
}
