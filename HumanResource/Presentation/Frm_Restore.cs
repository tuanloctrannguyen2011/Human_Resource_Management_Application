using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevOne.Security.Cryptography.BCrypt;
namespace Presentation
{
    public partial class Frm_Restore : Form
    {
        public Frm_Restore()
        {
            InitializeComponent();
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            try
            {
                Server DBserver = new Server(new ServerConnection(txt_server.Text));
                Restore DbRestore = new Restore()
                {
                    Database = txt_database.Text,
                    Action = RestoreActionType.Database,
                    ReplaceDatabase = true,
                    NoRecovery = false
                };

                //DbRestore.Devices.AddDevice(@"D:\A_HK1N3\Phat_Trien_Ung_Dung\HumanResource_DA\Backup_data\"+txt_database.Text+".bak", DeviceType.File);
                DbRestore.Devices.AddDevice(@"D:\" + txt_database.Text + ".bak", DeviceType.File);

                DbRestore.PercentComplete += DbRestore_PercentComplete;
                DbRestore.Complete += DbRestore_Complete;
                DbRestore.SqlRestoreAsync(DBserver);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region


        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lbl_Status.Invoke((MethodInvoker)delegate {
                    lbl_Status.Text = e.Error.Message;
                });
            }
            //throw new NotImplementedException();
        }

        private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar2.Invoke((MethodInvoker)delegate {
                progressBar2.Value = e.Percent;
                progressBar2.Update();
            });
            lbl_percent.Invoke((MethodInvoker)delegate
            {
                lbl_percent.Text = $"{e.Percent}%";
            });
            //throw new NotImplementedException();
        }

        #endregion

        public void btn_cancel_FRM_Restore_Click(object sender, EventArgs e)
        {
            //DialogResult rs;
            //rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rs == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void txt_database_Click(object sender, EventArgs e)
        {
            txt_database.Text = "";
            txt_database.ForeColor = Color.Black;
        }

        private void Frm_Restore_Load(object sender, EventArgs e)
        {
            txt_database.Text = "Nhập vào Tên database";
            txt_database.ForeColor = Color.Red;
        }
    }
}
