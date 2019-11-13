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
    public partial class Frm_PhongBan : Form
    {
        public Frm_PhongBan()
        {
            InitializeComponent();
        }
        List<Cls_Department> list_department = new List<Cls_Department>();
        List<Cls_Staff> list_staff = new List<Cls_Staff>();
        Cls_Department_BUS cls_department_BUS1 = new Cls_Department_BUS();
        Cls_Staffs_BUS cls_staff_BUS1 = new Cls_Staffs_BUS();
        public void btn_Cancel_ThemPhongBan_Click(object sender, EventArgs e)
        {

        }

        private void Frm_PhongBan_Load(object sender, EventArgs e)
        {
            list_department = cls_department_BUS1.Get_list_department_BUS();
            load_to_gridview(list_department, grv_department,bindingNavigator_department);

            format_grid_view_department(grv_department);

            grb_thong_tin_phong_ban_moi.Enabled = false;
            txt_Id_department.ReadOnly = true;
            toolStripButton_luu_thong_tin_phong_ban.Enabled = false;

            


        }
        public void load_to_gridview(List<Cls_Department> list_department, DataGridView datagridview, BindingNavigator binding_navigator)
        {

            BindingSource bd = new BindingSource();
            bd.DataSource = list_department;
            datagridview.DataSource = bd;
            binding_navigator.BindingSource = bd;
        }
        public void load_to_gridview_staff(List<Cls_Staff> list_department, DataGridView datagridview, BindingNavigator binding_navigator)
        {

            BindingSource bd = new BindingSource();
            bd.DataSource = list_department;
            datagridview.DataSource = bd;
            binding_navigator.BindingSource = bd;
        }

        private void grv_department_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = this.grv_department.Rows[e.RowIndex].Cells[0].Value.ToString();
                string name = this.grv_department.Rows[e.RowIndex].Cells[1].Value.ToString();
                list_staff = cls_staff_BUS1.Get_list_staff_by_Id_department_BUS(id);
                load_to_gridview_staff(list_staff,grv_Staff_of_department, bindingNavigator_staff_of_department);
                format_grid_view_staff(grv_Staff_of_department);
                Load_to_textbox(txt_Id_department,txt_name_department,id,name);
            }

        }

        public void format_grid_view_staff(DataGridView a)
        {
           
            a.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            a.AllowUserToAddRows = false;
            a.MultiSelect = true;
            a.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            a.ScrollBars = ScrollBars.Both;
            a.Columns["id_staff"].ReadOnly = true;
            a.Columns["Name"].ReadOnly = true;
            a.Columns["Phone"].ReadOnly = true;
            a.Columns["Mail"].ReadOnly = true;
            a.Columns["Address"].ReadOnly = true;
            a.Columns["id_staff"].HeaderText = "Mã số nhân viên";
            a.Columns["Name"].HeaderText = "Họ tên nhân viên";
            a.Columns["Phone"].HeaderText = "Số điện thoại";
            a.Columns["Mail"].HeaderText = "Email";
            a.Columns["Address"].HeaderText = "Địa chỉ ";
            a.Columns["Status_staff"].HeaderText = "Tình trạng làm việc";
            a.Columns["Gender"].HeaderText = "Giới tính";
            a.Columns["Birtday"].HeaderText = "Ngày sinh";

            for (int i = 0; i < a.Columns.Count; i++)
            {
                a.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            a.Columns["mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.Columns["address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.AllowUserToResizeColumns = false;

         
        }
        public void format_grid_view_department(DataGridView a)
        {
            a.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            a.AllowUserToAddRows = false;
            a.MultiSelect = true;
            a.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            a.ScrollBars = ScrollBars.Both;
            a.Columns["Id_dp"].ReadOnly = true;
            a.Columns["Name_dp"].ReadOnly = true;
            a.Columns["Id_dp"].HeaderText = "Mã số phong ban";
            a.Columns["Name_dp"].HeaderText = "Họ tên nhân viên";
            for (int i = 0; i < a.Columns.Count; i++)
            {
                a.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            } 
            a.AllowUserToResizeColumns = false;
        }

        private void mãSốPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search.Text = mãSốPhòngBanToolStripMenuItem.Text;
            //List<Cls_Department> list_department_auto = new List<Cls_Department>();
            //list_department_auto = cls_department_BUS1.Get_list_department_BUS();
            list_department = cls_department_BUS1.Get_list_department_BUS();
            AutoComplet(list_department, toolStripTextBox_content_search, toolStripComboBox_option_search);
        }

        private void tênPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search.Text = tênPhòngBanToolStripMenuItem.Text;
            //List<Cls_Department> list_department_auto = new List<Cls_Department>();
            //list_department_auto = cls_department_BUS1.Get_list_department_BUS();
            list_department = cls_department_BUS1.Get_list_department_BUS();
            AutoComplet(list_department, toolStripTextBox_content_search,toolStripComboBox_option_search);
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
            else if(option_search.Text.Equals("Tên phòng ban") == true)
            {

                foreach (Cls_Department a in list_department_auto)
                {
                    toolStripTextBox_content_search.AutoCompleteCustomSource.Add(a.Name_dp);
                }
            }
          
           
        }
        List<Cls_Department> list_result = new List<Cls_Department>();
        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            string option_search = toolStripComboBox_option_search.Text;
            string content_search = toolStripTextBox_content_search.Text;

            bool check = cls_department_BUS1.Check_before_search(option_search, content_search);
            if (check == true)
            {
                list_result = cls_department_BUS1.Search_department_BUS(content_search);
                bool check1 = cls_department_BUS1.Check_affter_search(list_result);
                if (check1 == true)
                {
                    load_to_gridview(list_result,grv_department,bindingNavigator_department);
                    grv_Staff_of_department.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bất kì kết quả nào phù hợp");
                }
            }
            else
            {
                MessageBox.Show("Đảm bảo tiêu chí tìm kiếm và nội dùng tìm kiếm không rỗng");
            }


        }

       

        private void toolStripButton_Them_moi_phong_ban_Click(object sender, EventArgs e)
        {
            // lúc bấm thêm
            if (toolStripButton_luu_thong_tin_phong_ban.Enabled==false)
            {
                toolStripButton_cap_nhat_thong_tin_pb.Enabled = false;
                toolStripButton_luu_thong_tin_phong_ban.Enabled = true;
                toolStripButton_delete_Phong_Ban.Enabled = false;
                grb_thong_tin_phong_ban_moi.Enabled = true;
                toolStripButton_Them_moi_phong_ban.Text = "Hủy thêm";
                //toolStripButton_Them_moi_phong_ban.Image = Bitmap.FromFile(@"D:\A_HK1N3\Phat_Trien_Ung_Dung\HumanResource_DA\HumanResource\Presentation\Images\icons8-cancel-64.png");
                toolStripButton_Them_moi_phong_ban.Image = Presentation.Properties.Resources.icons8_cancel_64;
                txt_Id_department.ReadOnly = true;
                txt_Id_department.Text = cls_department_BUS1.id_department_generation_BUS();
                // txt_Id_department.Text = "0000000005";
            }
            // đây là lúc bấm hủy thêm
            else if(toolStripButton_luu_thong_tin_phong_ban.Enabled == true)
            {
                toolStripButton_cap_nhat_thong_tin_pb.Enabled = true;
                toolStripButton_luu_thong_tin_phong_ban.Enabled = false;
                toolStripButton_delete_Phong_Ban.Enabled = true;
                grb_thong_tin_phong_ban_moi.Enabled = false;

                toolStripButton_Them_moi_phong_ban.Text = "Thêm";
                toolStripButton_Them_moi_phong_ban.Image = Presentation.Properties.Resources.icons8_add_property_64;
                txt_Id_department.Text = "";
                txt_name_department.Text = "";
                toolStripButton_cap_nhat_thong_tin_pb.Enabled = true;
                toolStripButton_luu_thong_tin_phong_ban.Enabled = false;
                toolStripButton_delete_Phong_Ban.Enabled = true;
                grb_thong_tin_phong_ban_moi.Enabled = false;
            }

        }
        
        private void toolStripButton_luu_thong_tin_phong_ban_Click(object sender, EventArgs e)
        {
            if (toolStripButton_cap_nhat_thong_tin_pb.Enabled==false)
            {
                //lưu thêm
                string id = txt_Id_department.Text;
                string name_dp = txt_name_department.Text;

                if (name_dp.Trim().Equals("")!=true)
                {
                    List<Cls_Department> l_dp = new List<Cls_Department>();
                    l_dp = cls_department_BUS1.Get_list_department_BUS();
                    bool check_exist_id = cls_department_BUS1.Check_exist_id_BUS(l_dp, id);
                    bool check_exists_name = cls_department_BUS1.Check_exitst_name_BUS(l_dp, name_dp);

                    if (check_exist_id == true && check_exists_name == true)
                    {
                        Cls_Department dp = new Cls_Department();
                        dp.Id_dp = txt_Id_department.Text;
                        dp.Name_dp = txt_name_department.Text;
                        bool check = cls_department_BUS1.InsertOnSubmitChange_department_BUS(dp);
                        if (check == true)
                        {
                           
                            list_department = cls_department_BUS1.Get_list_department_BUS();
                            this.load_to_gridview(list_department, grv_department, bindingNavigator_department);
                           
                            txt_Id_department.Text = cls_department_BUS1.id_department_generation_BUS();
                            txt_name_department.Text = "";
                           
                            if (toolStripComboBox_option_search.Text.Equals("") != true)
                            {
                                //List<Cls_Department> list_department_auto = new List<Cls_Department>();
                                //list_department_auto = cls_department_BUS1.Get_list_department_BUS();
                                list_department = cls_department_BUS1.Get_list_department_BUS();
                                AutoComplet(list_department, toolStripTextBox_content_search, toolStripComboBox_option_search);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lưu Không Thành công");
                        }
                    }
                    else if (check_exist_id == false && check_exists_name == true)
                    {
                        MessageBox.Show("Tồn tại mã số phòng ban");
                    }
                    else if (check_exist_id == true && check_exists_name == false)
                    {
                        MessageBox.Show("tồn tại mã nhân viên");
                    }
                }
                else
                {
                    MessageBox.Show("bạn không để trống tên phong ban");
                }
                    

            }
            else
            {
                // lưu cập nhật
                string id = txt_Id_department.Text;
                string name_dp= txt_name_department.Text;

                if (name_dp.Trim().Equals("") == false && id.Trim().Equals("")==false)
                {
                    List<Cls_Department> l_dp = new List<Cls_Department>();
                    l_dp = cls_department_BUS1.Get_list_department_BUS();
                    bool check_exist_id = cls_department_BUS1.Check_exist_id_BUS(l_dp, id);
                    //bool check_exists_name = cls_department_BUS1.Check_exitst_name_BUS(l_dp, name_dp);
                    if(check_exist_id==false )
                    {
                        Cls_Department dpm_up = new Cls_Department();
                        dpm_up.Id_dp = id;
                        dpm_up.Name_dp = name_dp;
                        bool check = cls_department_BUS1.Update_information_department_BUS(dpm_up);
                        if (check == true)
                        {
                            list_department = cls_department_BUS1.Get_list_department_BUS();
                            this.load_to_gridview(list_department, grv_department, bindingNavigator_department);

                            txt_Id_department.Text = "";
                            txt_name_department.Text = "";

                            if (toolStripComboBox_option_search.Text.Equals("") != true)
                            {
                                //List<Cls_Department> list_department_auto = new List<Cls_Department>();
                                //list_department_auto = cls_department_BUS1.Get_list_department_BUS();
                                list_department = cls_department_BUS1.Get_list_department_BUS();
                                AutoComplet(list_department, toolStripTextBox_content_search, toolStripComboBox_option_search);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thanh công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã số phòng ban không khớp");
                    }

                }
                else
                {
                    MessageBox.Show("mời bạn chọn thông tin cần update");
                }
                
                
            }
        }
       
        private void toolStripButton_delete_Phong_Ban_Click(object sender, EventArgs e)
        {
            
            if (this.grv_department.SelectedRows.Count > 0 && txt_Id_department.Text.Trim().Equals("")==false)
            {
                toolStripButton_cap_nhat_thong_tin_pb.Enabled = false;
                toolStripButton_Them_moi_phong_ban.Enabled = false;
                string id_dpm_del = txt_Id_department.Text;
                bool check_empty_dp = cls_department_BUS1.Check_empty_department_BUS(id_dpm_del);
                if (check_empty_dp == true)
                {
                    Cls_Department dpm_del = new Cls_Department();
                    dpm_del.Id_dp = txt_Id_department.Text;
                    dpm_del.Name_dp = id_dpm_del;
                    bool check = cls_department_BUS1.Delete_department_BUS(dpm_del);
                    if (check == true)
                    {
                        list_department = cls_department_BUS1.Get_list_department_BUS();
                        this.load_to_gridview(list_department, grv_department, bindingNavigator_department);

                        txt_Id_department.Text = cls_department_BUS1.id_department_generation_BUS();
                        txt_name_department.Text = "";
                        txt_Id_department.Text = "";

                        if (toolStripComboBox_option_search.Text.Equals("") != true)
                        {
                           
                            AutoComplet(list_department, toolStripTextBox_content_search, toolStripComboBox_option_search);
                        }
                    }
                    else
                    {
                        MessageBox.Show("xóa không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("không thể xóa","Phòng ban này đang hoạt động");
                }
                
            }
            else
            {
                MessageBox.Show("bạn chưa chọn đối tượng muốn xóa");
            }
           
        }

        private void toolStripButton_cap_nhat_thong_tin_pb_Click(object sender, EventArgs e)
        {
            
            if (toolStripButton_Them_moi_phong_ban.Enabled == false)
            {
                toolStripButton_Them_moi_phong_ban.Enabled = true;
                toolStripButton_cap_nhat_thong_tin_pb.Text = "Cập nhật";
                //toolStripButton_cap_nhat_thong_tin_pb.Image =Bitmap.FromResource(Presentation.Properties.Resources.icons8_cancel_64,"icons8_cancel_64");
                toolStripButton_cap_nhat_thong_tin_pb.Image = Presentation.Properties.Resources.icons8_car_service_96;
                toolStripButton_delete_Phong_Ban.Enabled = true;
                grb_thong_tin_phong_ban_moi.Enabled = false;
                txt_name_department.Text = "";
                txt_Id_department.Text = "";
            }
            else
            {
                if (txt_name_department.Text.Equals("") == true)
                {
                    MessageBox.Show("mời bạn chọn và nội dung muốn cập nhật thông tin");
                }
                else
                {
                    toolStripButton_Them_moi_phong_ban.Enabled = false;
                    toolStripButton_cap_nhat_thong_tin_pb.Text = "Hủy cập nhật";
                    //toolStripButton_cap_nhat_thong_tin_pb.Image =Bitmap.FromResource(Presentation.Properties.Resources.icons8_cancel_64,"icons8_cancel_64");
                    toolStripButton_cap_nhat_thong_tin_pb.Image = Presentation.Properties.Resources.icons8_cancel_64;
                    toolStripButton_delete_Phong_Ban.Enabled = false;
                    toolStripButton_luu_thong_tin_phong_ban.Enabled = true;
                    grb_thong_tin_phong_ban_moi.Enabled = true;
                }
            }
          
        }
        public void Load_to_textbox(TextBox txt_id, TextBox txt_name,string text_id, string text_name)
        {
            txt_id.Text = text_id;
            txt_name.Text = text_name;
        }
    }
}
