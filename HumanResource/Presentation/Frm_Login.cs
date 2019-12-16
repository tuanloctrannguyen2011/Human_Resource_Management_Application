using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Entity;
using DevOne.Security.Cryptography.BCrypt;
namespace Presentation
{
    public partial class Frm_Login : Form
    {
        Cls_account_BUS cls_account_BUS1 = new Cls_account_BUS();
        public Cls_Account obj_dn = new Cls_Account();
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txb_Login.Text.Trim() == "" && txb_Password.Text.Trim() != "")
            {
                MessageBox.Show("mời bạn nhập vào ID đăng nhập","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (txb_Login.Text.Trim() != "" && txb_Password.Text.Trim() == "")
            {
                MessageBox.Show("mời bạn nhập vào password đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txb_Login.Text.Trim() == "" && txb_Password.Text.Trim() == "")
            {
                MessageBox.Show("mời bạn nhập vào id và password đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txb_Login.Text.Trim() != "" && txb_Password.Text.Trim() != "")
            {

                bool check_id = cls_account_BUS1.Check_ID_DAL(txb_Login.Text);
                //bool check_ps = cls_account_BUS1.Check_PASS_DAL(txb_Login.Text, txb_Password.Text);
                bool check_ps = false;
                string s = cls_account_BUS1.Get_PASS_by_id_BUS(txb_Login.Text);

                check_ps = Cls_validate_login.ValidatePassword(txb_Password.Text, s);

                if (check_id == false && check_ps == false)
                {
                    MessageBox.Show("bạn nhậm sai ID hoặc PASSWORD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (check_id == false && check_ps == true)
                {
                    MessageBox.Show("Bạn nhập sai ID ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (check_id == true && check_ps == false)
                {
                    MessageBox.Show("Bạn nhập sai PASSWORD ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (check_id == true && check_ps == true)
                {
                    bool check_acc_exists = cls_account_BUS1.Check_acc_exists_BUS(txb_Login.Text);
                    if (check_acc_exists == true)
                    {
                        obj_dn = cls_account_BUS1.Get_information_dn_DAL(txb_Login.Text, s);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("tài khoản này đã bị vô hiệu hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
        }

        private void ptb_view_pass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txb_Password.PasswordChar == (char)'*')
            {
                txb_Password.PasswordChar = (char)0;
                ptb_view_pass.Image = Presentation.Properties.Resources.view_pass;
            }
            else
            {
                txb_Password.PasswordChar = Convert.ToChar("*");
                ptb_view_pass.Image = Presentation.Properties.Resources.hiden_pass;
            }
        }

       
    }
}
