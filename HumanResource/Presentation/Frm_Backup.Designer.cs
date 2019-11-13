namespace Presentation
{
    partial class Frm_Backup
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
            this.gdnP_backup = new Presentation.Gardient_Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_backupdata = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_PathAndName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gdnP_title_backup = new Presentation.Gardient_Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_cancel_FRM_BackupData = new System.Windows.Forms.Button();
            this.gdnP_backup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gdnP_title_backup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdnP_backup
            // 
            this.gdnP_backup.Angle = 0F;
            this.gdnP_backup.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gdnP_backup.BottomColor = System.Drawing.Color.Empty;
            this.gdnP_backup.Controls.Add(this.label1);
            this.gdnP_backup.Controls.Add(this.label3);
            this.gdnP_backup.Controls.Add(this.txt_database);
            this.gdnP_backup.Controls.Add(this.panel2);
            this.gdnP_backup.Controls.Add(this.txt_server);
            this.gdnP_backup.Controls.Add(this.label5);
            this.gdnP_backup.Controls.Add(this.txb_PathAndName);
            this.gdnP_backup.Controls.Add(this.panel1);
            this.gdnP_backup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdnP_backup.Location = new System.Drawing.Point(0, 42);
            this.gdnP_backup.Name = "gdnP_backup";
            this.gdnP_backup.Size = new System.Drawing.Size(381, 350);
            this.gdnP_backup.TabIndex = 34;
            this.gdnP_backup.TopColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Server";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SkyBlue;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "DataBase";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(125, 46);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(219, 20);
            this.txt_database.TabIndex = 28;
            this.txt_database.Click += new System.EventHandler(this.txt_database_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btn_backupdata);
            this.panel2.Controls.Add(this.lbl_Status);
            this.panel2.Controls.Add(this.lbl_percent);
            this.panel2.Location = new System.Drawing.Point(6, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 120);
            this.panel2.TabIndex = 30;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // btn_backupdata
            // 
            this.btn_backupdata.Location = new System.Drawing.Point(108, 83);
            this.btn_backupdata.Name = "btn_backupdata";
            this.btn_backupdata.Size = new System.Drawing.Size(133, 25);
            this.btn_backupdata.TabIndex = 9;
            this.btn_backupdata.Text = "Backup Data";
            this.btn_backupdata.UseVisualStyleBackColor = true;
            this.btn_backupdata.Click += new System.EventHandler(this.btn_backupdata_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.BackColor = System.Drawing.Color.SkyBlue;
            this.lbl_Status.Location = new System.Drawing.Point(4, 57);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(348, 23);
            this.lbl_Status.TabIndex = 11;
            this.lbl_Status.Text = "Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_percent
            // 
            this.lbl_percent.BackColor = System.Drawing.Color.SkyBlue;
            this.lbl_percent.Location = new System.Drawing.Point(151, 29);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(41, 23);
            this.lbl_percent.TabIndex = 10;
            this.lbl_percent.Text = "0%";
            this.lbl_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(125, 13);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(219, 20);
            this.txt_server.TabIndex = 27;
            this.txt_server.Text = "LENOVO_IDEAPAD_\\SQLEXPRESS";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.Location = new System.Drawing.Point(20, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "path and file name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txb_PathAndName
            // 
            this.txb_PathAndName.Location = new System.Drawing.Point(125, 151);
            this.txb_PathAndName.Name = "txb_PathAndName";
            this.txb_PathAndName.Size = new System.Drawing.Size(219, 20);
            this.txb_PathAndName.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 73);
            this.panel1.TabIndex = 29;
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
            // gdnP_title_backup
            // 
            this.gdnP_title_backup.Angle = 0F;
            this.gdnP_title_backup.BackColor = System.Drawing.Color.White;
            this.gdnP_title_backup.BottomColor = System.Drawing.Color.Empty;
            this.gdnP_title_backup.Controls.Add(this.label6);
            this.gdnP_title_backup.Controls.Add(this.btn_cancel_FRM_BackupData);
            this.gdnP_title_backup.Dock = System.Windows.Forms.DockStyle.Top;
            this.gdnP_title_backup.Location = new System.Drawing.Point(0, 0);
            this.gdnP_title_backup.Name = "gdnP_title_backup";
            this.gdnP_title_backup.Size = new System.Drawing.Size(381, 42);
            this.gdnP_title_backup.TabIndex = 33;
            this.gdnP_title_backup.TopColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 42);
            this.label6.TabIndex = 24;
            this.label6.Text = "Backup Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_cancel_FRM_BackupData
            // 
            this.btn_cancel_FRM_BackupData.BackColor = System.Drawing.Color.Red;
            this.btn_cancel_FRM_BackupData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel_FRM_BackupData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_FRM_BackupData.ForeColor = System.Drawing.Color.Transparent;
            this.btn_cancel_FRM_BackupData.Location = new System.Drawing.Point(342, 0);
            this.btn_cancel_FRM_BackupData.Name = "btn_cancel_FRM_BackupData";
            this.btn_cancel_FRM_BackupData.Size = new System.Drawing.Size(39, 42);
            this.btn_cancel_FRM_BackupData.TabIndex = 23;
            this.btn_cancel_FRM_BackupData.Text = "X";
            this.btn_cancel_FRM_BackupData.UseVisualStyleBackColor = false;
            this.btn_cancel_FRM_BackupData.Click += new System.EventHandler(this.btn_cancel_FRM_BackupData_Click);
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(381, 392);
            this.Controls.Add(this.gdnP_backup);
            this.Controls.Add(this.gdnP_title_backup);
            this.Name = "Frm_Backup";
            this.Text = "Frm_Backup";
            this.Load += new System.EventHandler(this.Frm_Backup_Load);
            this.gdnP_backup.ResumeLayout(false);
            this.gdnP_backup.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gdnP_title_backup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_database;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_backupdata;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btn_cancel_FRM_BackupData;
        private Gardient_Panel gdnP_title_backup;
        private Gardient_Panel gdnP_backup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_PathAndName;
    }
}