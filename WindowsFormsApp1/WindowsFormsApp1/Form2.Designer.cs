namespace AccountingSoft
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.viewSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.userToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.productToolStripMenuItem,
            this.salesOrderToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.viewEditUserToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // viewEditUserToolStripMenuItem
            // 
            this.viewEditUserToolStripMenuItem.Name = "viewEditUserToolStripMenuItem";
            this.viewEditUserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewEditUserToolStripMenuItem.Text = "View/Edit User";
            this.viewEditUserToolStripMenuItem.Click += new System.EventHandler(this.viewEditUserToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.viewEditCustomerToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.settingToolStripMenuItem.Text = "Customer";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // viewEditCustomerToolStripMenuItem
            // 
            this.viewEditCustomerToolStripMenuItem.Name = "viewEditCustomerToolStripMenuItem";
            this.viewEditCustomerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.viewEditCustomerToolStripMenuItem.Text = "View/Edit Customer";
            this.viewEditCustomerToolStripMenuItem.Click += new System.EventHandler(this.viewEditCustomerToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.viewProductToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addProductToolStripMenuItem.Text = "Add Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // viewProductToolStripMenuItem
            // 
            this.viewProductToolStripMenuItem.Name = "viewProductToolStripMenuItem";
            this.viewProductToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewProductToolStripMenuItem.Text = "View/Edit Product";
            this.viewProductToolStripMenuItem.Click += new System.EventHandler(this.viewProductToolStripMenuItem_Click);
            // 
            // salesOrderToolStripMenuItem
            // 
            this.salesOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSalesOrderToolStripMenuItem,
            this.viewSalesOrderToolStripMenuItem});
            this.salesOrderToolStripMenuItem.Name = "salesOrderToolStripMenuItem";
            this.salesOrderToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.salesOrderToolStripMenuItem.Text = "Sales Order";
            // 
            // addSalesOrderToolStripMenuItem
            // 
            this.addSalesOrderToolStripMenuItem.Name = "addSalesOrderToolStripMenuItem";
            this.addSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addSalesOrderToolStripMenuItem.Text = "Add Sales Order";
            this.addSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.addSalesOrderToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(724, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // viewSalesOrderToolStripMenuItem
            // 
            this.viewSalesOrderToolStripMenuItem.Name = "viewSalesOrderToolStripMenuItem";
            this.viewSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewSalesOrderToolStripMenuItem.Text = "View Sales Order";
            this.viewSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.viewSalesOrderToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 568);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditCustomerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem salesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSalesOrderToolStripMenuItem;
    }
}