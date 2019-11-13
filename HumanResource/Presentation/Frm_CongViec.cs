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
    public partial class Frm_CongViec : Form
    {
        Cls_JobTitle_BUS cls_job_bus1 = new Cls_JobTitle_BUS();
        Cls_Account account_curent = new Cls_Account();
        List<Cls_JobTitle> current_datasource;

        public Frm_CongViec()
        {
            InitializeComponent();
        }

        public Frm_CongViec(Cls_Account init_account)
        {
            InitializeComponent();
            account_curent = init_account;
        }

        private void Frm_Danhgia_Load(object sender, EventArgs e)
        {
            toolStripTextBox_content_search.Text = "nhập vào nội dung cần tìm kiếm";
            toolStripTextBox_content_search.ForeColor = Color.DeepSkyBlue;
            innit_listview(lsv_CongViec);
            current_datasource = cls_job_bus1.Get_All_jobTitle_BUS();
            load_Data_To_lvs(current_datasource);
            lsv_CongViec.SmallImageList = small_iamge;
            for (int a = 0; a < lsv_CongViec.Items.Count; a++)
            {
                lsv_CongViec.Items[a].ImageIndex = 0;
            }
            tbx_id_cv.Enabled = false;
           
        }
        public void innit_listview(ListView lsv)
        {
            lsv.View = View.Details;
            lsv.GridLines = true;
            lsv.FullRowSelect = true;

            string[] header = { "STT", "ID ", "Tên công việc" };
            lsv.Columns.Add(header[0], 60, HorizontalAlignment.Left);
            lsv.Columns.Add(header[1], 200, HorizontalAlignment.Center);
            lsv.Columns.Add(header[2], 500, HorizontalAlignment.Center);



        }

        private void load_Data_To_lvs(List<Cls_JobTitle> datasource)
        {
            lsv_CongViec.Items.Clear();
            int i = 1;
            foreach (Cls_JobTitle item in datasource)
            {

                ListViewItem listViewItem = new ListViewItem(new string[] { i.ToString(), item.Id_job, item.Name_job }) { Tag = item.Des_job };
                lsv_CongViec.Items.Add(listViewItem);
                i++;

            }

        }

        private void lsv_CongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_CongViec.SelectedItems.Count > 0)
            {
                load_To_tbx();
            }
        }

        private void load_To_tbx()
        {
            tbx_id_cv.Text = lsv_CongViec.SelectedItems[0].SubItems[1].Text;
            tbx_TenCV.Text = lsv_CongViec.SelectedItems[0].SubItems[2].Text;
            rTb_MoTa.Text = lsv_CongViec.SelectedItems[0].Tag == null ? "" : lsv_CongViec.SelectedItems[0].Tag.ToString();
        }


        private void switch_Btn(ToolStripButton btn_On = null)
        {
            if (!tsp_btn_luu.Enabled)
            {
                tsp_btn_sua.Enabled = tsp_btn_them.Enabled = tsp_btn_xoa.Enabled = false;
                tsp_btn_luu.Enabled = true;

            }
            else if (tsp_btn_luu.Enabled)
            {
                
                tsp_btn_sua.Enabled = tsp_btn_them.Enabled = tsp_btn_xoa.Enabled = true;
               
                tsp_btn_luu.Enabled = false;
            }
            if (btn_On != null)
            {
                btn_On.Enabled = true;
            }

        }

        private void Clear_tbx()
        {
            tbx_id_cv.Clear();
            tbx_TenCV.Clear();
            rTb_MoTa.Clear();
        }

        private void Switch_tbx()
        {
            if (!tbx_id_cv.ReadOnly)
            {
                tbx_id_cv.ReadOnly = tbx_TenCV.ReadOnly = rTb_MoTa.ReadOnly = true;
            }
            else
            {
                tbx_id_cv.ReadOnly = tbx_TenCV.ReadOnly = rTb_MoTa.ReadOnly = false;
            }
        }

        private bool check_Tbx()
        {
            return tbx_id_cv.Text == "" || tbx_TenCV.Text == "" ? false : true;
        }

        

        private void tsp_btn_them_Click(object sender, EventArgs e)
        {
            if (tsp_btn_them.Text == "Thêm")
            {
                switch_Btn(tsp_btn_them);
                Switch_tbx();
                Clear_tbx();
                tsp_btn_them.Image = Presentation.Properties.Resources.icons8_cancel_64;
                tsp_btn_them.Text = "Hủy";

                tbx_id_cv.Text = cls_job_bus1.genaration_id_new_jobtitle_BUS();

             

            }
            else if ( tsp_btn_them.Text == "Hủy")
            {
                switch_Btn(tsp_btn_them);
                Switch_tbx();
                Clear_tbx();
                tsp_btn_them.Image = Presentation.Properties.Resources.add;
                tsp_btn_them.Text = "Thêm";
            }
        }

        private void tsp_btn_sua_Click(object sender, EventArgs e)
        {
            if ( tsp_btn_sua.Text == "Sửa")
            {
                if (lsv_CongViec.SelectedItems.Count > 0)
                {
                    if (cls_job_bus1.Check_Jobtitle_Allow_Modifile_BUS(lsv_CongViec.SelectedItems[0].SubItems[1].Text) == true)
                    {
                 
                        switch_Btn(tsp_btn_sua);
                        Switch_tbx();
                        tsp_btn_sua.Text = "Hủy";
                        tsp_btn_sua.Image = Presentation.Properties.Resources.icons8_cancel_64;
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được phép sửa công việc này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
            else if (tsp_btn_sua.Text=="Hủy")
            {
                
                switch_Btn(tsp_btn_sua);
                Switch_tbx();
                tsp_btn_sua.Text = "Sửa";
                tsp_btn_sua.Image = Presentation.Properties.Resources.edit;

            }
        }

        private void tsp_btn_xoa_Click(object sender, EventArgs e)
        {
            if (lsv_CongViec.SelectedItems.Count <= 0)
            {

                return;
            }
            if (cls_job_bus1.Check_Jobtitle_Allow_Modifile_BUS(lsv_CongViec.SelectedItems[0].SubItems[1].Text) == false)
            {
                MessageBox.Show("Bạn không được phép sửa công việc này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thật sự muốn xóa công việc?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (!cls_job_bus1.Delete_job_BUS(tbx_id_cv.Text))
                {
                    MessageBox.Show("xóa công việc không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                current_datasource = cls_job_bus1.Get_All_jobTitle_BUS();
                load_Data_To_lvs(current_datasource);
                Clear_tbx();
                tbx_id_cv.ReadOnly = true;
            }
        }

        private void tsp_btn_luu_Click(object sender, EventArgs e)
        {

            if (!check_Tbx())
            {
                return;
            }
            if (tsp_btn_them.Enabled)
            {
                if (cls_job_bus1.them_job_BUS(new Cls_JobTitle(tbx_id_cv.Text, tbx_TenCV.Text, rTb_MoTa.Text)))
                {
                   
                    switch_Btn(tsp_btn_them);
                    Switch_tbx();
                    Clear_tbx();
                    tsp_btn_them.Text = "Thêm";
                    tsp_btn_them.Image = Presentation.Properties.Resources.add;
                    current_datasource = cls_job_bus1.Get_All_jobTitle_BUS();
                    load_Data_To_lvs(current_datasource);

                }
                else
                {
                    MessageBox.Show("thêm công việc thất bại!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tsp_btn_sua.Enabled)
            {

                if (cls_job_bus1.sua_job_BUS(new Cls_JobTitle(tbx_id_cv.Text, tbx_TenCV.Text, rTb_MoTa.Text)))
                {
                   
                    switch_Btn(tsp_btn_sua);
                    Switch_tbx();
                    Clear_tbx();
                    tsp_btn_sua.Text = "Sửa";
                    tsp_btn_sua.Image = Presentation.Properties.Resources.edit;

                    current_datasource = cls_job_bus1.Get_All_jobTitle_BUS();
                    load_Data_To_lvs(current_datasource);

                }
                else
                {
                    MessageBox.Show("sửa công việc thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_CongViec.View = View.SmallIcon;
            lsv_CongViec.LargeImageList = large_image;
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_CongViec.View = View.Tile;
            lsv_CongViec.LargeImageList = large_image;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_CongViec.View = View.Details;
            lsv_CongViec.SmallImageList = small_iamge;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_CongViec.View = View.LargeIcon;
            lsv_CongViec.LargeImageList = large_image;
        }

        private void chiTiêtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_CongViec.View = View.List;
            lsv_CongViec.LargeImageList = large_image;
        }

        private void mãCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_content_search.Text = "Mã công việc";
            toolStripTextBox_content_search.ForeColor = Color.Red;
            toolStripTextBox_content_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            toolStripTextBox_content_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
            for (int i = 0; i < cls_job_bus1.Get_All_jobTitle_BUS().Count; i++)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Add(cls_job_bus1.Get_All_jobTitle_BUS()[i].Id_job);
            }
        }

        private void tênCôngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_content_search.Text = "Nhập vào tên công việc";
            toolStripTextBox_content_search.ForeColor = Color.Red;
            toolStripTextBox_content_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            toolStripTextBox_content_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
            for (int i = 0; i < cls_job_bus1.Get_All_jobTitle_BUS().Count; i++)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Add(cls_job_bus1.Get_All_jobTitle_BUS()[i].Name_job);
            }
        }

        private void toolStripTextBox_content_search_Click(object sender, EventArgs e)
        {

            toolStripTextBox_content_search.Text = "";
            toolStripTextBox_content_search.ForeColor = Color.Black;

        }

        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            List<Cls_JobTitle> l_job = new List<Cls_JobTitle>();
            l_job = cls_job_bus1.Search_jobtitle_BUS(toolStripTextBox_content_search.Text);

            load_Data_To_lvs(l_job);
            //string s = toolStripTextBox_content_search.Text;
            //if (cls_job_bus1.Search_jobtitle_BUS(s) == null || cls_job_bus1.Search_jobtitle_BUS(s).Count < 0)
            //{
            //    MessageBox.Show("Không tìm thấy kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;

            //}
            //else
            //if (cls_job_bus1.Search_jobtitle_BUS(s).Count > 0)
            //{
               
            //}

        }

       
    }
}
