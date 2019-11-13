namespace Presentation
{
    partial class Frm_Login
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
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.txb_Login = new System.Windows.Forms.TextBox();
            this.ptB_Pass = new System.Windows.Forms.PictureBox();
            this.ptb_ID = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Login = new Presentation.Button_HinhTron();
            this.btn_Caneldn = new Presentation.Button_HinhTron();
            ((System.ComponentModel.ISupportInitialize)(this.ptB_Pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txb_Password
            // 
            this.txb_Password.BackColor = System.Drawing.Color.SkyBlue;
            this.txb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Password.ForeColor = System.Drawing.SystemColors.Info;
            this.txb_Password.Location = new System.Drawing.Point(80, 234);
            this.txb_Password.Multiline = true;
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.PasswordChar = '*';
            this.txb_Password.Size = new System.Drawing.Size(327, 30);
            this.txb_Password.TabIndex = 15;
            this.txb_Password.Text = "qwerty";
            // 
            // txb_Login
            // 
            this.txb_Login.BackColor = System.Drawing.Color.SkyBlue;
            this.txb_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Login.ForeColor = System.Drawing.SystemColors.Info;
            this.txb_Login.Location = new System.Drawing.Point(80, 186);
            this.txb_Login.Multiline = true;
            this.txb_Login.Name = "txb_Login";
            this.txb_Login.Size = new System.Drawing.Size(327, 30);
            this.txb_Login.TabIndex = 14;
            this.txb_Login.Text = "0000000015";
            // 
            // ptB_Pass
            // 
            this.ptB_Pass.Image = global::Presentation.Properties.Resources.Register_icon;
            this.ptB_Pass.Location = new System.Drawing.Point(27, 222);
            this.ptB_Pass.Name = "ptB_Pass";
            this.ptB_Pass.Size = new System.Drawing.Size(47, 42);
            this.ptB_Pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptB_Pass.TabIndex = 13;
            this.ptB_Pass.TabStop = false;
            // 
            // ptb_ID
            // 
            this.ptb_ID.Image = global::Presentation.Properties.Resources.ID_ICON;
            this.ptb_ID.Location = new System.Drawing.Point(27, 174);
            this.ptb_ID.Name = "ptb_ID";
            this.ptb_ID.Size = new System.Drawing.Size(47, 42);
            this.ptb_ID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_ID.TabIndex = 12;
            this.ptb_ID.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation.Properties.Resources.Login_icon;
            this.pictureBox1.Location = new System.Drawing.Point(135, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Login
            // 
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.Image = global::Presentation.Properties.Resources.button_round_dark_arrow_right_icon;
            this.btn_Login.Location = new System.Drawing.Point(78, 275);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(100, 84);
            this.btn_Login.TabIndex = 16;
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Caneldn
            // 
            this.btn_Caneldn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Caneldn.FlatAppearance.BorderSize = 0;
            this.btn_Caneldn.Image = global::Presentation.Properties.Resources.button_round_cancel_icon;
            this.btn_Caneldn.Location = new System.Drawing.Point(264, 275);
            this.btn_Caneldn.Name = "btn_Caneldn";
            this.btn_Caneldn.Size = new System.Drawing.Size(100, 84);
            this.btn_Caneldn.TabIndex = 17;
            this.btn_Caneldn.UseVisualStyleBackColor = true;
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentation.Properties.Resources.line_background_band_light_69088_1280x1024;
            this.CancelButton = this.btn_Caneldn;
            this.ClientSize = new System.Drawing.Size(440, 384);
            this.Controls.Add(this.btn_Caneldn);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txb_Password);
            this.Controls.Add(this.txb_Login);
            this.Controls.Add(this.ptB_Pass);
            this.Controls.Add(this.ptb_ID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Frm_Login";
            this.Text = "Frm_Login";
            ((System.ComponentModel.ISupportInitialize)(this.ptB_Pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.TextBox txb_Login;
        private System.Windows.Forms.PictureBox ptB_Pass;
        private System.Windows.Forms.PictureBox ptb_ID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Button_HinhTron btn_Login;
        private Button_HinhTron btn_Caneldn;
    }
}