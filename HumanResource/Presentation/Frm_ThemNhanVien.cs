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
    public partial class Frm_ThemNhanVien : Form
    {
        string innit_id = "";
        public Frm_ThemNhanVien()
        {
            InitializeComponent();
        }
        public Frm_ThemNhanVien(string id_curent)
        {
            InitializeComponent();
            innit_id = id_curent;
        }
        string id_contract_edit1 = "";
        string id_staff_edit1 = "";

        public Frm_ThemNhanVien(string id_contract_edit, string id_staff_edit)
        {
            InitializeComponent();
            id_contract_edit1 = id_contract_edit;
            id_staff_edit1 = id_staff_edit;




        }
        bool check_them_tk = false;
        bool check_them_nv = false;
        bool check_them_ct = false;
        Cls_Contract_BUS cls_contract_bus1 = new Cls_Contract_BUS();
        Cls_Department_BUS cls_department_bus1 = new Cls_Department_BUS();
        Cls_JobTitle_BUS cls_job_title_bus1 = new Cls_JobTitle_BUS();
        Cls_Shiffs_BUS cls_shiff_bus1 = new Cls_Shiffs_BUS();
        Cls_Staffs_BUS cls_staff_bus1 = new Cls_Staffs_BUS();
        Cls_account_BUS cls_account_bus1 = new Cls_account_BUS();


        private void Frm_ThemNhanVien_Load(object sender, EventArgs e)
        {


            if (!id_contract_edit1.Trim().Equals("") && !id_staff_edit1.Trim().Equals(""))
            {

                load_form_edit();
                List<Cls_Shiff> list_shift1 = new List<Cls_Shiff>();
                list_shift1 = cls_shiff_bus1.Get_list_shiff_BUS();

                List<Cls_Department> list_department1 = new List<Cls_Department>();
                list_department1 = cls_department_bus1.Get_list_department_BUS();
                List<Cls_JobTitle> list_jobtitle1 = new List<Cls_JobTitle>();
                list_jobtitle1 = cls_job_title_bus1.Get_list_job_title_BUS();
                cmb_CVI.DataSource = list_jobtitle1;
                cmb_CVI.DisplayMember = "Name_job";
                cmb_CVI.ValueMember = "Id_job";
                cmb_DPM.DataSource = list_department1;
                cmb_DPM.DisplayMember = "Name_dp";
                cmb_DPM.ValueMember = "Id_dp";
                cmb_TG.DataSource = list_shift1;
                cmb_TG.DisplayMember = "Shiff_time";
                cmb_TG.ValueMember = "Id_shift";
            }
            else
            {
                cmb_CVI.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_DPM.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_TG.DropDownStyle = ComboBoxStyle.DropDownList;

                grb_tt_hopdong.Enabled = true;
                grb_tt_nhanvien.Enabled = false;
                grb_tt_taikhoan.Enabled = false;
                txt_MaHD.ReadOnly = true;

                dt_ngaybatdau.Format = DateTimePickerFormat.Custom;
                dt_ngaybatdau.CustomFormat = "----------";

                dtp_ngaysinh.Format = DateTimePickerFormat.Custom;
                dtp_ngaysinh.CustomFormat = "----------";

                txt_MaHD.Text = cls_contract_bus1.genaration_id_new_contract_BUS();

                List<Cls_Shiff> list_shift1 = new List<Cls_Shiff>();
                list_shift1 = cls_shiff_bus1.Get_list_shiff_BUS();
                List<Cls_Department> list_department1 = new List<Cls_Department>();
                list_department1 = cls_department_bus1.Get_list_department_BUS();
                List<Cls_JobTitle> list_jobtitle1 = new List<Cls_JobTitle>();
                list_jobtitle1 = cls_job_title_bus1.Get_list_job_title_BUS();

                load_to_cmb(list_shift1, list_department1, list_jobtitle1);
            }




        }
        public void load_to_cmb(List<Cls_Shiff> list_shiff1, List<Cls_Department> list_department1, List<Cls_JobTitle> list_jobtitle)
        {


            ///////////
            this.cmb_TG.DataSource = list_shiff1;
            this.cmb_TG.DisplayMember = "Shiff_time";
            this.cmb_TG.ValueMember = "Id_shift";

            ////
            this.cmb_DPM.DataSource = list_department1;
            this.cmb_DPM.DisplayMember = "Name_dp";
            this.cmb_DPM.ValueMember = "Id_dp";
            //////
            this.cmb_CVI.DataSource = list_jobtitle;
            this.cmb_CVI.DisplayMember = "Name_job";
            this.cmb_CVI.ValueMember = "Id_job";
        }

        public void load_form_edit()
        {
            Cls_Contract ct = cls_contract_bus1.Get_contract_BUS(id_contract_edit1);
            Cls_Staff st = cls_staff_bus1.Get_staff_BUS(id_staff_edit1);
            btn_luuMoi_contract.Text = "Cập nhật hợp đồng";
            btn_luuMOINV.Visible = false;
            btn_luu_tk.Visible = false;
            txt_id_tk.Text = id_contract_edit1;
            txt_MaHD.Text = id_contract_edit1;
            txt_MNV.Text = id_staff_edit1;
            // phần hợp đồng
            txt_MaHD.Text = id_contract_edit1;
            txt_THD.Text = ct.Contract_name;
            txt_luong.Text = ct.Salary.ToString();
            dt_ngaybatdau.Value = ct.Start_date;
            cmb_TG.Text = cls_shiff_bus1.Get_shiff_BUS(ct.Id_contract).Shiff_time;

            cmb_CVI.Text = cls_job_title_bus1.Get_jobtitle_BUS(ct.Id_contract).Name_job;

            cmb_DPM.Text = cls_department_bus1.Get_department_BUS(ct.Id_contract).Name_dp;


            // phần nhân viên
            txt_MNV.Text = id_staff_edit1;
            txt_TNV.Text = st.Name;
            txt_SDT.Text = st.Phone;
            txt_DIACHI.Text = st.Address;
            txt_DiaChiEMAIL.Text = st.Mail;
            dtp_ngaysinh.Format = DateTimePickerFormat.Custom;
            dtp_ngaysinh.CustomFormat = "dd-MM-yyyy";
            dtp_ngaysinh.Value = st.Birtday;
            if (st.Gender.Equals("male") == true)
            {
                ckb_gioitinh.Checked = true;
            }
            else if (st.Gender.Equals("female") == true)
            {
                ckb_gioitinh.Checked = false;
            }
            // phần tài khoản
            txt_id_tk.Text = txt_MNV.Text;
            cmb_quyenhan.Text = cls_account_bus1.Get_account_by_id_BUS(id_contract_edit1).Role_name;


        }

        public bool check_contract()
        {
            if (txt_MaHD.Text.Trim().Equals("") == true || txt_THD.Text.Trim().Equals("") == true || cmb_CVI.Text.Trim().Equals("") == true || txt_luong.Text.Trim().Equals("") == true || cmb_TG.Text.Trim().Equals("") == true || cmb_DPM.Text.Trim().Equals("") == true || dt_ngaybatdau.Text.Equals("----------") == true)
            {

                return false;
            }
            return true;
        }

        private void dt_ngaybatdau_ValueChanged(object sender, EventArgs e)
        {
            dt_ngaybatdau.Format = DateTimePickerFormat.Custom;
            dt_ngaybatdau.CustomFormat = "dd-MM-yyyy";
            //MessageBox.Show(dt_ngaybatdau.Text);
            //MessageBox.Show(dt_ngaybatdau.Value.ToShortDateString());
        }

        private void btn_luuMoi_contract_Click(object sender, EventArgs e)
        {

            bool a = check_contract();
            if (a == true)
            {

                Cls_Contract aa = new Cls_Contract();
                aa.Id_contract = txt_MaHD.Text;
                aa.Contract_name = txt_THD.Text;
                aa.Id_shiff = cmb_TG.SelectedValue.ToString();
                aa.Id_job = cmb_CVI.SelectedValue.ToString();
                aa.Id_department = cmb_DPM.SelectedValue.ToString();
                aa.Start_date = dt_ngaybatdau.Value;
                if (txt_luong.Text.Trim().Equals("") != true)
                {
                    aa.Salary = int.Parse(txt_luong.Text);
                }
                else
                {
                    aa.Salary = 0;
                }
                if (btn_luuMoi_contract.Text.Trim().ToLower().Equals("lưu mới một hợp đồng") == true)
                {
                    if (cls_contract_bus1.InsertOnSubmit_Change_contract_BUS(aa) == true)
                    {
                        MessageBox.Show("Thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grb_tt_nhanvien.Enabled = true;
                        txt_MNV.Text = cls_staff_bus1.genaration_id_new_staff_BUS();
                        grb_tt_hopdong.Enabled = false;
                        grb_tt_taikhoan.Enabled = false;
                        dtp_ngaysinh.CustomFormat = "dd-MM-yyyy";
                        check_them_ct = true;

                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (btn_luuMoi_contract.Text.Trim().ToLower().Equals("cập nhật hợp đồng") == true)
                {
                    if (cls_contract_bus1.UpdateOnSubmitchange_contract_BUS(aa) == true)
                    {
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại, mười bạn nhập lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin hớp đồng mời bạn nhập đày đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool check_staff()
        {
            if (txt_MNV.Text.Trim().Equals("") == true || txt_TNV.Text.Equals("") == true || txt_SDT.Text.Trim().Equals("") == true || txt_DiaChiEMAIL.Text.Trim().Equals("") == true
                || txt_DIACHI.Text.Trim().Equals("") == true || dt_ngaybatdau.Text.Equals("----------") == true)
            {
                return false;
            }
            return true;
        }

        private void btn_luuMOINV_Click(object sender, EventArgs e)
        {
            if (check_staff() == true)
            {
                Cls_Staff staff_new = new Cls_Staff();
                staff_new.Id_staff = txt_MNV.Text;
                staff_new.Name = txt_TNV.Text;
                staff_new.Phone = txt_SDT.Text;
                staff_new.Mail = txt_DiaChiEMAIL.Text;
                staff_new.Status_staff = true;
                staff_new.Address = txt_DIACHI.Text;
                if (ckb_gioitinh.Checked == true)
                {
                    staff_new.Gender = "male";
                }
                else if (ckb_gioitinh.Checked == false)
                {
                    staff_new.Gender = "female";
                }
                staff_new.Birtday = dtp_ngaysinh.Value;
                if (cls_staff_bus1.InsertOnSubmitChange_nhanvien_BUS(staff_new) == true)
                {
                    Cls_StaffContract st_ct = new Cls_StaffContract();
                    st_ct.Id_contract = txt_MaHD.Text;
                    st_ct.Id_staff = txt_MNV.Text;
                    if (cls_staff_bus1.InsertOnsubmitChange_staff_contract_BUS(st_ct) == true)
                    {
                        MessageBox.Show("Thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grb_tt_hopdong.Enabled = false;
                        grb_tt_nhanvien.Enabled = false;
                        grb_tt_taikhoan.Enabled = true;
                        txt_id_tk.Text = txt_MNV.Text;
                        txt_id_tk.ReadOnly = true;
                        cmb_quyenhan.DropDownStyle = ComboBoxStyle.DropDownList;
                        string[] array_quyenhan = new string[5] { "Chọn quyền hạn", "admin", "hrstaff", "staff", "manager" };
                        cmb_quyenhan.DataSource = array_quyenhan;

                        check_them_nv = true;
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                MessageBox.Show("Bạn chưa nhập đủ thông tin nhân viên mời bạn nhập đày đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_luu_tk_Click(object sender, EventArgs e)
        {
            if (txt_id_tk.Text.Trim() != null && cmb_quyenhan.Text.Equals("Chọn quyền hạn") != true)
            {
                Cls_Account acc = new Cls_Account();
                acc.Id_acc = txt_id_tk.Text;
                acc.Role_name = cmb_quyenhan.Text;
                
                string default_password = "qwerty";
                string ma_code = Cls_validate_login.HashPassword(default_password);
                acc.Password = ma_code;
                if (cls_account_bus1.insertonsubmit_change_account_BUS(acc) == true)
                {
                    grb_tt_hopdong.Enabled = true;
                    grb_tt_nhanvien.Enabled = false;
                    grb_tt_taikhoan.Enabled = false;
                    txt_MaHD.Text = cls_contract_bus1.genaration_id_new_contract_BUS();
                    // Phần hợp đồng
                    txt_THD.Text = "";
                    txt_luong.Text = "";
                    //
                    cmb_quyenhan.Text = "";
                    txt_id_tk.Text = "";
                    //
                    txt_MNV.Text = "";
                    txt_TNV.Text = "";
                    txt_SDT.Text = "";
                    txt_DiaChiEMAIL.Text = "";
                    txt_DIACHI.Text = "";
                    ckb_gioitinh.Checked = false;
                    MessageBox.Show("Hoàn tất quá trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    check_them_tk = true;
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thồn tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        public void Frm_ThemNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (id_contract_edit1.Trim().Equals("") && id_staff_edit1.Trim().Equals(""))
            {
                if (check_them_ct == true || check_them_nv == true || check_them_tk == true)
                {
                    DialogResult result = MessageBox.Show("Bạn chưa hoàn tất quá trình thêm mới một nhân viên\n Nếu bạn thoát mọi thông tin sẽ bị hủy", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (check_them_ct == true && check_them_nv == false && grb_tt_taikhoan.Enabled == false)
                        {

                            if (cls_contract_bus1.DeleteOnsubmitChange_contract_BUS(txt_MaHD.Text.Trim()) == true)
                            {
                                MessageBox.Show("Hủy Thành công ");
                            }
                        }
                        else if (check_them_ct == true && check_them_nv == true && grb_tt_taikhoan.Enabled == true)
                        {
                            if (cls_staff_bus1.DeleteOnSubmitChange_staff_contract_BUS(txt_MaHD.Text.Trim(), txt_MNV.Text.Trim()) == true)
                            {
                                if (cls_staff_bus1.DeleteOnSubmitChange_staff(txt_MNV.Text.Trim()) == true && cls_contract_bus1.DeleteOnsubmitChange_contract_BUS(txt_MaHD.Text.Trim()) == true)
                                {
                                    MessageBox.Show("HỦy thành công 3 BẢNG");
                                }
                            }
                        }
                    }
                }


            }

        }

        //private void cmb_TG_Click(object sender, EventArgs e)
        //{
        //    List<Cls_Shiff> list_shift1 = new List<Cls_Shiff>();
        //    list_shift1 = cls_shiff_bus1.Get_list_shiff_BUS();

        //    List<Cls_Department> list_department1 = new List<Cls_Department>();
        //    list_department1 = cls_department_bus1.Get_list_department_BUS();
        //    List<Cls_JobTitle> list_jobtitle1 = new List<Cls_JobTitle>();
        //    list_jobtitle1 = cls_job_title_bus1.Get_list_job_title_BUS();
        //    load_to_cmb(list_shift1, list_department1, list_jobtitle1);

        //}

        //private void cmb_DPM_Click(object sender, EventArgs e)
        //{
        //    List<Cls_Shiff> list_shift1 = new List<Cls_Shiff>();
        //    list_shift1 = cls_shiff_bus1.Get_list_shiff_BUS();

        //    List<Cls_Department> list_department1 = new List<Cls_Department>();
        //    list_department1 = cls_department_bus1.Get_list_department_BUS();
        //    List<Cls_JobTitle> list_jobtitle1 = new List<Cls_JobTitle>();
        //    list_jobtitle1 = cls_job_title_bus1.Get_list_job_title_BUS();
        //    load_to_cmb(list_shift1, list_department1, list_jobtitle1);
        //}

        //private void cmb_CVI_Click(object sender, EventArgs e)
        //{
        //    List<Cls_Shiff> list_shift1 = new List<Cls_Shiff>();
        //    list_shift1 = cls_shiff_bus1.Get_list_shiff_BUS();

        //    List<Cls_Department> list_department1 = new List<Cls_Department>();
        //    list_department1 = cls_department_bus1.Get_list_department_BUS();
        //    List<Cls_JobTitle> list_jobtitle1 = new List<Cls_JobTitle>();
        //    list_jobtitle1 = cls_job_title_bus1.Get_list_job_title_BUS();
        //    load_to_cmb(list_shift1, list_department1, list_jobtitle1);
        //}
    }
}
