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
    public partial class Frm_Backup : Form
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }
       // int i = 0;
        string st = "";
        string path_file = "";
        private void btn_backupdata_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int i = r.Next(1, 9999999);
            //string s = @"Data Source="+txt_server.Text+";Initial Catalog="+txt_database.Text+";Integrated Security=True"; 
            progressBar1.Value = 0;
            i++;
            st = i.ToString();

            try
            {
                Server DBserver = new Server(new ServerConnection(txt_server.Text));
                Backup DbBackup = new Backup()
                {
                    Action = BackupActionType.Database,
                    Database = txt_database.Text
                };
                DbBackup.Initialize = true;
                DbBackup.Devices.AddDevice(@"D:\A_HK1N3\Phat_Trien_Ung_Dung\HumanResource_DA\Backup_data\"+txt_database.Text+".bak", DeviceType.File);
                path_file = @"D:\A_HK1N3\Phat_Trien_Ung_Dung\HumanResource_DA\Backup_data\" + txt_database.Text +".bak";
                DbBackup.PercentComplete += DbBackup_PercentComplete;
                DbBackup.Complete += DbBackup_Complete;
                DbBackup.SqlBackupAsync(DBserver);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lbl_Status.Invoke((MethodInvoker)delegate
                {
                    lbl_Status.Text = e.Error.Message;
                    txb_PathAndName.Text = path_file;
                });
            }
            //throw new NotImplementedException();
        }
        
        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lbl_percent.Invoke((MethodInvoker)delegate
            {
                lbl_percent.Text = $"{e.Percent}%";
            });
            //throw new NotImplementedException();
        }

        public void btn_cancel_FRM_BackupData_Click(object sender, EventArgs e)
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

        private void Frm_Backup_Load(object sender, EventArgs e)
        {
            txt_database.Text = "Nhập vào Tên database";
            txt_database.ForeColor = Color.Red;
        }
    }
}
