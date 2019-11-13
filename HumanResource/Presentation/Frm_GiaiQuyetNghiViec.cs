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
    public partial class Frm_GiaiQuyetNghiViec : Form
    {
        string id_current;
        Cls_Staffs_BUS cls_staffs_BUS1 = new Cls_Staffs_BUS();
        Cls_Department_BUS cls_department_BUS1 = new Cls_Department_BUS();
        Cls_JobTitle_BUS cls_jobtitle_BUS1 = new Cls_JobTitle_BUS();
        Cls_Shiffs_BUS cls_shiffs_BUS1 = new Cls_Shiffs_BUS();
        Cls_Contract_BUS cls_contracts_BUS1 = new Cls_Contract_BUS();

        List<Cls_Staff> list_staff_active = new List<Cls_Staff>();
        List<Cls_Staff> list_staff_inactive = new List<Cls_Staff>();

        public Frm_GiaiQuyetNghiViec(Cls_Account acc_curent)
        {
            InitializeComponent();
            id_current = acc_curent.Id_acc;
        }
        public void format_grid_view(DataGridView a)
        {
            a.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           
            a.AllowUserToAddRows = false;
            a.MultiSelect = true;
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
  
            for (int i=0; i < a.Columns.Count; i++)
            {
                a.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            a.Columns["Mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            a.AllowUserToResizeColumns = true;
        }
        public void load_to_gridview(List<Cls_Staff>  list_staff, DataGridView datagridview,BindingNavigator binding_navigator)
        {
           
            BindingSource bd = new BindingSource();
            bd.DataSource = list_staff;
            datagridview.DataSource = bd;
            binding_navigator.BindingSource = bd;
        }
        private void Frm_GiaiQuyetNghiVieccs_Load(object sender, EventArgs e)
        {
            this.saveToolStripButton.Enabled = false;
            list_staff_active = cls_staffs_BUS1.Get_list_staffs_Active_BUS(id_current);
            list_staff_inactive = cls_staffs_BUS1.Get_list_staffs_Inactive_BUS(id_current);
            load_to_gridview(list_staff_active, grv_DSNV_danglamviec, bdnvgt_DSNV_danglamviec);
            load_to_gridview(list_staff_inactive, grv_DSNV_nghiviec, bdnvgt_DSNV_nghiviec);
            format_grid_view(grv_DSNV_danglamviec);
            format_grid_view(grv_DSNV_nghiviec);
            ReadOnly_TextBox(true);
            
            
           
        }

        // xét nhân viên nghỉ việc
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.grv_DSNV_danglamviec.EndEdit();
            DialogResult result = MessageBox.Show("Bạn thực sự muốn lưu thay đổi", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < grv_DSNV_danglamviec.Rows.Count; i++)
                    {
                        Cls_Staff a = cls_staffs_BUS1.Get_staff_BUS(this.grv_DSNV_danglamviec.Rows[i].Cells["id_staff"].Value.ToString());
                       // MessageBox.Show("trạng thái lúc chưa thay đổi là " + a.Status_staff.ToString());
                        bool status = (bool)this.grv_DSNV_danglamviec.Rows[i].Cells["Status_staff"].Value;
                        if (status == false)
                        {
                            a.Status_staff = false;
                            cls_staffs_BUS1.SubmitChange_DataGridview__active_BUS(a);
                            // cập nhật thời gian nghỉ việc vào bản hợp đồng 
                            
                            string id_ck1 = this.grv_DSNV_danglamviec.Rows[i].Cells["id_staff"].Value.ToString();
                            DateTime dt = DateTime.Today;
                            cls_contracts_BUS1.Submit_date_modifine_BUS(dt,id_ck1);


                        }

                    }
                    list_staff_active = cls_staffs_BUS1.Get_list_staffs_Active_BUS(id_current);
                    list_staff_inactive = cls_staffs_BUS1.Get_list_staffs_Inactive_BUS(id_current);
                    load_to_gridview(list_staff_active, grv_DSNV_danglamviec, bdnvgt_DSNV_danglamviec);
                    load_to_gridview(list_staff_inactive, grv_DSNV_nghiviec, bdnvgt_DSNV_nghiviec);
                    MessageBox.Show("cập nhật thành công");
                    saveToolStripButton.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "cập nhật không thành công");
                    
                }
            }

            Clear_textbox(txt_ms_nv_NV, txt_name_NV_nghiviec, txt_name_PB_NV_nghiviec, txt_name_Congviec_NV_nghiviec, txt_time_LV_NV_nghiviec, dtp_NgayBatDau_nv_NV, dtp_NgayNV, txt_dg_NV_nghiviec);

            Clear_textbox(txt_ms_nv_DLV, txt_name_NV_danglamviec, txt_name_pb_NV_danglamviec, txt_nameCongviec_NV_danglamviec, txt_time_LV_NV_danglamviec, dtp_NgaybatDau_NV_DLV, dtp_NgayNV, txt_dg_NV_danglamviec);
        }

        private void grv_DSNV_danglamviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                saveToolStripButton.Enabled = true;

                string id_Ck = this.grv_DSNV_danglamviec.Rows[e.RowIndex].Cells[0].Value.ToString();

                load_to_textbox(txt_ms_nv_DLV, txt_name_NV_danglamviec, txt_name_pb_NV_danglamviec, txt_nameCongviec_NV_danglamviec, txt_time_LV_NV_danglamviec, dtp_NgaybatDau_NV_DLV, dtp_NgayNV, txt_dg_NV_danglamviec, grv_DSNV_danglamviec, e.RowIndex, id_Ck);
               
                if (grv_DSNV_danglamviec.SelectedRows[0].Cells[4].Value.ToString().Equals("Nam") == true)
                {
                    ckb_gender_dlv.Checked = true;
                }
                else
                {
                    ckb_gender_dlv.Checked = false;
                }

            }
        }
        private void grv_DSNV_nghiviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                saveToolStripButton_NV_nghiviec.Enabled = true;

                string id_Ck = this.grv_DSNV_nghiviec.Rows[e.RowIndex].Cells[0].Value.ToString();

                load_to_textbox(txt_ms_nv_NV, txt_name_NV_nghiviec, txt_name_PB_NV_nghiviec, txt_name_Congviec_NV_nghiviec, txt_time_LV_NV_nghiviec, dtp_NgayBatDau_nv_NV, dtp_NgayNV, txt_dg_NV_nghiviec, grv_DSNV_nghiviec, e.RowIndex, id_Ck);
                if (grv_DSNV_danglamviec.SelectedRows[0].Cells[4].Value.ToString().Equals("Nam") == true)
                {
                    ckb_gender_dlv.Checked = true;
                }
                else
                {
                    ckb_gender_dlv.Checked = false;
                }
            }


            
        }


        public void load_to_textbox(TextBox id,TextBox name, TextBox pb, TextBox cv, TextBox tg,DateTimePicker dt_bd, DateTimePicker dt_kt,  TextBox dg, DataGridView datagridview ,int index,string id_ck)
        {
            
            id.Text = datagridview.Rows[index].Cells[0].Value.ToString();
            name.Text = datagridview.Rows[index].Cells[1].Value.ToString();
            pb.Text = cls_department_BUS1.Get_department_BUS(id_ck).Name_dp;
            cv.Text = cls_jobtitle_BUS1.Get_jobtitle_BUS(id_ck).Name_job;
            tg.Text = cls_shiffs_BUS1.Get_shiff_BUS(id_ck).Shiff_time;
            dt_bd.CustomFormat = "yyyy-MM-dd";
            dt_bd.Value = cls_contracts_BUS1.Get_contract_BUS(id_ck).Start_date;
            
            string dt_ck= cls_contracts_BUS1.Get_contract_BUS(id_ck).End_date.ToString();
          
            if (dt_ck.Length != 0)
            {
                dt_kt.CustomFormat = "yyyy-MM-dd";
                dt_kt.Value = (DateTime)cls_contracts_BUS1.Get_contract_BUS(id_ck).End_date;
            }
            else
            {
                dt_kt.Format = DateTimePickerFormat.Custom;
                dt_kt.CustomFormat =".......";
            }
            
        }
        public void Clear_textbox(TextBox id, TextBox name, TextBox pb, TextBox cv, TextBox tg, DateTimePicker dt_bd, DateTimePicker dt_kt, TextBox dg)
        {
            id.Text = "";
            name.Text = "";
            pb.Text = "";
            cv.Text = "";
            tg.Text = "";
            dt_bd.CustomFormat = ".........";
            dt_kt.CustomFormat = "..........";
            dg.Text = "";
        }

        private void saveToolStripButton_NV_nghiviec_Click(object sender, EventArgs e)
        {
            this.grv_DSNV_nghiviec.EndEdit();
                DialogResult result = MessageBox.Show("Bạn thực sự muốn lưu thay đổi", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {

                    try
                    {
                        for (int i = 0; i < grv_DSNV_nghiviec.Rows.Count; i++)
                        {
                            Cls_Staff a = cls_staffs_BUS1.Get_staff_BUS(this.grv_DSNV_nghiviec.Rows[i].Cells["id_staff"].Value.ToString());
                           // MessageBox.Show("trạng thái lúc chưa thay đổi là " + a.Status_staff.ToString());
                            bool status = (bool)this.grv_DSNV_nghiviec.Rows[i].Cells["Status_staff"].Value;
                            if (status == true)
                            {
                                a.Status_staff = true;
                                //MessageBox.Show("trạng thái lúc đã thay đổi là " + a.Status_staff.ToString());
                                cls_staffs_BUS1.SubmitChange_DataGridview__active_BUS(a);
                                //cập nhật ngày lại ngày nghỉ việc là null
                                string id_ck1 = this.grv_DSNV_nghiviec.Rows[i].Cells["id_staff"].Value.ToString();
                                DateTime? dt1 = null;
                                cls_contracts_BUS1.Submit_date_modifine_BUS(dt1, id_ck1);

                            } 
                        }
                        list_staff_active = cls_staffs_BUS1.Get_list_staffs_Active_BUS(id_current);
                        list_staff_inactive = cls_staffs_BUS1.Get_list_staffs_Inactive_BUS(id_current);
                        load_to_gridview(list_staff_active, grv_DSNV_danglamviec, bdnvgt_DSNV_danglamviec);
                        load_to_gridview(list_staff_inactive, grv_DSNV_nghiviec, bdnvgt_DSNV_nghiviec);
                        MessageBox.Show("cập nhật thành công");
                        saveToolStripButton.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "cập nhật không thành công");

                    }
                }
            Clear_textbox(txt_ms_nv_NV, txt_name_NV_nghiviec, txt_name_PB_NV_nghiviec, txt_name_Congviec_NV_nghiviec, txt_time_LV_NV_nghiviec, dtp_NgayBatDau_nv_NV, dtp_NgayNV, txt_dg_NV_nghiviec);

            Clear_textbox(txt_ms_nv_DLV, txt_name_NV_danglamviec, txt_name_pb_NV_danglamviec, txt_nameCongviec_NV_danglamviec, txt_time_LV_NV_danglamviec, dtp_NgaybatDau_NV_DLV, dtp_NgayNV, txt_dg_NV_danglamviec);
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime? a = null;
            DateTime? b=(DateTime)System.Data.SqlTypes.SqlDateTime.Null;
            b = null;
            

            
            MessageBox.Show(b.ToString());
        }

        private void tênPhòngBanToolStripMenuItem_nv_dlv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_select_option_search_DLV.Text = tênPhòngBanToolStripMenuItem_nv_dlv.Text;
            AutoComplet(txt_content_search_DLV, "Tên phòng ban", true);
        }
     

        private void mãSốPhòngBanToolStripMenuItem_nv_dlv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_select_option_search_DLV.Text = mãSốPhòngBanToolStripMenuItem_nv_dlv.Text;
            AutoComplet(txt_content_search_DLV, "Mã số phòng ban", true);
        }
       

        private void tênNhânViênToolStripMenuItem_nv_dlv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_select_option_search_DLV.Text = tênNhânViênToolStripMenuItem_nv_dlv.Text;
            AutoComplet(txt_content_search_DLV, "Tên nhân viên", true);
        }
      

        private void mãSốNhânViênToolStripMenuItem_nv_dlv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_select_option_search_DLV.Text = mãSốNhânViênToolStripMenuItem_nv_dlv.Text;
            AutoComplet(txt_content_search_DLV, "Mã số nhân viên", true);
        }
     

        private void toolStripButton__search_DLV_Click(object sender, EventArgs e)
        {
            string option_search = toolStripComboBox_select_option_search_DLV.Text;
            string content_search = txt_content_search_DLV.Text;
            bool check=cls_staffs_BUS1.Check_before_search_BUS(option_search, content_search);
            //bool check =cls_staffs_BUS1.Check_after_search_BUS(list_result_search_NVDLV);
            if (check == true)
            {
                List<Cls_Staff> list_result_search_NVDLV = new List<Cls_Staff>();
                list_result_search_NVDLV = cls_staffs_BUS1.Search_staff_BUS(option_search, content_search, true);
                bool check1 = cls_staffs_BUS1.Check_after_search_BUS(list_result_search_NVDLV);
                if (check1 == true)
                {
                    load_to_gridview(list_result_search_NVDLV, grv_DSNV_danglamviec, bdnvgt_DSNV_danglamviec);
                }
                else if (check1 == false)
                {
                    MessageBox.Show("Không tìm thấy bất cứ kết quả nào phù hợp");
                }
            }
            else
            {
                MessageBox.Show("bạn chưa chọn tiêu chí tìm kiếm hoặc chưa nhập nội dung tìm kiếm");
            }

        }

        public void AutoComplet(ToolStripTextBox txt_search, string option_search, bool status)
        {
            txt_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_search.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_search.AutoCompleteCustomSource.Clear();
            List<Cls_Staff> list_staff_auto = new List<Cls_Staff>(); 
            if (status == true)
            {
                list_staff_auto = cls_staffs_BUS1.Get_list_staffs_Active_BUS(id_current);

            }
            else
            {
                list_staff_auto = cls_staffs_BUS1.Get_list_staffs_Inactive_BUS(id_current);
            }
            List<Cls_Department> list_department_auto = new List<Cls_Department>();
            list_department_auto = cls_department_BUS1.Get_list_department_BUS();
            if (option_search.Equals("Tên phòng ban") == true)
            {
               
              foreach(Cls_Department a in list_department_auto)
                {
                    txt_content_search_DLV.AutoCompleteCustomSource.Add(a.Name_dp);
                    txt_content_search_NV.AutoCompleteCustomSource.Add(a.Name_dp);
                }

            }
            else if (option_search.Equals("Mã số phòng ban") == true)
            {
                foreach (Cls_Department a in list_department_auto)
                {
                    txt_content_search_DLV.AutoCompleteCustomSource.Add(a.Id_dp);
                    txt_content_search_NV.AutoCompleteCustomSource.Add(a.Id_dp);
                }
            }
            else if (option_search.Equals("Tên nhân viên") == true)
            {
               
               foreach (Cls_Staff a in list_staff_auto)
                {
                    txt_content_search_DLV.AutoCompleteCustomSource.Add(a.Name);
                    txt_content_search_NV.AutoCompleteCustomSource.Add(a.Name);
                }
            }
            else if (option_search.Equals("Mã số nhân viên") == true)
            {
             
                foreach (Cls_Staff a in list_staff_auto)
                {
                    txt_content_search_DLV.AutoCompleteCustomSource.Add(a.Id_staff);
                    txt_content_search_NV.AutoCompleteCustomSource.Add(a.Id_staff);
                }
            }
            //this.list_acc = cls_acc_BUS1.Get_List_Acc_BUS();
            //this.list_staff = cls_staffs_BUS1.Get_list_staff_BUS();
            //this.txb_timkiem.AutoCompleteCustomSource.Clear();
            //if (this.rdo_ID_Acc.Checked == true)
            //{
            //    foreach (Cls_Account id_acc in list_acc)
            //    {
            //        this.txb_timkiem.AutoCompleteCustomSource.Add(id_acc.Id_acc);
            //    }
            //}
            //else if (this.rdo_NameST.Checked == true)
            //{
            //    foreach (Cls_Staff name in list_staff)
            //    {
            //        this.txb_timkiem.AutoCompleteCustomSource.Add(name.Name);
            //    }
            //}
        }

        public void ReadOnly_TextBox(bool e)
        {

            txt_dg_NV_danglamviec.ReadOnly = e;
            txt_dg_NV_nghiviec.ReadOnly = e;
            txt_ms_nv_DLV.ReadOnly = e;
            txt_ms_nv_NV.ReadOnly = e;
            txt_nameCongviec_NV_danglamviec.ReadOnly = e;
            txt_name_Congviec_NV_nghiviec.ReadOnly = e;
            txt_name_pb_NV_danglamviec.ReadOnly = e;
            txt_name_PB_NV_nghiviec.ReadOnly = e;
            txt_time_LV_NV_nghiviec.ReadOnly = e;
            txt_name_PB_NV_nghiviec.ReadOnly = e;
            dtp_NgaybatDau_NV_DLV.Enabled = !e;
            dtp_NgayBatDau_nv_NV.Enabled = !e;
            dtp_NgayNV.Enabled = !e;
            txt_time_LV_NV_danglamviec.ReadOnly = e;
            txt_name_NV_nghiviec.ReadOnly = e;
            txt_name_NV_danglamviec.ReadOnly = e;
        }

        public void btn_cancel_GiaiQuyetNghiViec_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_search_NV_Click(object sender, EventArgs e)
        {
            // tìm nhân viên bên nghỉ việc

            string option_search = toolStripComboBox_option_search_nvnv.Text;
            string content_search = txt_content_search_NV.Text;
            bool check = cls_staffs_BUS1.Check_before_search_BUS(option_search, content_search);
            //bool check = cls_staffs_BUS1.Check_after_search_BUS(list_result_search_NVDLV);
            if (check == true)
            {
                List<Cls_Staff> list_result_search_staff_NV = new List<Cls_Staff>();
                list_result_search_staff_NV = cls_staffs_BUS1.Search_staff_BUS(option_search, content_search, false);
                bool check1 = cls_staffs_BUS1.Check_after_search_BUS(list_result_search_staff_NV);
                if (check1 == true)
                {
                    load_to_gridview(list_result_search_staff_NV, grv_DSNV_nghiviec, bdnvgt_DSNV_nghiviec);
                }
                else if (check1 == false)
                {
                    MessageBox.Show("Không tìm thấy bất cứ kết quả nào phù hợp");
                }
            }
            else
            {
                MessageBox.Show("bạn chưa chọn tiêu chí tìm kiếm hoặc chưa nhập nội dung tìm kiếm");
            }
        }

        //private void mãSốNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    //toolStripComboBox_select_option_search_NV.Text = mãSốNhânViênToolStripMenuItem1.Text;
        //    AutoComplet(txt_content_search_NV, "Mã số nhân viên", true);
        //}

        private void tênNhânViênToolStripMenuItem_nv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search_nvnv.Text = tênNhânViênToolStripMenuItem_nv.Text;
            AutoComplet(txt_content_search_NV, "Tên nhân viên", false);
        }

        private void mãSốPhòngBanToolStripMenuItem_nv_Click(object sender, EventArgs e)
        {

            toolStripComboBox_option_search_nvnv.Text = mãSốPhòngBanToolStripMenuItem_nv.Text;
            AutoComplet(txt_content_search_NV, "Mã số phòng ban", false);
        }

        private void tênPhòngBanToolStripMenuItem_nv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search_nvnv.Text = tênPhòngBanToolStripMenuItem_nv.Text;
            AutoComplet(txt_content_search_NV, "Tên phòng ban", false);
        }

        private void mãSốNhânViênToolStripMenuItem_nv_Click(object sender, EventArgs e)
        {
            toolStripComboBox_option_search_nvnv.Text = mãSốNhânViênToolStripMenuItem_nv.Text;
            AutoComplet(txt_content_search_NV, "Mã số nhân viên", false);
        }
    }
}
