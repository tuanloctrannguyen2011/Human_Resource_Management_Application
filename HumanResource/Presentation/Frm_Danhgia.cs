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
    public partial class Frm_Danhgia : Form
    {
        Cls_Staffs_BUS cls_staff_bus1 = new Cls_Staffs_BUS();
        Cls_Evaluate_BUS cls_evaluate_bus1 = new Cls_Evaluate_BUS();
        List<Cls_Staff> list_staff = new List<Cls_Staff>();
        public Frm_Danhgia()
        {
            InitializeComponent();
        }
        Cls_Account account_curent = new Cls_Account();
        public Frm_Danhgia(Cls_Account init_account)
        {
            InitializeComponent();
            account_curent = init_account;
        }

        private void Frm_Danhgia_Load(object sender, EventArgs e)
        {
            toolStripTextBox_content_search.Text = "nhập vào nội dung cần tìm kiếm";
            toolStripTextBox_content_search.ForeColor = Color.DeepSkyBlue;
            // toolStripComboBox_optionseearch.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //  string[] array_option_search = new string[] { "Mã nhân viên", "Tên nhân viên", "Mã Phòng ban", "Tên Phòng ban", "Địa chỉ" };
            // toolStripComboBox_optionseearch.ComboBox.DataSource = array_option_search;
            innit_listview(lsv_staff);

            list_staff = cls_staff_bus1.Get_list_staff_BUS();
            Load_to_list_view(lsv_staff, list_staff);
            innit_listview_danhgia(lstviewdanhgia);

            tbx_staffID.ReadOnly = true;
            tbx_id_dg.ReadOnly = true;
            grb_danhgia.Enabled = false;
            dtp_date.Format = DateTimePickerFormat.Custom;
            dtp_date.CustomFormat = "-------------------";
            //auto_complet_search();
            load_to_optionsearch();


        }
        public void innit_listview(ListView lsv)
        {
            lsv.View = View.Details;
            lsv.GridLines = true;
            lsv.FullRowSelect = true;

            string[] header = { "STT ", "Mã số ", "Họ và tên ", "Số điện thoại ", "Email ", "Địa chỉ ", "Tình trạng" };
            lsv.Columns.Add(header[0], 50, HorizontalAlignment.Center);
            for (int i = 1; i < header.Count(); i++)
            {
                lsv.Columns.Add(header[i], 200, HorizontalAlignment.Center);
            }


        }

        public void Load_to_list_view(ListView lsv, List<Cls_Staff> list_staff)
        {
            lsv.Items.Clear();
            int i = 0;
            CheckBox cb = new CheckBox();
            foreach (Cls_Staff a in list_staff)
            {
                // cb.Checked = true ? a.Status_staff.ToString().Equals("True") : false;
                //string gender = "";
                ListViewItem item = new ListViewItem(new[] { i.ToString(), a.Id_staff, a.Name, a.Phone, a.Mail, a.Address, a.Status_staff.ToString() });
                i++;
                lsv.Items.Add(item);
            }

            lsv.SmallImageList = small_iamge;
            for (int j = 0; j < lsv.Items.Count; j++)
            {
                lsv.Items[j].ImageIndex = 0;
            }

        }

        private void lsv_staff_Click(object sender, EventArgs e)
        {
            List<Cls_Eveluate> l_eva = new List<Cls_Eveluate>();
            l_eva = cls_evaluate_bus1.list_eve_BUS(lsv_staff.SelectedItems[0].SubItems[1].Text);
            load_to_listview_danhgia(lstviewdanhgia, l_eva);
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_staff.View = View.SmallIcon;
            lsv_staff.SmallImageList = small_iamge;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_staff.View = View.Details;
            //lsv_staff.SmallImageList = small_iamge;
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_staff.View = View.Tile;
            //  lsv_staff.View = View.Tile;
        }

        private void chiTiêtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_staff.View = View.List;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lsv_staff.View = View.LargeIcon;
            lsv_staff.LargeImageList = large_image;
        }


        public void innit_listview_danhgia(ListView lsv)
        {
            lsv.View = View.Details;
            lsv.GridLines = true;
            lsv.FullRowSelect = true;
            string[] header = { "STT ", "Mã số ", "Loại ", "Nội dung", "Ngày đánh giá" };
            lsv.Columns.Add(header[0], 50, HorizontalAlignment.Center);
            lsv.Columns.Add(header[1], 80, HorizontalAlignment.Center);
            lsv.Columns.Add(header[2], 50, HorizontalAlignment.Center);
            lsv.Columns.Add(header[3], 500, HorizontalAlignment.Center);
            lsv.Columns.Add(header[4], 100, HorizontalAlignment.Center);



        }
        public void load_to_listview_danhgia(ListView lsv_eve, List<Cls_Eveluate> l_eve)
        {
            //CheckBox tinh_trang = new CheckBox();
            //tinh_trang.Checked = false;
            lsv_eve.Items.Clear();
            int i = 0;
            RichTextBox rtb = new RichTextBox();

            foreach (Cls_Eveluate a in l_eve)
            {
                ListViewItem item = new ListViewItem(new[] { i.ToString(), a.Id_eva, a.Eva_type, rtb.Text = a.Eva_desc, a.Eva_date.ToString() });
                i++;
                lsv_eve.Items.Add(item);
            }

        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            if (btn_danhgia.Text.Trim().ToLower().Equals("đánh giá") == true)
            {
                if (lsv_staff.SelectedItems.Count > 0)
                {
                    grb_danhgia.Enabled = true;
                    btn_luu_dg.Enabled = true;
                    btn_danhgia.Text = "Hủy đánh giá";


                    tbx_id_dg.Text = cls_evaluate_bus1.genaration_id_evaluate_BUS();
                    string[] array_type = new string[] { "Khen thưởng", "kỷ luật" };
                    cmb_type.DataSource = array_type;
                    tbx_staffID.Text = lsv_staff.SelectedItems[0].SubItems[1].Text;

                    dtp_date.Format = DateTimePickerFormat.Custom;
                    dtp_date.CustomFormat = "dd-MM-yyyy";
                    dtp_date.Value = DateTime.Now;

                    rtb_noidung_dg.Text = "nhập vào nội dụng đánh giá vào đây";
                    rtb_noidung_dg.ForeColor = Color.Red;

                }
                else
                {
                    MessageBox.Show("bạn chưa chọn nhân viên cần đánh giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (btn_danhgia.Text.Trim().ToLower().Equals("hủy đánh giá") == true)
            {
                tbx_id_dg.Text = "";
                tbx_staffID.Text = "";
                dtp_date.Format = DateTimePickerFormat.Custom;
                dtp_date.CustomFormat = "--------------------";
                cmb_type.DataSource = new string[1] { "" };
                rtb_noidung_dg.Text = "";
                btn_danhgia.Text = "Đánh giá";
                btn_luu_dg.Enabled = false;
                grb_danhgia.Enabled = false;

            }
        }


        private void btn_luu_dg_Click(object sender, EventArgs e)
        {
            if (rtb_noidung_dg.ForeColor != Color.Red)
            {
                if (tbx_id_dg.Text.Trim().Equals("") == false && tbx_staffID.Text.Trim().Equals("") == false && rtb_noidung_dg.Text.Trim().Equals("") == false)
                {
                    Cls_Eveluate new_eva = new Cls_Eveluate();
                    new_eva.Id_eva = tbx_id_dg.Text;
                    new_eva.Eva_type = cmb_type.Text;
                    new_eva.Eva_date = dtp_date.Value;
                    new_eva.Id_staff = tbx_staffID.Text;
                    new_eva.Eva_desc = rtb_noidung_dg.Text;



                    if (cls_evaluate_bus1.insert_evaluate_bus(new_eva) == true)
                    {
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tbx_id_dg.Text = "";
                        tbx_staffID.Text = "";
                        dtp_date.Format = DateTimePickerFormat.Custom;
                        dtp_date.CustomFormat = "--------------------";
                        cmb_type.DataSource = new string[1] { "" };
                        rtb_noidung_dg.Text = "";
                        btn_danhgia.Text = "Đánh giá";
                        btn_luu_dg.Enabled = false;
                        grb_danhgia.Enabled = false;
                        List<Cls_Eveluate> l_eva = new List<Cls_Eveluate>();
                        l_eva = cls_evaluate_bus1.list_eve_BUS(lsv_staff.SelectedItems[0].SubItems[1].Text);
                        load_to_listview_danhgia(lstviewdanhgia, l_eva);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    MessageBox.Show("Thất bại => Bạn chưa cung cấp đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Thất bại => Bạn chưa cung cấp đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void toolStripMenuItem_sort_PB_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_sort_gender_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_sort_A_Z_Click(object sender, EventArgs e)
        {
            List<Cls_Staff> list_staff = new List<Cls_Staff>();
            list_staff = cls_staff_bus1.Get_list_staff_BUS().OrderBy(x => x.Id_staff).ThenBy(x => x.Name).ToList<Cls_Staff>();
            Load_to_list_view(lsv_staff, list_staff);
        }

        private void toolStripMenuItem_sort_ID_Click(object sender, EventArgs e)
        {

           


            Load_to_list_view(lsv_staff, list_staff);
        }



        private void rtb_noidung_dg_DoubleClick(object sender, EventArgs e)
        {
            rtb_noidung_dg.Text = "";
            rtb_noidung_dg.ForeColor = Color.Black;
        }

        public void btn_exit_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            if (cmb_optionsearch.ComboBox.Text.Trim().Equals("lựa chọn") != true)
            {
                if (toolStripTextBox_content_search.Text.Trim().Equals("") != true)
                {
                    list_staff = cls_staff_bus1.result_staff_BUS(cmb_optionsearch.ComboBox.Text, toolStripTextBox_content_search.Text.Trim());
                    Load_to_list_view(lsv_staff,list_staff);
                }
                else
                {

                    MessageBox.Show("mời bạn chọn nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("mời bạn chọn vào tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        public void load_to_optionsearch()
        {
            string[] array_optionsearch = new string[] { "lựa chọn", "mã số nhân viên", "tên nhân viên", "địa chỉ email", "địa chỉ", "số điện thoại" };
            cmb_optionsearch.ComboBox.DataSource = array_optionsearch;




        }



        public void auto_complet_search(string s, List<Cls_Staff> l_st)
        {
            toolStripTextBox_content_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripTextBox_content_search.AutoCompleteMode = AutoCompleteMode.Suggest;

            //list_staff = cls_staff_bus1.Get_list_staff_BUS();
            // Load_to_list_view(lsv_staff, list_staff);
            if (s.Equals("mã số nhân viên") == true)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
                foreach (Cls_Staff a in list_staff)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Id_staff);
                }
            }
            if (s.Equals("tên nhân viên") == true)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
                foreach (Cls_Staff a in list_staff)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Name);
                }
            }
            else if (s.Equals("số điện thoại") == true)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
                foreach (Cls_Staff a in list_staff)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Phone);
                }
            }
            else if (s.Equals("địa chỉ email") == true)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
                foreach (Cls_Staff a in list_staff)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Mail);
                }
            }
            else if (s.Equals("địa chỉ") == true)
            {
                toolStripTextBox_content_search.AutoCompleteCustomSource.Clear();
                foreach (Cls_Staff a in list_staff)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Address);
                }
            }
        }

        private void cmb_optionsearch_Click(object sender, EventArgs e)
        {

        }

        private void cmb_optionsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_staff = cls_staff_bus1.Get_list_staff_BUS();
            string s = cmb_optionsearch.ComboBox.Text;
            auto_complet_search(s, list_staff);
        }

       




        //private void toolStripComboBox_optionseearch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MessageBox.Show(toolStripComboBox_optionseearch.ComboBox.SelectedItem.ToString());
        //}
    }
}
