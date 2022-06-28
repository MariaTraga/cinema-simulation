namespace CinemaComplex
{
    partial class SelectUserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectUserForm));
            this.btn_enterCustomer = new System.Windows.Forms.Button();
            this.Staff = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_enterCustomer
            // 
            this.btn_enterCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enterCustomer.FlatAppearance.BorderSize = 0;
            this.btn_enterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_enterCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enterCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btn_enterCustomer.Image")));
            this.btn_enterCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_enterCustomer.Location = new System.Drawing.Point(166, 12);
            this.btn_enterCustomer.Name = "btn_enterCustomer";
            this.btn_enterCustomer.Size = new System.Drawing.Size(138, 136);
            this.btn_enterCustomer.TabIndex = 0;
            this.btn_enterCustomer.Text = "Customer";
            this.btn_enterCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_enterCustomer, "Login as customer");
            this.btn_enterCustomer.UseVisualStyleBackColor = true;
            this.btn_enterCustomer.Click += new System.EventHandler(this.btn_enterCustomer_Click);
            // 
            // Staff
            // 
            this.Staff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Staff.FlatAppearance.BorderSize = 0;
            this.Staff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Staff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staff.Image = ((System.Drawing.Image)(resources.GetObject("Staff.Image")));
            this.Staff.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Staff.Location = new System.Drawing.Point(12, 12);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(148, 136);
            this.Staff.TabIndex = 2;
            this.Staff.Text = "Staff";
            this.Staff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.Staff, "Login as Staff");
            this.Staff.UseVisualStyleBackColor = true;
            this.Staff.Click += new System.EventHandler(this.Staff_Click);
            // 
            // SelectUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 161);
            this.Controls.Add(this.Staff);
            this.Controls.Add(this.btn_enterCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectUserForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_enterCustomer;
        private System.Windows.Forms.Button Staff;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}