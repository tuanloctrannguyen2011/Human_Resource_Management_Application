namespace Presentation
{
    partial class Frm_Restore
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
            this.gardient_Panel2 = new Presentation.Gardient_Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_cancel_FRM_Restore = new System.Windows.Forms.Button();
            this.gardient_Panel1 = new Presentation.Gardient_Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btn_Restore = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gardient_Panel2.SuspendLayout();
            this.gardient_Panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gardient_Panel2
            // 
            this.gardient_Panel2.Angle = 0F;
            this.gardient_Panel2.BackColor = System.Drawing.Color.White;
            this.gardient_Panel2.BottomColor = System.Drawing.Color.Empty;
            this.gardient_Panel2.Controls.Add(this.label6);
            this.gardient_Panel2.Controls.Add(this.btn_cancel_FRM_Restore);
            this.gardient_Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gardient_Panel2.Location = new System.Drawing.Point(0, 0);
            this.gardient_Panel2.Name = "gardient_Panel2";
            this.gardient_Panel2.Size = new System.Drawing.Size(382, 58);
            this.gardient_Panel2.TabIndex = 42;
            this.gardient_Panel2.TopColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 58);
            this.label6.TabIndex = 32;
            this.label6.Text = "Restore Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_cancel_FRM_Restore
            // 
            this.btn_cancel_FRM_Restore.BackColor = System.Drawing.Color.Red;
            this.btn_cancel_FRM_Restore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel_FRM_Restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_FRM_Restore.ForeColor = System.Drawing.Color.Transparent;
            this.btn_cancel_FRM_Restore.Location = new System.Drawing.Point(343, 0);
            this.btn_cancel_FRM_Restore.Name = "btn_cancel_FRM_Restore";
            this.btn_cancel_FRM_Restore.Size = new System.Drawing.Size(39, 58);
            this.btn_cancel_FRM_Restore.TabIndex = 31;
            this.btn_cancel_FRM_Restore.Text = "X";
            this.btn_cancel_FRM_Restore.UseVisualStyleBackColor = false;
            this.btn_cancel_FRM_Restore.Click += new System.EventHandler(this.btn_cancel_FRM_Restore_Click);
            // 
            // gardient_Panel1
            // 
            this.gardient_Panel1.Angle = 0F;
            this.gardient_Panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gardient_Panel1.BottomColor = System.Drawing.Color.Empty;
            this.gardient_Panel1.Controls.Add(this.label1);
            this.gardient_Panel1.Controls.Add(this.label3);
            this.gardient_Panel1.Controls.Add(this.txt_server);
            this.gardient_Panel1.Controls.Add(this.panel3);
            this.gardient_Panel1.Controls.Add(this.txt_database);
            this.gardient_Panel1.Controls.Add(this.panel1);
            this.gardient_Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gardient_Panel1.Location = new System.Drawing.Point(0, 0);
            this.gardient_Panel1.Name = "gardient_Panel1";
            this.gardient_Panel1.Size = new System.Drawing.Size(382, 391);
            this.gardient_Panel1.TabIndex = 41;
            this.gardient_Panel1.TopColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "Server";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SkyBlue;
            this.label3.Location = new System.Drawing.Point(24, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "DataBase";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(131, 81);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(219, 20);
            this.txt_server.TabIndex = 43;
            this.txt_server.Text = "LENOVO_IDEAPAD_\\SQLEXPRESS";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lbl_percent);
            this.panel3.Controls.Add(this.progressBar2);
            this.panel3.Controls.Add(this.btn_Restore);
            this.panel3.Controls.Add(this.lbl_Status);
            this.panel3.Location = new System.Drawing.Point(12, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 118);
            this.panel3.TabIndex = 46;
            // 
            // lbl_percent
            // 
            this.lbl_percent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_percent.Location = new System.Drawing.Point(163, 29);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(41, 23);
            this.lbl_percent.TabIndex = 18;
            this.lbl_percent.Text = "0%";
            this.lbl_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(3, 3);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(352, 23);
            this.progressBar2.TabIndex = 16;
            // 
            // btn_Restore
            // 
            this.btn_Restore.Location = new System.Drawing.Point(129, 80);
            this.btn_Restore.Name = "btn_Restore";
            this.btn_Restore.Size = new System.Drawing.Size(109, 25);
            this.btn_Restore.TabIndex = 13;
            this.btn_Restore.Text = "Restore";
            this.btn_Restore.UseVisualStyleBackColor = true;
            this.btn_Restore.Click += new System.EventHandler(this.btn_Restore_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Location = new System.Drawing.Point(4, 57);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(351, 23);
            this.lbl_Status.TabIndex = 19;
            this.lbl_Status.Text = "Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(131, 114);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(219, 20);
            this.txt_database.TabIndex = 44;
            this.txt_database.Click += new System.EventHandler(this.txt_database_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 73);
            this.panel1.TabIndex = 45;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(120, 44);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(219, 20);
            this.txt_password.TabIndex = 11;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(121, 8);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(219, 20);
            this.txt_username.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SkyBlue;
            this.label4.Location = new System.Drawing.Point(14, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "User name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 391);
            this.Controls.Add(this.gardient_Panel2);
            this.Controls.Add(this.gardient_Panel1);
            this.Name = "Frm_Restore";
            this.Text = "Frm_Restore";
            this.Load += new System.EventHandler(this.Frm_Restore_Load);
            this.gardient_Panel2.ResumeLayout(false);
            this.gardient_Panel1.ResumeLayout(false);
            this.gardient_Panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btn_cancel_FRM_Restore;
        private Gardient_Panel gardient_Panel1;
        private Gardient_Panel gardient_Panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btn_Restore;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.TextBox txt_database;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}