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
    public partial class Frm_ThongTinPhongBan : Form
    {
        string id_curent = "";
        Cls_Department_BUS cls_dpm_bus1 = new Cls_Department_BUS();
        Cls_Staffs_BUS cls_stff_bus1 = new Cls_Staffs_BUS();
        Cls_JobTitle_BUS cls_job_titlte1 = new Cls_JobTitle_BUS();
        Cls_Shiffs_BUS cls_shiff_bus = new Cls_Shiffs_BUS();
        Cls_Evaluate_BUS cls_eveluate_bus1 = new Cls_Evaluate_BUS();
        List<Cls_Department> l_dp = new List<Cls_Department>();
        List<Cls_Staff> l_st = new List<Cls_Staff>();
        List<Cls_JobTitle> l_jb = new List<Cls_JobTitle>();
        List<Cls_Staff> list_staff_after = new List<Cls_Staff>();
        Cls_Account innit_account = new Cls_Account();
        public Frm_ThongTinPhongBan()
        {
            InitializeComponent();


        }
        Cls_Account acc_current = new Cls_Account();
        public Frm_ThongTinPhongBan(Cls_Account cls_acc)
        {
            InitializeComponent();
            id_curent = cls_acc.Id_acc;
            innit_account = cls_acc;
            LoadFilterToCombox();
            acc_current = cls_acc;


        }

        private void Frm_ThongTinPhongBan_Load(object sender, EventArgs e)
        {
            if (acc_current.Role_name.Trim().Equals("hrstaff"))
            {
                lbl_title.Text = "Nhân viên";
            }
            else
            {
                lbl_title.Text = "Phòng ban";
            }
            tvw_department.ImageList = imageList_tree;

            l_dp = cls_dpm_bus1.Get_list_department_BUS();
            Load_to_tree_view(tvw_department, l_dp);

            toolStripTextBox_content_search.Text = "Tìm kiếm phòng ban";
            toolStripTextBox_content_search.ForeColor = Color.DeepSkyBlue;
            toolStripTextBox_content_search_nv.Text = "Tìm kiếm nhân viên";
            toolStripTextBox_content_search_nv.ForeColor = Color.DeepSkyBlue;
            bool b = false;
            txb_soluongnv.Enabled = b;
            txb_namepb.Enabled = b;
            txb_mspb.Enabled = b;

            innit_listview_danhgia(lsv_danhgia);

            if (innit_account.Role_name.Trim().ToLower().Equals("hrstaff") == true)
            {
                toolStripButton_themnhanvien.Visible = true;
                toolStripButton_suanhanvien.Visible = true;
            }
            else if (innit_account.Role_name.Trim().ToLower().Equals("manager") == true)
            {
                toolStripButton_themnhanvien.Visible = false;
                toolStripButton_suanhanvien.Visible = false;
            }

            //webBrowser1.Navigate(@"https://unsplash.com/?utm_source=academydesignbold&utm_medium=article&utm_campaign=10-trang-web-hinh-anh-mien-phi-chat-luong");

        }
        public void Load_to_tree_view(TreeView trev, List<Cls_Department> l_dp)
        {
            trev.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "Danh sách phòng ban";
            foreach (Cls_Department a in l_dp)
            {
                TreeNode child = new TreeNode();
                child.Text = a.Name_dp;
                child.Tag = a.Id_dp;
                root.Nodes.Add(child);
            }
            trev.Nodes.Add(root);
            innit_listview(lvl_staffList);

        }
        private void tvw_department_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvw_department.SelectedNode.ImageIndex = 0;
            tvw_department.SelectedNode.SelectedImageIndex = 1;
            if (tvw_department.SelectedNode.Level > 0)
            {
                l_st = cls_stff_bus1.Get_list_staff_by_Id_department_BUS(tvw_department.SelectedNode.Tag.ToString());
                lvl_staffList.Items.Clear();
                load_to_listview(lvl_staffList, l_st);
                lvl_staffList.SmallImageList = smallimage;
                for (int i = 0; i < lvl_staffList.Items.Count; i++)
                {
                    lvl_staffList.Items[i].ImageIndex = 0;
                }
                txb_mspb.Text = tvw_department.SelectedNode.Tag.ToString();
                txb_namepb.Text = tvw_department.SelectedNode.Text;
                txb_soluongnv.Text = lvl_staffList.Items.Count.ToString();
            }
            list_staff_after = GetStaffInListView(GetStaffID());

        }
        public void innit_listview(ListView lsv)
        {
            lsv.View = View.Details;
            lsv.GridLines = true;
            lsv.FullRowSelect = true;
            // lsv.CheckBoxes = true;
            string[] header = { "STT ", "Mã số ", "Họ và tên ", "Số điện thoại ", "Email ", "Giới tính ", "Ngày sinh ", "Địa chỉ ", "Đang làm việc " };
            lsv.Columns.Add(header[0], 50, HorizontalAlignment.Center);
            for (int i = 1; i < header.Count(); i++)
            {
                lsv.Columns.Add(header[i], 200, HorizontalAlignment.Center);
            }
            lvl_staffList.Columns[1].Tag = 1;
            lvl_staffList.Columns[2].Tag = 1;
        }
        public void load_to_listview(ListView lsv, List<Cls_Staff> l_st)
        {
            //CheckBox tinh_trang = new CheckBox();
            //tinh_trang.Checked = false;
            lsv.Items.Clear();
            int i = 1;
            foreach (Cls_Staff a in l_st)
            {
                ListViewItem item = new ListViewItem(new[] { i.ToString(), a.Id_staff, a.Name, a.Phone, a.Mail, a.Gender, a.Birtday.ToShortDateString(), a.Address, a.Status_staff.ToString() });
                i++;
                lsv.Items.Add(item);
            }

        }
        private void lvl_staffList_MouseClick(object sender, MouseEventArgs e)
        {

            //MessageBox.Show(lvl_staffList.FocusedItem.Index.ToString());
            load_to_textbox(lvl_staffList);
            List<Cls_Eveluate> l_eve = new List<Cls_Eveluate>();
            l_eve = cls_eveluate_bus1.list_eve_BUS(lvl_staffList.SelectedItems[0].SubItems[1].Text);
            load_to_listview_danhgia(lsv_danhgia, l_eve);


        }
        public void load_to_textbox(ListView lsv)
        {
            int index = 0;
            if (lsv.SelectedItems.Count > -1)
            {
                index = lsv.SelectedIndices[0];
                tbx_id.Text = lsv.SelectedItems[0].SubItems[1].Text;
                tbx_name.Text = lsv.SelectedItems[0].SubItems[2].Text;
                tbx_sdt.Text = lsv.SelectedItems[0].SubItems[3].Text;
                tbx_email.Text = lsv.SelectedItems[0].SubItems[4].Text;
                tbx_address.Text = lsv.SelectedItems[0].SubItems[7].Text;
                tbx_birthdate.Text = lsv.SelectedItems[0].SubItems[6].Text;
                tbx_gender.Text = lsv.SelectedItems[0].SubItems[5].Text;
                string id = lsv.SelectedItems[0].SubItems[1].Text;
                tbx_congviec.Text = cls_job_titlte1.Get_jobtitle_BUS(id).Name_job;
                tbx_calamviec.Text = cls_shiff_bus.Get_shiff_BUS(id).Shiff_time;

                ckb_danglamviec.Checked = true ? (lsv.SelectedItems[0].SubItems[6].Text == "True") : false;


            }
        }
        private void mãSốPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search.Text = mãSốPhòngBanToolStripMenuItem.Text;
            toolStripTextBox_content_search.Text = "Nhập mã số phòng ban";

            toolStripTextBox_content_search.ForeColor = Color.Red;
            string[] auto = Get_array_auto("phòng ban", toolStripComboBox_option_search.Text, tvw_department);
            auto_complet_search("phòng ban", toolStripComboBox_option_search.Text, auto);



        }
        private void tênPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search.Text = tênPhòngBanToolStripMenuItem.Text;
            toolStripTextBox_content_search.Text = "Nhập tên phòng ban";
            toolStripTextBox_content_search.ForeColor = Color.Red;
            string[] auto = Get_array_auto("phòng ban", toolStripComboBox_option_search.Text, tvw_department);
            auto_complet_search("phòng ban", toolStripComboBox_option_search.Text, auto);

        }
        private void toolStripTextBox_content_search_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripTextBox_content_search.Text = "";
            toolStripTextBox_content_search.ForeColor = Color.Black;
            List<Cls_Department> list_department_auto = cls_dpm_bus1.Get_list_department_BUS();
            AutoComplet(list_department_auto, toolStripTextBox_content_search, toolStripComboBox_option_search);



        }
        public void AutoComplet(List<Cls_Department> list_department_auto, ToolStripTextBox txt_search, ToolStripComboBox option_search)
        {

            txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;

            txt_search.AutoCompleteCustomSource.Clear();

            if (option_search.Text.Equals("Mã số phòng ban") == true)
            {
                foreach (Cls_Department a in list_department_auto)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Id_dp);
                }
            }
            else if (option_search.Text.Equals("Tên phòng ban") == true)
            {

                foreach (Cls_Department a in list_department_auto)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Name_dp);
                }
            }


        }
        private void toolStripButton_xem_toan_bo_phong_ban_Click(object sender, EventArgs e)
        {
            List<Cls_Department> result = cls_dpm_bus1.Get_list_department_BUS();
            Load_to_tree_view(tvw_department, result);
            lvl_staffList.Items.Clear();
            clear_textbox("phòng ban");

        }
        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_content_search.ForeColor == Color.Black)
            {
                List<Cls_Department> result = cls_dpm_bus1.Search_department_BUS(toolStripTextBox_content_search.Text);

                if (result.Count > 0)
                {
                    Load_to_tree_view(tvw_department, result);
                    lvl_staffList.Items.Clear();
                    clear_textbox("phòng ban");
                }
                else
                {
                    MessageBox.Show("không tìm thấy kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else if (toolStripTextBox_content_search.ForeColor == Color.Red)
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("bạn chưa chọn tieu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
        private void toolStripButton_search_nv_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_content_search_nv.ForeColor == Color.Black)
            {


                if (lvl_staffList.Items.Count > 0)
                {
                    List<Cls_Staff> result = new List<Cls_Staff>();
                    result = cls_stff_bus1.Search_staff(tvw_department.SelectedNode.Tag.ToString(), toolStripTextBox_content_search_nv.Text, toolStripComboBox_option_search_nv.Text);
                    if (result.Count > 0)
                    {
                        lvl_staffList.Items.Clear();
                        load_to_listview(lvl_staffList, result);
                        clear_textbox("nhân viên");


                    }
                    else
                    {
                        MessageBox.Show("không tìm thấy kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("bạn chưa chọn phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (toolStripTextBox_content_search_nv.ForeColor == Color.Red)
            {
                MessageBox.Show("Mời bạn nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("bạn chưa lựa chọn tiêu chí tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripTextBox_content_search_nv_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripTextBox_content_search_nv.Text = "";
            toolStripTextBox_content_search_nv.ForeColor = Color.Black;

        }
        /// <summary>
        /// hàm gợi ý tìm kiếm 
        /// </summary>
        /// <param lst="listview hiện tại"></param>
        /// <param option_search="tiêu chí tìm kiếm"></param>
        ///  <param object1="đối tượng tìm kiếm"></param>
        /// <returns></returns>
        public string[] Get_array_auto(string object1, string option_search, object lst1)
        {



            int a = 10;
            string[] auto = new string[a];
            if (object1.Trim().Equals("nhân viên") == true)
            {
                ListView lst = (ListView)lst1;
                int count_item = lst.Items.Count;

                a = count_item;
                string[] array_item = new string[a];
                auto = array_item;
                if (option_search.Trim().ToLower().Equals("mã số nhân viên") == true)
                {
                    for (int i = 0; i < lst.Items.Count; i++)
                    {
                        auto[i] = lst.Items[i].SubItems[1].Text;

                    }
                }
                else if (option_search.Trim().ToLower().Equals("tên nhân viên") == true)
                {
                    for (int i = 0; i < lst.Items.Count; i++)
                    {
                        auto[i] = lst.Items[i].SubItems[2].Text;

                    }
                }
                else if (option_search.Trim().ToLower().Equals("địa chỉ") == true)
                {

                    for (int i = 0; i < lst.Items.Count; i++)
                    {
                        auto[i] = lst.Items[i].SubItems[7].Text;

                    }
                }
            }
            else if (object1.Trim().Equals("phòng ban") == true)
            {
                TreeView node = (TreeView)lst1;
                int count_ndoes = 0;
                if (lvl_staffList.Items.Count > 0)
                {
                    count_ndoes = node.SelectedNode.GetNodeCount(true);
                }
                else
                {
                    List<Cls_Department> ldp1 = new List<Cls_Department>();
                    ldp1 = cls_dpm_bus1.Get_list_department_BUS();
                    count_ndoes = ldp1.Count;
                }


                a = count_ndoes;
                string[] auto_node = new string[a];
                auto = auto_node;
                if (a > 0)
                {
                    if (option_search.Trim().ToLower().Equals("mã số phong ban") == true)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            auto[i] = node.Nodes[i].Tag.ToString();
                        }
                    }
                    else if (option_search.Trim().ToLower().Equals("tên phong ban") == true)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            auto[i] = node.Nodes[i].Text;
                        }
                    }
                }
            }

            return auto;
        }
        public void auto_complet_search(string object1, string option, string[] auto)
        {
            toolStripTextBox_content_search_nv.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripTextBox_content_search_nv.AutoCompleteMode = AutoCompleteMode.Suggest;
            toolStripTextBox_content_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolStripTextBox_content_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            if (object1.Trim().ToLower().Equals("nhân viên") == true)
            {
                toolStripTextBox_content_search_nv.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < auto.Count(); i++)
                {
                    toolStripTextBox_content_search_nv.AutoCompleteCustomSource.Add(auto[i]);
                }

            }
            else if (object1.Trim().ToLower().Equals("phòng ban") == true)
            {
                toolStripTextBox_content_search_nv.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < auto.Count(); i++)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(auto[i]);
                }
            }
        }

        private void địaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {

            toolStripComboBox_option_search_nv.Text = "Địa chỉ";
            string[] auto = new string[lvl_staffList.Items.Count];
            auto = Get_array_auto("nhân viên", toolStripComboBox_option_search_nv.Text, lvl_staffList);
            auto_complet_search("nhân viên", toolStripComboBox_option_search_nv.Text, auto);
            toolStripTextBox_content_search_nv.Text = "Nhập địa chỉ";
            toolStripTextBox_content_search_nv.ForeColor = Color.Red;

        }
        private void tênNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            toolStripComboBox_option_search_nv.Text = "Tên nhân viên";
            string[] auto = new string[lvl_staffList.Items.Count];
            auto = Get_array_auto("nhân viên", toolStripComboBox_option_search_nv.Text, lvl_staffList);
            auto_complet_search("nhân viên", toolStripComboBox_option_search_nv.Text, auto);
            toolStripTextBox_content_search_nv.Text = "Nhập vào tên nhân viên";
            toolStripTextBox_content_search_nv.ForeColor = Color.Red;
        }
        private void mãSốNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search_nv.Text = "Mã số nhân viên";
            toolStripTextBox_content_search_nv.Text = "Nhập Mã số nhân viên";
            toolStripTextBox_content_search_nv.ForeColor = Color.Red;



            string[] auto = new string[lvl_staffList.Items.Count];
            auto = Get_array_auto("nhân viên", toolStripComboBox_option_search_nv.Text, lvl_staffList);
            auto_complet_search("nhân viên", toolStripComboBox_option_search_nv.Text, auto);
        }
        private void toolStripButton_dsNhanVienThuocPhong_Click(object sender, EventArgs e)
        {
            if (lvl_staffList.Items.Count > 0)
            {
                List<Cls_Staff> result = new List<Cls_Staff>();
                result = cls_stff_bus1.Get_list_staff_by_Id_department_BUS(tvw_department.SelectedNode.Tag.ToString());
                if (result.Count > 0)
                {
                    lvl_staffList.Items.Clear();
                    load_to_listview(lvl_staffList, result);
                    clear_textbox("nhân viên");



                }
            }
            else
            {
                MessageBox.Show("mời bạn chọn phòng ban muốn xem thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clear_textbox(string type_textbox)
        {
            if (type_textbox.Trim().Equals("nhân viên") == true)
            {
                tbx_address.Text = "";
                tbx_birthdate.Text = "";
                tbx_calamviec.Text = "";
                tbx_congviec.Text = "";
                tbx_email.Text = "";
                tbx_gender.Text = "";
                tbx_id.Text = "";
                tbx_name.Text = "";
                tbx_sdt.Text = "";
                ckb_danglamviec.Checked = false;

            }
            else if (type_textbox.Trim().Equals("phòng ban") == true)
            {
                tbx_address.Text = "";
                tbx_birthdate.Text = "";
                tbx_calamviec.Text = "";
                tbx_congviec.Text = "";
                tbx_email.Text = "";
                tbx_gender.Text = "";
                tbx_id.Text = "";
                tbx_name.Text = "";
                tbx_sdt.Text = "";
                txb_mspb.Text = "";
                txb_namepb.Text = "";
                txb_soluongnv.Text = "";
                ckb_danglamviec.Checked = false;
            }
        }
        #region phần laod dũ liệu lên cho textbox
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
        #endregion
        private void toolStripButton_themnhanvien_Click(object sender, EventArgs e)
        {
            Frm_ThemNhanVien frm_themNV = new Frm_ThemNhanVien();
            frm_themNV.ShowDialog();


        }
        private void toolStripButton_suanhanvien_Click(object sender, EventArgs e)
        {
            if (lvl_staffList.SelectedItems.Count > 0)
            {
                string id_contract_current = lvl_staffList.SelectedItems[0].SubItems[1].Text;

                Frm_ThemNhanVien frm_edit_nhanvien = new Frm_ThemNhanVien(id_contract_current, id_contract_current);
                frm_edit_nhanvien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời bạn chọn đối tượng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region phần lọc
        /// <summary>
        /// Hàm sắp xếp
        /// </summary>
        private void SoftGridView(int indexcolumn)
        {
            List<Cls_Staff> list = new List<Cls_Staff>();
            if (indexcolumn == 1)
            {
                if (lvl_staffList.Columns[indexcolumn].Tag.ToString().Equals("0"))
                {
                    list = GetStaffInListView(GetStaffID()).OrderBy(x => x.Id_staff).ToList();
                    lvl_staffList.Columns[indexcolumn].Tag = 1;
                }

                else
                {
                    list = GetStaffInListView(GetStaffID()).OrderByDescending(x => x.Id_staff).ToList();
                    lvl_staffList.Columns[indexcolumn].Tag = 0;
                }

            }
            else if (indexcolumn == 2)
            {
                if (lvl_staffList.Columns[indexcolumn].Tag.ToString().Equals("0"))
                {
                    lvl_staffList.Columns[indexcolumn].Tag = 1;
                    list = GetStaffInListView(GetStaffID()).OrderBy(x => x.Name).ToList();
                }

                else
                {
                    list = GetStaffInListView(GetStaffID()).OrderByDescending(x => x.Name).ToList();
                    lvl_staffList.Columns[indexcolumn].Tag = 0;
                }

            }
            if (list != null)
            {
                load_to_listview(lvl_staffList, list);
                lvl_staffList.SmallImageList = smallimage;
                for (int i = 0; i < lvl_staffList.Items.Count; i++)
                {
                    lvl_staffList.Items[i].ImageIndex = 0;
                }
                list_staff_after = list;
            }

        }
        /// <summary>
        /// Lấy list staff in list view
        /// </summary>
        /// <param name="listid"></param>
        /// <returns></returns>
        private List<Cls_Staff> GetStaffInListView(List<String> listid)
        {
            List<Cls_Staff> list = new List<Cls_Staff>();
            foreach (var item in listid)
            {
                list.Add(new Cls_Staffs_BUS().Get_staff_BUS(item));
            }
            return list;
        }
        /// <summary>
        /// Lấy mã nhân viên trên list view
        /// </summary>
        private List<String> GetStaffID()
        {
            List<String> list = new List<string>();
            for (int i = 0; i < lvl_staffList.Items.Count; i++)
            {
                list.Add(lvl_staffList.Items[i].SubItems[1].Text.ToString());
            }
            return list;
        }
        /// <summary>
        /// Load các tiêu chí vào combobox
        /// </summary>
        private void LoadFilterToCombox()
        {
            List<String> listgt = new List<string>();
            List<String> listtt = new List<string>();
            listgt.Add("Giới tính");
            listgt.Add("Nam");
            listgt.Add("Nữ");
            toolStripComboBox_GioiTinhFilter.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_GioiTinhFilter.ComboBox.DataSource = listgt;

            listtt.Add("Tình trạng làm việc");
            listtt.Add("Đang làm việc");
            listtt.Add("Nghỉ việc");
            toolStripComboBox_TinhTrangLVFilter.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_TinhTrangLVFilter.ComboBox.DataSource = listtt;
        }
        /// <summary>
        /// Sự kiện click column listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvl_staffList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SoftGridView(e.Column);

        }

        /// <summary>
        /// Sự kiện index change giới tính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }
        /// <summary>
        /// Hàm kiểm tra thông tin combobox gồm giới tính và tình trạng
        /// </summary>
        private void Filter()
        {
            List<Cls_Staff> list = list_staff_after;
            if (toolStripComboBox_TinhTrangLVFilter.ComboBox.SelectedIndex != 0)
            {
                if (toolStripComboBox_TinhTrangLVFilter.ComboBox.SelectedIndex == 1)
                    list = list.Where(x => x.Status_staff == true).ToList();
                else
                    list = list.Where(x => x.Status_staff == false).ToList();
            }
            if (toolStripComboBox_GioiTinhFilter.ComboBox.SelectedIndex != 0)
            {
                //.ToLower()
                list = list.Where(x => x.Gender.Trim().Equals(toolStripComboBox_GioiTinhFilter.ComboBox.Text.ToString())).ToList();
            }
            if (list != null)
            {
                load_to_listview(lvl_staffList, list);
                lvl_staffList.SmallImageList = smallimage;
                for (int i = 0; i < lvl_staffList.Items.Count; i++)
                {
                    lvl_staffList.Items[i].ImageIndex = 0;
                }
                //list_staff_after = list;
            }
        }
        private void toolStripComboBox_TinhTrangLVFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();

        }
        #endregion
    }
}
