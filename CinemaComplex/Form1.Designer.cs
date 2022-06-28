namespace CinemaComplex
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_enter = new System.Windows.Forms.Button();
            this.pct_clerk = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pct_switch = new System.Windows.Forms.PictureBox();
            this.pct_help = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_clerk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_switch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.btn_enter);
            this.panel1.Location = new System.Drawing.Point(201, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 207);
            this.panel1.TabIndex = 0;
            // 
            // btn_enter
            // 
            this.btn_enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_enter.FlatAppearance.BorderSize = 0;
            this.btn_enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_enter.Image = ((System.Drawing.Image)(resources.GetObject("btn_enter.Image")));
            this.btn_enter.Location = new System.Drawing.Point(56, 114);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(83, 75);
            this.btn_enter.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btn_enter, "Enter the cinema");
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            this.btn_enter.MouseLeave += new System.EventHandler(this.btn_enter_MouseLeave);
            this.btn_enter.MouseHover += new System.EventHandler(this.btn_enter_MouseHover);
            // 
            // pct_clerk
            // 
            this.pct_clerk.BackColor = System.Drawing.Color.Transparent;
            this.pct_clerk.Image = global::CinemaComplex.Properties.Resources.PinClipart_com_hardworking_clipart_5365585;
            this.pct_clerk.Location = new System.Drawing.Point(88, 143);
            this.pct_clerk.Name = "pct_clerk";
            this.pct_clerk.Size = new System.Drawing.Size(143, 286);
            this.pct_clerk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_clerk.TabIndex = 1;
            this.pct_clerk.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CinemaComplex.Properties.Resources.wigflip_ds;
            this.pictureBox2.Location = new System.Drawing.Point(2, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(189, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pct_switch
            // 
            this.pct_switch.BackColor = System.Drawing.Color.Transparent;
            this.pct_switch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pct_switch.Image = global::CinemaComplex.Properties.Resources.icons8_switch_on_128px;
            this.pct_switch.Location = new System.Drawing.Point(441, 236);
            this.pct_switch.Name = "pct_switch";
            this.pct_switch.Size = new System.Drawing.Size(22, 35);
            this.pct_switch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_switch.TabIndex = 3;
            this.pct_switch.TabStop = false;
            this.pct_switch.Tag = "on";
            this.toolTip1.SetToolTip(this.pct_switch, "Turn On/Off the lights");
            this.pct_switch.Click += new System.EventHandler(this.pct_switch_Click);
            // 
            // pct_help
            // 
            this.pct_help.BackColor = System.Drawing.Color.Transparent;
            this.pct_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pct_help.Image = global::CinemaComplex.Properties.Resources.icons8_help_80px;
            this.pct_help.Location = new System.Drawing.Point(522, 12);
            this.pct_help.Name = "pct_help";
            this.pct_help.Size = new System.Drawing.Size(42, 39);
            this.pct_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_help.TabIndex = 4;
            this.pct_help.TabStop = false;
            this.pct_help.Tag = "on";
            this.toolTip1.SetToolTip(this.pct_help, "Show help");
            this.pct_help.Click += new System.EventHandler(this.pct_help_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.BackgroundImage = global::CinemaComplex.Properties.Resources.exit;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(499, 390);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(113, 39);
            this.btn_exit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_exit, "Exit the App");
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(570, 12);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(42, 39);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 17;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "on";
            this.toolTip1.SetToolTip(this.pictureBox12, "Show info");
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CinemaComplex.Properties.Resources.entrance_light;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.pct_help);
            this.Controls.Add(this.pct_switch);
            this.Controls.Add(this.pct_clerk);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pct_clerk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_switch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.PictureBox pct_clerk;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pct_switch;
        private System.Windows.Forms.PictureBox pct_help;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

