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
using DevOne.Security.Cryptography.BCrypt;

namespace Presentation
{
    public partial class Frm_Main : Form
    {

        Cls_Account acc_curent = new Cls_Account();

        
        public Frm_Main()
        {
            InitializeComponent();
        }
        public Frm_Main(Cls_Account acoount1)
        {
            InitializeComponent();
            this.Text = acoount1.Role_name;
            Load_Form(acoount1);
            acc_curent = acoount1;
        }
        public void Load_Form(Cls_Account a)
        {
            bool e = false;
            if (a.Role_name.Trim().Equals("admin") == true)
            {
                // page admin
                adminToolStripMenuItem.Enabled = !e;
                //page Lãnh đạo
                lãnhĐạoToolStripMenuItem.Enabled = e;
                //page cán bộ nhân sự
                cánBộNhânSựToolStripMenuItem.Enabled = e;
                //page Nhân sự 
                nhânViênToolStripMenuItem.Enabled = !e;

            }
            if (a.Role_name.Trim().Equals("manager") == true)
            {
                //page Lãnh đạo
                lãnhĐạoToolStripMenuItem.Enabled = !e;
                // page admin
                adminToolStripMenuItem.Enabled = e;
                //page cán bộ nhân sự
                cánBộNhânSựToolStripMenuItem.Enabled = e;
                //page Nhân sự 
                nhânViênToolStripMenuItem.Enabled = !e;

            }

            if (a.Role_name.Trim().Equals("hrstaff") == true)
            {
                //page cán bộ nhân sự
                cánBộNhânSựToolStripMenuItem.Enabled = !e;
                // page admin
                adminToolStripMenuItem.Enabled = e;
                //page Lãnh đạo
                lãnhĐạoToolStripMenuItem.Enabled = e;
                //page Nhân sự 
                nhânViênToolStripMenuItem.Enabled = !e;

            }
            else if (a.Role_name.Trim().Equals("staff") == true)
            {
                //page Nhân sự 
                nhânViênToolStripMenuItem.Enabled = !e;
                // page admin
                adminToolStripMenuItem.Enabled = e;
                //page Lãnh đạo
                lãnhĐạoToolStripMenuItem.Enabled = e;
                //page cán bộ nhân sự
                cánBộNhânSựToolStripMenuItem.Enabled = e;


            }
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frm_Backup frm_backupDT1 = new Frm_Backup();
            // frm_backupDT1.FormClosing += Frm_backupDT1_FormClosing;
            //this.Embed_form(frm_backupDT1);


            tabControl1.Visible = true;
            string title = "Backup data" + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            myTabPage.AutoScroll = true;
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            //pnl.AutoSize = true;
            pnl.AutoScroll = true;
            Frm_Backup a = new Frm_Backup();
            a.btn_cancel_FRM_BackupData.Click += Btn_cancel_FRM_BackupData_Click;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            a.Dock = DockStyle.Fill;
            a.Parent = pnl;
            pnl.Controls.Add(a);
            a.Show();
            myTabPage.Controls.Add(pnl);
            tabControl1.TabPages.Add(myTabPage);
            //tabPage1.Controls.Add(a);
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;

        }

        private void Btn_cancel_FRM_BackupData_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            // throw new NotImplementedException();
        }

        public void Embed_form(Form frm)
        {
            // Remove any existing form
            if (this.gdnP_main.Controls.Count > 0)
                this.gdnP_main.Controls[0].Dispose();
            // Embed new one
            frm.TopLevel = false;
            //  frm.FormBorderStyle = FormBorderStyle.None;
            frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            this.gdnP_main.Controls.Add(frm);
            frm.Show();
        }
        public void Embed_form2(Form a,string title_p)
        {
            tabControl1.Visible = true;
            tabControl1.Dock = DockStyle.Fill;
            string title = title_p + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            
            myTabPage.AutoScroll = true;
            
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            //pnl.AutoSize = true;
            pnl.AutoScroll = true;
            //Frm_Backup a = new Frm_Backup();
            //a.btn_cancel_FRM_BackupData.Click += Btn_cancel_FRM_BackupData_Click;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            a.Dock = DockStyle.Fill;  
            a.Parent = pnl;
            pnl.Controls.Add(a);
            a.Show();
            myTabPage.Controls.Add(pnl);
            tabControl1.TabPages.Add(myTabPage);
            
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
 

            
        }
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void restoreDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Frm_Restore frm__restoreDT1 = new Frm_Restore();
            // frm__restoreDT1.FormClosing += Frm__restoreDT1_FormClosing;
            //this.Embed_form(frm__restoreDT1);
            tabControl1.Visible = true;
            string title = "Restore data" + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            myTabPage.AutoScroll = true;

            Panel pnl = new Panel();

            pnl.Dock = DockStyle.Fill;
            //pnl.AutoSize = true;
            pnl.AutoScroll = true;
            Frm_Restore a = new Frm_Restore();
            a.btn_cancel_FRM_Restore.Click += Btn_cancel_FRM_Restore_Click;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            a.Dock = DockStyle.Fill;
            //a.WindowState = FormWindowState.Maximized;
            a.AutoScroll = true;
            pnl.Controls.Add(a);
            a.Show();
            myTabPage.Controls.Add(pnl);
            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void Btn_cancel_FRM_Restore_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //tabControl1.Visible = false;
            tabControl1.TabPages.Clear();
        
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.Visible = true;
            //tabControl1.SizeMode = TabSizeMode.Fixed;
             string title = "Phân quyền tài khoản " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
           
            myTabPage.AutoScroll = true;
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            //pnl.AutoSize = true;
            pnl.AutoScroll = true;
            Frm_PhanQuyen a = new Frm_PhanQuyen(acc_curent);
            a.btn_cancel_PhanQuyen.Click += Btn_cancel_PhanQuyen_Click;
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            a.Dock = DockStyle.Fill;
            a.Parent = pnl;
            pnl.Controls.Add(a);
            a.Show();
            myTabPage.Controls.Add(pnl);
            tabControl1.TabPages.Add(myTabPage);
            //tabPage1.Controls.Add(a);
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;



        }

        private void Btn_cancel_PhanQuyen_Click(object sender, EventArgs e)
        {

            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);

            }
            //throw new NotImplementedException();
        }

        private void QuyếtđịnhtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_GiaiQuyetNghiViec frm_gqnv = new Frm_GiaiQuyetNghiViec(acc_curent);
            Embed_form2(frm_gqnv, "Giải quyết Nghỉ việc");
            frm_gqnv.btn_cancel_GiaiQuyetNghiViec.Click += Btn_cancel_GiaiQuyetNghiViec_Click;

            //tabControl1.Visible = true;
            ////tabControl1.SizeMode = TabSizeMode.Fixed;
            //string title = "Giải quyết nghỉ việc " + (tabControl1.TabCount + 1).ToString();
            //TabPage myTabPage = new TabPage(title);

            //myTabPage.AutoScroll = true;
            //Panel pnl = new Panel();
            //pnl.Dock = DockStyle.Fill;
            ////pnl.AutoSize = true;
            //pnl.AutoScroll = true;
            //Frm_GiaiQuyetNghiViec a = new Frm_GiaiQuyetNghiViec();
            //a.btn_cancel_GiaiQuyetNghiViec.Click += Btn_cancel_GiaiQuyetNghiViec_Click;
            //a.TopLevel = false;
            //a.FormBorderStyle = FormBorderStyle.None;
            //a.Dock = DockStyle.Fill;
            //a.Parent = pnl;
            //pnl.Controls.Add(a);
            //a.Show();
            //myTabPage.Controls.Add(pnl);
            //tabControl1.TabPages.Add(myTabPage);
            ////tabPage1.Controls.Add(a);

        }

        private void Btn_cancel_GiaiQuyetNghiViec_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                tabControl1.TabPages.Remove(tabControl1.SelectedTab);

            }
            //throw new NotImplementedException();
        }

       

        private void Btn_Cancel_ThemPhongBan_Click(object sender, EventArgs e)
        {

            DialogResult rs;
            rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            // throw new NotImplementedException();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult check_logout = MessageBox.Show("bạn muốn đăng xuất tài khoản", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check_logout == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DoiMatKhau frm_dmk = new Frm_DoiMatKhau(acc_curent);
            Embed_form2(frm_dmk,"Đổi mật khẩu tài khoản");
            frm_dmk.btn_exit.Click += Btn_exit_Click;
            frm_dmk.btn_cancel.Click += Btn_cancel_Click;
        }

       

        private void Btn_cancel_Click(object sender, EventArgs e)
        {

            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                this.DialogResult =DialogResult.Yes;
                //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

        private void thôngTinPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ThongTinPhongBan frm_ttpb = new Frm_ThongTinPhongBan(acc_curent);
            Embed_form2(frm_ttpb,"Thông tin phòng ban");
            frm_ttpb.btn_exit.Click += Btn_exit_Click1;
        }

        private void Btn_exit_Click1(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

       
        private void toolStripMenuItem_danhgia_Click(object sender, EventArgs e)
        {
            Frm_Danhgia frm_danhgia = new Frm_Danhgia(acc_curent);
            Embed_form2(frm_danhgia,"Đánh giá nhân viên");
            frm_danhgia.btn_exit.Click += Btn_exit_Click2;
        }

        private void Btn_exit_Click2(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                //this.DialogResult = DialogResult.Yes;
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ThongTinCaNhan frm_ttcn = new Frm_ThongTinCaNhan(acc_curent);
            Embed_form2(frm_ttcn, "Thông tin cá nhân");
            frm_ttcn.btn_cancel_form_ttcn.Click += Btn_cancel_form_ttcn_Click;
        }

        private void Btn_cancel_form_ttcn_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            //throw new NotImplementedException();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ThongTinPhongBan frm_nhanvien = new Frm_ThongTinPhongBan(acc_curent);
            Embed_form2(frm_nhanvien, "Nhân viên ");
            frm_nhanvien.btn_exit.Click += Btn_exit_Click3;
           

        }

        private void Btn_exit_Click3(object sender, EventArgs e)
        {

            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            // throw new NotImplementedException();
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CongViec frm_congviec = new Frm_CongViec();
            Embed_form2(frm_congviec,"Công việc trong công ty ");
            frm_congviec.btn_exit.Click += Btn_exit_Click4;
        }

        private void Btn_exit_Click4(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn muốn thoát", "thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            // throw new NotImplementedException();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PhongBan frm_pb = new Frm_PhongBan();
            Embed_form2(frm_pb, "Thêm mới một nhân viên ");
            frm_pb.btn_Cancel_ThemPhongBan.Click += Btn_Cancel_ThemPhongBan_Click;
        }

        private void hướngDẫnSửDụngPhậnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "HDSD.chm"));
        }
    }
}
