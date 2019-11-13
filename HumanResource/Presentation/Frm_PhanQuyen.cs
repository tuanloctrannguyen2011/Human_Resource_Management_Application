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
    public partial class Frm_PhanQuyen : Form
    {
        string id_current = "";
        public Frm_PhanQuyen(Cls_Account acc_current)
        {
            InitializeComponent();
            id_current = acc_current.Id_acc;

        }
        Cls_account_BUS cls_acc_BUS1 = new Cls_account_BUS();
        Cls_TongHop_BUS cls_tonghop_BUS1 = new Cls_TongHop_BUS();
        Cls_Staffs_BUS cls_staffs_BUS1 = new Cls_Staffs_BUS();
        List<Cls_Account> list_acc = new List<Cls_Account>();
        List<Cls_Staff> list_staff = new List<Cls_Staff>();
        //List<object> list_tt_acc = new List<object>();

        public void btn_cancel_PhanQuyen_Click(object sender, EventArgs e)
        {
            //DialogResult rs;
            //rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rs == DialogResult.Yes)
            //{
            //    this.Close();

            //}
        }

        private void Frm_PhanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult rs;
            //rs = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (rs == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void Frm_PhanQuyen_Load(object sender, EventArgs e)
        {
            grb_tt_tk.Enabled = false;
            grb_pq.Enabled = false;
            btn_Timkiem.Enabled = true;



            list_acc = cls_acc_BUS1.Get_List_Acc_BUS(id_current);
            Load_to_gridView(grV_Acc, list_acc);
            //grV_Acc.Rows[grV_Acc.Rows.Count - 1].Visible = false;
            grV_Acc.AllowUserToAddRows = false;

            txb_timkiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txb_timkiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            rdo_NameST.Checked = true;

            txb_timkiem.Text = "Nhập vào thông tin tìm kiếm";
            txb_timkiem.ForeColor = Color.DeepSkyBlue;

            clickToSort();
        }

        public void Load_to_gridView(DataGridView a, List<Cls_Account> b)
        {
            BindingSource BD_Acc = new BindingSource();
            BD_Acc.DataSource = b;
            a.DataSource = BD_Acc;
            formmat_Gridview_ACC(a);
        }
        public void formmat_Gridview_ACC(DataGridView abc)
        {

            //abc.AutoResizeColumns();
            //abc.AutoResizeRows();
            //abc.Columns[0].Width = 130;
            //abc.Columns[2].Width = 135;
            abc.AllowUserToResizeColumns = true;
            abc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            abc.ReadOnly = true;
            abc.RowHeadersVisible = false;
            abc.Columns[0].HeaderText = "Mã Số tài khoản";
            abc.Columns[1].HeaderText = "Mật khẩu";
            abc.Columns[1].Visible = false;
            abc.Columns[2].HeaderText = "Quyền hạn";


        }

        private void grV_Acc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grb_pq.Enabled == false)
            {

                string ma = grV_Acc.SelectedRows[0].Cells[0].Value.ToString();
                string quyenhan = grV_Acc.SelectedRows[0].Cells[2].Value.ToString();

                //list_tt_acc = cls_tonghop_BUS1.Get_ThongTin_TongHop_BUS(ma);
                //Load_to_Gridview_TT_ACC(grV_Thongtin_Acc, list_tt_acc);
                txb_nameqhpq.Text = quyenhan;
                txb_idtkpq.Text = ma;
                List<Cls_Department> ld = cls_tonghop_BUS1.Get_list_dpm_BUS(ma);
                Cls_Department dp1 = new Cls_Department();
                foreach (Cls_Department d in ld)
                {
                    //dp1.Id_dp = d.Id_dp;
                    //dp1.Name_dp = d.Name_dp;
                    txb_namepbpq.Text = d.Name_dp;
                }

                List<Cls_Staff> st = cls_tonghop_BUS1.Get_list_staff_BUS(ma);
                // Cls_Staff st1 = new Cls_Staff();
                foreach (Cls_Staff s in st)
                {
                    //st1.Address = s.Address;
                    //st1.Id_staff = s.Id_staff;
                    //st1.Mail = s.Mail;
                    //st1.Name = s.Name;
                    //st1.Phone = s.Phone;
                    //st1.Status_staff = s.Status_staff;
                    txb_idnvpq.Text = s.Id_staff;
                    txb_namenvpq.Text = s.Name;
                    if (s.Gender.Trim().ToLower().Equals("nam") == true)
                    {
                        ckb_gioitinh.Checked = true;
                    }
                    else if (s.Gender.Trim().ToLower().Equals("nữ") == true)
                    {
                        ckb_gioitinh.Checked = false;
                    }
                }
                List<Cls_JobTitle> jb = cls_tonghop_BUS1.Get_list_job_BUS(ma);
                Cls_JobTitle jb1 = new Cls_JobTitle();
                foreach (Cls_JobTitle j in jb)
                {
                    //jb1.Id_job = j.Id_job;
                    //jb1.Name_job = j.Name_job;
                    //jb1.Des_job = j.Des_job;
                    txb_namecvpq.Text = j.Name_job;
                }


            }
            else if (grb_pq.Enabled == true)
            {

                string ma = grV_Acc.SelectedRows[0].Cells[0].Value.ToString();
                string quyenhan = grV_Acc.SelectedRows[0].Cells[2].Value.ToString();
                btn_Phanquyen.Enabled = true;
                //list_tt_acc = cls_tonghop_BUS1.Get_ThongTin_TongHop_BUS(ma);
                //Load_to_Gridview_TT_ACC(grV_Thongtin_Acc, list_tt_acc);
                txb_nameqhpq.Text = quyenhan;
                txb_idtkpq.Text = ma;
                List<Cls_Department> ld = cls_tonghop_BUS1.Get_list_dpm_BUS(ma);
                Cls_Department dp1 = new Cls_Department();
                foreach (Cls_Department d in ld)
                {
                    //dp1.Id_dp = d.Id_dp;
                    //dp1.Name_dp = d.Name_dp;
                    txb_namepbpq.Text = d.Name_dp;
                }
                List<Cls_Staff> st = cls_tonghop_BUS1.Get_list_staff_BUS(ma);
                Cls_Staff st1 = new Cls_Staff();
                foreach (Cls_Staff s in st)
                {
                    //st1.Address = s.Address;
                    //st1.Id_staff = s.Id_staff;
                    //st1.Mail = s.Mail;
                    //st1.Name = s.Name;
                    //st1.Phone = s.Phone;
                    //st1.Status_staff = s.Status_staff;
                    txb_idnvpq.Text = s.Id_staff;
                    txb_namenvpq.Text = s.Name;
                    if (s.Gender.Trim().Equals("Nam") == true)
                    {
                        ckb_gioitinh.Checked = true;
                    }
                    else if (s.Gender.Trim().Equals("Nữ") == true)
                    {
                        ckb_gioitinh.Checked = false;
                    }
                }
                List<Cls_JobTitle> jb = cls_tonghop_BUS1.Get_list_job_BUS(ma);
                Cls_JobTitle jb1 = new Cls_JobTitle();
                foreach (Cls_JobTitle j in jb)
                {
                    //jb1.Id_job = j.Id_job;
                    //jb1.Name_job = j.Name_job;
                    //jb1.Des_job = j.Des_job;
                    txb_namecvpq.Text = j.Name_job;
                }
                string[] array_quyen_han = new string[4] { "admin", "hrstaff", "staff", "manager" };
                Load_to_grb_ThongTinTK(array_quyen_han);



            }




        }
        public void Load_to_Gridview_TT_ACC(DataGridView a, List<object> b)
        {
            BindingSource BD_TT_Acc = new BindingSource();
            BD_TT_Acc.DataSource = b;
            //grV_Thongtin_Acc.DataSource = BD_TT_Acc;


        }

        private void btn_Phanquyen_Click(object sender, EventArgs e)
        {
            if (txb_idnvpq.Text.Equals("") == false)
            {

                grb_pq.Enabled = true;
                txb_idtk_cq.ReadOnly = true;
                #region phân quyền kiểu khác

                //List<Cls_Account> TK_N1 = cls_acc_BUS1.Get_QuyenHan_to_ThongTinTK_BUS();
                //Load_to_grb_ThongTinTK(TK_N1);
                #endregion
                string[] array_quyen_han = new string[4] { "admin", "hrstaff", "staff", "manager" };
                Load_to_grb_ThongTinTK(array_quyen_han);
            }
            else
            {
                MessageBox.Show("Mời bạn chọn tài khoản cần cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Load_to_grb_ThongTinTK(string[] array_quyen_han)
        {
            txb_idtk_cq.Text = txb_idtkpq.Text;
            cmb_qh.DataSource = array_quyen_han;
            #region load dữu liệu phân quyền kiểu khác
            //    txb_idtk_cq.Text = txb_idtkpq.Text;
            //    cmb_qh.DataSource = tk_n;
            //    cmb_qh.DisplayMember = "Role_name";
            //    cmb_qh.ValueMember = "Role_name";
            #endregion

        }

        private void btn_luu_phanquyen_Click(object sender, EventArgs e)
        {


            if (cls_acc_BUS1.UpdateOnSubmitChange_quyenhan_BUS(txb_idtk_cq.Text, cmb_qh.SelectedValue.ToString()) == 1)
            {
                MessageBox.Show("Thành công");
                list_acc = cls_acc_BUS1.Get_List_Acc_BUS(id_current);
                Load_to_gridView(grV_Acc, list_acc);
                txb_nameqhpq.Text = cmb_qh.SelectedValue.ToString();
                txb_idtk_cq.Text = "";
                cmb_qh.Text = "";
                grb_pq.Enabled = false;
            }
            else
            {
                DialogResult a = MessageBox.Show("lưu không tành công \n bạn có muốn tiếp tục", "Thông báo", MessageBoxButtons.YesNo);
                if (a == DialogResult.No)
                {
                    txb_idtk_cq.Text = "";
                    cmb_qh.Text = "";
                    grb_pq.Enabled = false;
                }
            }
        }

        private void rdo_NameST_CheckedChanged(object sender, EventArgs e)
        {
            Autocomlet();
            txb_timkiem.Text = "Nhập vào tên nhân viên";
            txb_timkiem.ForeColor = Color.Red;

        }

        private void rdo_ID_Acc_CheckedChanged(object sender, EventArgs e)
        {
            Autocomlet();
            txb_timkiem.Text = "Nhập mã số tài khoản hoặc mã số nhân viên";
            txb_timkiem.ForeColor = Color.Red;
        }
        public void Autocomlet()
        {
            this.list_acc = cls_acc_BUS1.Get_List_Acc_BUS(id_current);
            this.list_staff = cls_staffs_BUS1.Get_list_staff_BUS();
            this.txb_timkiem.AutoCompleteCustomSource.Clear();
            if (this.rdo_ID_Acc.Checked == true)
            {
                foreach (Cls_Account id_acc in list_acc)
                {
                    this.txb_timkiem.AutoCompleteCustomSource.Add(id_acc.Id_acc);
                }
            }
            else if (this.rdo_NameST.Checked == true)
            {
                foreach (Cls_Staff name in list_staff)
                {
                    this.txb_timkiem.AutoCompleteCustomSource.Add(name.Name);
                }
            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            if (txb_timkiem.Text.Trim().Equals("") == false)
            {

                if (this.rdo_NameST.Checked == true && this.rdo_ID_Acc.Checked == false)
                {
                    if (this.cls_acc_BUS1.Check_Timkiem(txb_timkiem.Text))
                    {
                        //MessageBox.Show("Tìm thấy");
                        this.list_acc = cls_acc_BUS1.Search_follow_name_BUS(txb_timkiem.Text);
                        Load_to_gridView(this.grV_Acc, this.list_acc);
                        clear_textbox();
                    }
                    else
                    {
                        MessageBox.Show("tìm không thấy");
                    }
                }
                else if (this.rdo_NameST.Checked == false && this.rdo_ID_Acc.Checked == true)
                {
                    if (this.cls_acc_BUS1.Check_Timkiem(txb_timkiem.Text))
                    {
                        MessageBox.Show("Tìm thấy");
                        this.list_acc = cls_acc_BUS1.Search_follow_id_BUS(txb_timkiem.Text);
                        Load_to_gridView(this.grV_Acc, this.list_acc);
                    }
                    else
                    {
                        MessageBox.Show("tìm không thấy");
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập thông tin cần tìm kiếm");

            }


        }

        private void btn_all_acc_Click(object sender, EventArgs e)
        {

            list_acc = cls_acc_BUS1.Get_List_Acc_BUS(id_current);
            Load_to_gridView(grV_Acc, list_acc);
            clear_textbox();
        }

        public void clear_textbox()
        {
            txb_idnvpq.Text = "";
            txb_idtkpq.Text = "";
            txb_idtk_cq.Text = "";
            txb_namecvpq.Text = "";
            txb_namenvpq.Text = "";
            txb_namepbpq.Text = "";
            txb_nameqhpq.Text = "";
            txb_timkiem.Text = "";
            cmb_qh.Text = "";
            grb_pq.Enabled = false;

        }

        private void txb_timkiem_MouseDown(object sender, MouseEventArgs e)
        {
            txb_timkiem.Text = "";
            txb_timkiem.ForeColor = Color.Black;
        }

        private void btn_huyPq_Click(object sender, EventArgs e)
        {
            grb_pq.Enabled = false;
            txb_idtk_cq.Text = "";
            cmb_qh.Text = "";
        }


        private void clickToSort()
        {
            grV_Acc.ColumnHeaderMouseClick += GrV_Acc_ColumnHeaderMouseClick;
            grV_Acc.Columns[0].Tag = 0;
            grV_Acc.Columns[2].Tag = 1;
        }

        private void GrV_Acc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Load_to_gridView(grV_Acc, cls_acc_BUS1.Get_List_Acc_Affter_Sort_By_Id_BUS(getListAccFromDGV(), ((int)grV_Acc.Columns[0].Tag)));
                grV_Acc.Columns[0].Tag = ((int)grV_Acc.Columns[0].Tag) == 1 ? 0 : 1;


            }
            else if (e.ColumnIndex == 2)
            {
                Load_to_gridView(grV_Acc, cls_acc_BUS1.Get_List_Acc_Affter_Sort_By_Role_BUS(getListAccFromDGV(), ((int)grV_Acc.Columns[2].Tag)));
                grV_Acc.Columns[2].Tag = ((int)grV_Acc.Columns[2].Tag) == 1 ? 0 : 1;
            }
        }

        /// <summary>
        /// ép kiểu datasource của gdv thành list<class account>
        /// </summary>
        /// <returns></returns>
        private List<Cls_Account> getListAccFromDGV()
        {
            return (List<Cls_Account>)((BindingSource)grV_Acc.DataSource).DataSource;
        }

        private void cmb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == " ")
            {
                list_acc = cls_acc_BUS1.Get_List_Acc_BUS(id_current);
                Load_to_gridView(grV_Acc, list_acc);
            }
            else
            {
                list_acc = cls_acc_BUS1.Get_List_Acc_Affter_Fill(((ComboBox)sender).Text, id_current);
                Load_to_gridView(grV_Acc, list_acc);
            }
        }



        private void btn_reset_pass_Click(object sender, EventArgs e)
        {
            if (grV_Acc.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("mật khẩu của tài khoản này sẽ được reset về mặc định => Bạn muốn tiếp tục ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    string id = grV_Acc.SelectedRows[0].Cells[0].Value.ToString();
                    string default_password = "qwerty";
                    string ma_code = Cls_validate_login.HashPassword(default_password);
                    cls_acc_BUS1.Change_Pass(id, ma_code);
                    string check_reset = cls_acc_BUS1.Get_PASS_by_id_BUS(id);
                    if (ma_code.Equals(check_reset) == true)
                    {
                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
               

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mật khẩu cần reset", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
