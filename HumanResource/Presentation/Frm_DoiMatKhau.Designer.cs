namespace Presentation
{
    partial class Frm_DoiMatKhau
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gardient_Panel2 = new Presentation.Gardient_Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gardient_Panel1 = new Presentation.Gardient_Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_confirmPassword = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_oldPassword = new System.Windows.Forms.TextBox();
            this.tbx_newPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gardient_Panel2.SuspendLayout();
            this.gardient_Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gardient_Panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gardient_Panel1);
            this.splitContainer1.Size = new System.Drawing.Size(344, 280);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // gardient_Panel2
            // 
            this.gardient_Panel2.Angle = 0F;
            this.gardient_Panel2.BottomColor = System.Drawing.Color.DeepSkyBlue;
            this.gardient_Panel2.Controls.Add(this.btn_exit);
            this.gardient_Panel2.Controls.Add(this.label1);
            this.gardient_Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gardient_Panel2.Location = new System.Drawing.Point(0, 0);
            this.gardient_Panel2.Name = "gardient_Panel2";
            this.gardient_Panel2.Size = new System.Drawing.Size(344, 25);
            this.gardient_Panel2.TabIndex = 0;
            this.gardient_Panel2.TopColor = System.Drawing.Color.White;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(306, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(38, 25);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "X";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đổi Mật Khẩu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gardient_Panel1
            // 
            this.gardient_Panel1.Angle = 120F;
            this.gardient_Panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gardient_Panel1.BottomColor = System.Drawing.Color.Empty;
            this.gardient_Panel1.Controls.Add(this.label4);
            this.gardient_Panel1.Controls.Add(this.tbx_confirmPassword);
            this.gardient_Panel1.Controls.Add(this.btn_cancel);
            this.gardient_Panel1.Controls.Add(this.btn_save);
            this.gardient_Panel1.Controls.Add(this.label2);
            this.gardient_Panel1.Controls.Add(this.label3);
            this.gardient_Panel1.Controls.Add(this.tbx_oldPassword);
            this.gardient_Panel1.Controls.Add(this.tbx_newPassword);
            this.gardient_Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gardient_Panel1.Location = new System.Drawing.Point(0, 0);
            this.gardient_Panel1.Name = "gardient_Panel1";
            this.gardient_Panel1.Size = new System.Drawing.Size(344, 251);
            this.gardient_Panel1.TabIndex = 0;
            this.gardient_Panel1.TopColor = System.Drawing.Color.White;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nhập lại:";
            // 
            // tbx_confirmPassword
            // 
            this.tbx_confirmPassword.BackColor = System.Drawing.Color.LightBlue;
            this.tbx_confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_confirmPassword.ForeColor = System.Drawing.Color.White;
            this.tbx_confirmPassword.Location = new System.Drawing.Point(133, 125);
            this.tbx_confirmPassword.Name = "tbx_confirmPassword";
            this.tbx_confirmPassword.Size = new System.Drawing.Size(167, 23);
            this.tbx_confirmPassword.TabIndex = 14;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(191, 184);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(84, 32);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "Thoát";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click_1);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(74, 185);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(84, 32);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Lưu";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // tbx_oldPassword
            // 
            this.tbx_oldPassword.BackColor = System.Drawing.Color.LightBlue;
            this.tbx_oldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_oldPassword.ForeColor = System.Drawing.Color.White;
            this.tbx_oldPassword.Location = new System.Drawing.Point(133, 41);
            this.tbx_oldPassword.Name = "tbx_oldPassword";
            this.tbx_oldPassword.Size = new System.Drawing.Size(167, 23);
            this.tbx_oldPassword.TabIndex = 9;
            // 
            // tbx_newPassword
            // 
            this.tbx_newPassword.BackColor = System.Drawing.Color.LightBlue;
            this.tbx_newPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_newPassword.ForeColor = System.Drawing.Color.White;
            this.tbx_newPassword.Location = new System.Drawing.Point(133, 83);
            this.tbx_newPassword.Name = "tbx_newPassword";
            this.tbx_newPassword.Size = new System.Drawing.Size(167, 23);
            this.tbx_newPassword.TabIndex = 10;
            // 
            // Frm_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 280);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Frm_DoiMatKhau";
            this.Text = "6";
            this.Load += new System.EventHandler(this.Frm_DoiMatKhau_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gardient_Panel2.ResumeLayout(false);
            this.gardient_Panel1.ResumeLayout(false);
            this.gardient_Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Gardient_Panel gardient_Panel2;
        private System.Windows.Forms.Label label1;
        private Gardient_Panel gardient_Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btn_exit;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.TextBox tbx_oldPassword;
        public System.Windows.Forms.TextBox tbx_newPassword;
        public System.Windows.Forms.TextBox tbx_confirmPassword;
    }
}