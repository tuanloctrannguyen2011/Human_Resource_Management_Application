using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Business;
using DevOne.Security.Cryptography.BCrypt;

namespace Presentation
{
    public partial class Frm_DoiMatKhau : Form
    {
        Cls_account_BUS cls_account_bus1;
        string id_current = "";
        public Frm_DoiMatKhau(Cls_Account cls_acc)
        {
            InitializeComponent();
            cls_account_bus1 = new Cls_account_BUS();
            id_current = cls_acc.Id_acc;
        }
     

        private void Frm_DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        public void btn_save_Click(object sender, EventArgs e)
        {
            bool check_change_pass = cls_account_bus1.Check_Change_Pass(id_current, tbx_oldPassword.Text, tbx_newPassword.Text, tbx_confirmPassword.Text);
            if (check_change_pass == true)
            {
                bool check_Success = cls_account_bus1.Change_Pass(id_current, Cls_validate_login.HashPassword( tbx_confirmPassword.Text));
                if (check_Success == true)
                {
                    MessageBox.Show("thay đổi thành công");
                    tbx_confirmPassword.Text = "";
                    tbx_newPassword.Text = "";
                    tbx_oldPassword.Text = "";

                }
                //nếu thành công báo có muốn đăng xuất ra hay không . nếu có thì cho đăng xuấ ra

            }
            else
            {
                MessageBox.Show("thông tin bạn nhập vào chưa chính xác");
            }

        }

      
        public void btn_exit_Click(object sender, EventArgs e)
        {

        }

        public void btn_cancel_Click_1(object sender, EventArgs e)
        {
        //    DialogResult rs = MessageBox.Show("Thay đổi thành công", "Bạn có muốn đăng xuất tài khoản?", MessageBoxButtons.YesNo);
        //    if (rs == DialogResult.Yes)
        //    {
        //        this.DialogResult = DialogResult.OK;
        //    }
        }
    }
}
