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
    public partial class Frm_ThongTinCaNhan : Form
    {
        Cls_Account cls_acc_curent = new Cls_Account();
        Cls_Department_BUS cls_department_bus1 = new Cls_Department_BUS();
        Cls_Contract_BUS cls_contract_bus1 = new Cls_Contract_BUS();
        Cls_Staffs_BUS cls_staff_bus1 = new Cls_Staffs_BUS();
        public Frm_ThongTinCaNhan(Cls_Account cls_acc_init)
        {
            InitializeComponent();
            cls_acc_curent = cls_acc_init;
        }
        bool a = true;
        private void Frm_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            load_toTextBox(cls_acc_curent);
            // grb_ThongTinCaNhan.Enabled = false;

            tbx_congviec.ReadOnly = true;
            tbx_calamviec.ReadOnly = true;
            tbx_luong.ReadOnly = true;
            tbx_phongban.ReadOnly = true;
            ckb_danglamviec.Enabled = false;
            btn_luu_thongtincapnhat.Enabled = false;
            readonly_textbox(true);
            


        }
        public void readonly_textbox(bool a)
        {
            tbx_id.ReadOnly = a;
            tbx_name.ReadOnly = a;
            dtp_ngaysinh.Enabled = !a;
            tbx_sdt.ReadOnly = a;
            tbx_email.ReadOnly = a;
            tbx_address.ReadOnly = a;
            ckb_gioitinh.Enabled = !a;
          

            
            
        }
        public void load_toTextBox(Cls_Account acc)
        {
            tbx_id.Text = acc.Id_acc;
            Cls_Staff stff = new Cls_Staff();
            Cls_Staffs_BUS cls_staff_bus1 = new Cls_Staffs_BUS();
            stff = cls_staff_bus1.Get_staff_BUS(acc.Id_acc);
            tbx_name.Text = stff.Name.Trim();
            tbx_email.Text = stff.Mail.Trim();
            dtp_ngaysinh.Value = stff.Birtday;
            tbx_address.Text = stff.Address;
            tbx_sdt.Text = stff.Phone;
            if (stff.Gender.Trim().ToLower().Equals("female") == true)
            {
                ckb_gioitinh.Checked = false;
            }
            else if(stff.Gender.Trim().ToLower().Equals("male") == true){
                ckb_gioitinh.Checked = true;
            }
           
            tbx_phongban.Text = cls_department_bus1.Get_department_BUS(cls_acc_curent.Id_acc).Name_dp;
     
            tbx_luong.Text = cls_contract_bus1.Get_contract_BUS(cls_acc_curent.Id_acc).Salary.ToString();
            Cls_JobTitle_BUS cls_jobtitle_bus1 = new Cls_JobTitle_BUS();
            Cls_JobTitle jb = new Cls_JobTitle();
            jb = cls_jobtitle_bus1.Get_jobtitle_BUS(acc.Id_acc);
            ckb_danglamviec.Checked = true ? stff.Status_staff == true : false;
            tbx_congviec.Text = jb.Name_job;
            Cls_Shiffs_BUS cls_shiff_bus1 = new Cls_Shiffs_BUS();
            tbx_calamviec.Text = cls_shiff_bus1.Get_shiff_BUS(acc.Id_acc).Shiff_time;
            Cls_Evaluate_BUS cls_evaluate_bus1 = new Cls_Evaluate_BUS();
            //Cls_Eveluate eva = new Cls_Eveluate();
            //eva = cls_evaluate_bus1.Get_Eveluate_staff_BUS(acc.Id_acc);
            //if (eva != null)
            //{
            //    rtbx_danhgia.Text = eva.Eva_desc;
            //}
            innit_listview_danhgia(lvw_danhgia);


            List<Cls_Eveluate> l_eva = new List<Cls_Eveluate>();
            l_eva = cls_evaluate_bus1.list_eve_BUS(cls_acc_curent.Id_acc);
            load_to_listview_danhgia(lvw_danhgia,l_eva);

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

        private void btn_update_ttcn_Click(object sender, EventArgs e)
        {

          
            if (btn_update_ttcn.Text.Trim().ToLower().Equals("cập nhật thông tin"))
            {
                btn_update_ttcn.Text = "Hủy cập nhật thông tin";
                btn_update_ttcn.Image = Presentation.Properties.Resources.icons8_cancel_64;
                btn_luu_thongtincapnhat.Enabled = true;
                tbx_id.Enabled = false;
                ckb_danglamviec.Enabled = false;
                readonly_textbox(false);
            }
            else if (btn_update_ttcn.Text.Trim().ToLower().Equals("hủy cập nhật thông tin"))
            {

                btn_update_ttcn.Text = "Cập nhật thông tin";
                btn_update_ttcn.Image = Presentation.Properties.Resources.update;
                btn_luu_thongtincapnhat.Enabled = false;
                tbx_id.Enabled = false;
                ckb_danglamviec.Enabled = false;
                readonly_textbox(true);


            }
        }

        private void btn_luu_thongtincapnhat_Click(object sender, EventArgs e)
        {
            if (tbx_luong.Text.Trim() == null || tbx_name.Text.Trim() == null || tbx_id.Text.Trim() == null || tbx_sdt.Text.Trim() == null || tbx_email.Text.Trim() == null || tbx_address.Text.Trim() == null )
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Cls_Staff staff_new = new Cls_Staff();
                staff_new.Id_staff = tbx_id.Text;
                staff_new.Name = tbx_name.Text;
                staff_new.Phone = tbx_sdt.Text;
                staff_new.Mail = tbx_email.Text;
                staff_new.Address = tbx_address.Text;
                if (ckb_gioitinh.Checked == true)
                {
                    staff_new.Gender = "male";
                }
                else if (ckb_gioitinh.Checked == false)
                {
                    staff_new.Gender = "female";
                }
                staff_new.Birtday = dtp_ngaysinh.Value;
                if (cls_staff_bus1.UpdateOnSubmitChange_staff_BUS(staff_new) == true)
                {
                    MessageBox.Show("Thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_luu_thongtincapnhat.Enabled = false;
                    btn_update_ttcn.Enabled = true;
                    btn_update_ttcn.Text = "Cập nhật thông tin";
                    btn_update_ttcn.Image = Presentation.Properties.Resources.update;
                    readonly_textbox(true);
                }
            }

        }         


    }
}
