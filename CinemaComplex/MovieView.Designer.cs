namespace CinemaComplex
{
    partial class MovieView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pct_audio = new System.Windows.Forms.PictureBox();
            this.pct_help = new System.Windows.Forms.PictureBox();
            this.cmb_movies = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.txtSTime = new System.Windows.Forms.TextBox();
            this.lblSTime = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.txtActor = new System.Windows.Forms.TextBox();
            this.lblActor = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pcbMovie = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_audio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pct_audio);
            this.panel1.Controls.Add(this.pct_help);
            this.panel1.Controls.Add(this.cmb_movies);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtRoom);
            this.panel1.Controls.Add(this.lblRoom);
            this.panel1.Controls.Add(this.txtSTime);
            this.panel1.Controls.Add(this.lblSTime);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.txtDirector);
            this.panel1.Controls.Add(this.lblDirector);
            this.panel1.Controls.Add(this.txtActor);
            this.panel1.Controls.Add(this.lblActor);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pcbMovie);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 486);
            this.panel1.TabIndex = 0;
            // 
            // pct_audio
            // 
            this.pct_audio.BackColor = System.Drawing.Color.Transparent;
            this.pct_audio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pct_audio.Image = global::CinemaComplex.Properties.Resources.icons8_sound_80px;
            this.pct_audio.Location = new System.Drawing.Point(776, 3);
            this.pct_audio.Name = "pct_audio";
            this.pct_audio.Size = new System.Drawing.Size(42, 39);
            this.pct_audio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_audio.TabIndex = 24;
            this.pct_audio.TabStop = false;
            this.pct_audio.Tag = "on";
            this.toolTip1.SetToolTip(this.pct_audio, "Turn sound On/Off");
            this.pct_audio.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pct_help
            // 
            this.pct_help.BackColor = System.Drawing.Color.Transparent;
            this.pct_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pct_help.Image = global::CinemaComplex.Properties.Resources.icons8_help_80px;
            this.pct_help.Location = new System.Drawing.Point(824, 3);
            this.pct_help.Name = "pct_help";
            this.pct_help.Size = new System.Drawing.Size(42, 39);
            this.pct_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_help.TabIndex = 23;
            this.pct_help.TabStop = false;
            this.pct_help.Tag = "on";
            this.toolTip1.SetToolTip(this.pct_help, "Show help");
            this.pct_help.Click += new System.EventHandler(this.pct_help_Click_1);
            // 
            // cmb_movies
            // 
            this.cmb_movies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmb_movies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmb_movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_movies.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmb_movies.FormattingEnabled = true;
            this.cmb_movies.ItemHeight = 20;
            this.cmb_movies.Location = new System.Drawing.Point(155, 160);
            this.cmb_movies.Name = "cmb_movies";
            this.cmb_movies.Size = new System.Drawing.Size(377, 160);
            this.cmb_movies.TabIndex = 22;
            this.toolTip1.SetToolTip(this.cmb_movies, "Click on a movie to select it");
            this.cmb_movies.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(99, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRoom.Location = new System.Drawing.Point(808, 326);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(58, 24);
            this.txtRoom.TabIndex = 20;
            this.txtRoom.Tag = "10";
            this.toolTip1.SetToolTip(this.txtRoom, "Selected movie\'s room number");
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRoom.Location = new System.Drawing.Point(725, 326);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(74, 25);
            this.lblRoom.TabIndex = 19;
            this.lblRoom.Text = "Room:";
            // 
            // txtSTime
            // 
            this.txtSTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSTime.Location = new System.Drawing.Point(808, 354);
            this.txtSTime.Name = "txtSTime";
            this.txtSTime.ReadOnly = true;
            this.txtSTime.Size = new System.Drawing.Size(58, 24);
            this.txtSTime.TabIndex = 18;
            this.txtSTime.Tag = "10";
            this.toolTip1.SetToolTip(this.txtSTime, "Schedule time of the  selected movie\'s screening");
            // 
            // lblSTime
            // 
            this.lblSTime.AutoSize = true;
            this.lblSTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSTime.Location = new System.Drawing.Point(727, 353);
            this.lblSTime.Name = "lblSTime";
            this.lblSTime.Size = new System.Drawing.Size(65, 25);
            this.lblSTime.TabIndex = 17;
            this.lblSTime.Text = "Time:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPrice.Location = new System.Drawing.Point(830, 381);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(36, 24);
            this.txtPrice.TabIndex = 16;
            this.txtPrice.Tag = "10";
            this.txtPrice.Text = "10€";
            this.toolTip1.SetToolTip(this.txtPrice, "Price per ticket for the selected movie");
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPrice.Location = new System.Drawing.Point(693, 381);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(131, 25);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Ticket Price:";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(443, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(203, 95);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCancel, "Return to the  main hall");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(210, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(203, 95);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "NEXT";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnOk, "Go to seat selector");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTime.Location = new System.Drawing.Point(737, 296);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(129, 24);
            this.txtTime.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtTime, "Duration of the movie you have selected");
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTime.Location = new System.Drawing.Point(727, 268);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(132, 25);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "Watch Time:";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDate.Location = new System.Drawing.Point(737, 238);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(129, 24);
            this.txtDate.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtDate, "Selected movie\'s  release date");
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDate.Location = new System.Drawing.Point(727, 210);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(148, 25);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Release Date:";
            // 
            // txtDirector
            // 
            this.txtDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDirector.Location = new System.Drawing.Point(538, 295);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.ReadOnly = true;
            this.txtDirector.Size = new System.Drawing.Size(165, 24);
            this.txtDirector.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtDirector, "Selected movie\'s director");
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDirector.Location = new System.Drawing.Point(538, 267);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(93, 25);
            this.lblDirector.TabIndex = 7;
            this.lblDirector.Text = "Director:";
            // 
            // txtActor
            // 
            this.txtActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActor.Location = new System.Drawing.Point(538, 238);
            this.txtActor.Name = "txtActor";
            this.txtActor.ReadOnly = true;
            this.txtActor.Size = new System.Drawing.Size(165, 24);
            this.txtActor.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtActor, "Selected movie\'s leading actor");
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActor.Location = new System.Drawing.Point(538, 210);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(151, 25);
            this.lblActor.TabIndex = 5;
            this.lblActor.Text = "Leading Actor:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTitle.Location = new System.Drawing.Point(538, 180);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(328, 24);
            this.txtTitle.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtTitle, "Title of the movie you have selected");
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTitle.Location = new System.Drawing.Point(538, 152);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(59, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title:";
            // 
            // pcbMovie
            // 
            this.pcbMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbMovie.Image = ((System.Drawing.Image)(resources.GetObject("pcbMovie.Image")));
            this.pcbMovie.Location = new System.Drawing.Point(12, 125);
            this.pcbMovie.Name = "pcbMovie";
            this.pcbMovie.Size = new System.Drawing.Size(139, 308);
            this.pcbMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMovie.TabIndex = 2;
            this.pcbMovie.TabStop = false;
            // 
            // MovieView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(878, 486);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MovieView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Box Office";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MovieView_FormClosed);
            this.Load += new System.EventHandler(this.MovieView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_audio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox txtActor;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pcbMovie;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtSTime;
        private System.Windows.Forms.Label lblSTime;
        private System.Windows.Forms.ListBox cmb_movies;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pct_help;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pct_audio;
    }
}