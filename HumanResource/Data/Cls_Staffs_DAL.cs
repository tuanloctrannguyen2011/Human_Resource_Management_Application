using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Staffs_DAL
    {
        // Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_Staffs_DAL()
        {
            //DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }
        public List<Cls_Staff> Get_list_staff()
        {

            List<Cls_Staff> list_staff = new List<Cls_Staff>();
            IEnumerable<Staff> a = DB.Staffs.ToList<Staff>();
            foreach (Staff x in a)
            {
                Cls_Staff x1 = new Cls_Staff();
                x1.Address = x.staff_address;
                x1.Id_staff = x.staff_id;
                x1.Mail = x.staff_mail;
                x1.Name = x.staff_name;
                x1.Phone = x.staff_phoneNo;
                x1.Status_staff = x.staff_status;
                list_staff.Add(x1);
            }

            return list_staff;
        }

        public List<Cls_Staff> Get_list_staff_load_form(string id_curent)
        {

            List<Cls_Staff> list_staff = new List<Cls_Staff>();
            IEnumerable<Staff> a = DB.Staffs.Where(x=>x.staff_id.Trim().Equals(id_curent.Trim())==false).ToList<Staff>();
            foreach (Staff x in a)
            {
                Cls_Staff x1 = new Cls_Staff();
                x1.Address = x.staff_address;
                x1.Id_staff = x.staff_id;
                x1.Mail = x.staff_mail;
                x1.Name = x.staff_name;
                x1.Phone = x.staff_phoneNo;
                x1.Status_staff = x.staff_status;
                list_staff.Add(x1);
            }

            return list_staff;
        }

        public List<Cls_Staff> Get_list_staffs_Active(string id_curent)
        {
            List<Cls_Staff> list_staff_active = new List<Cls_Staff>();
            IEnumerable<Staff> a = DB.Staffs.Where(x => x.staff_status == true).Where(x => x.staff_id.Equals(id_curent) == false).ToList<Staff>();
            foreach (Staff x in a)
            {
                Cls_Staff x1 = new Cls_Staff();
                x1.Address = x.staff_address;
                x1.Id_staff = x.staff_id;
                x1.Mail = x.staff_mail;
                x1.Name = x.staff_name;
                x1.Phone = x.staff_phoneNo;
                x1.Status_staff = x.staff_status;
                if (x.staff_gender.Equals("female") == true)
                {
                    x1.Gender = "Nữ";
                }
                else
                {
                    x1.Gender = "Nam";
                }
                x1.Birtday = x.staff_birthdate;
                list_staff_active.Add(x1);
            }

            return list_staff_active;
        }
        public List<Cls_Staff> Get_list_staffs_Inactive(string id_curent)
        {
            List<Cls_Staff> list_staff_inactive = new List<Cls_Staff>();
            IEnumerable<Staff> a = DB.Staffs.Where(x => x.staff_status == false).Where(x => x.staff_id.Equals(id_curent) == false).ToList<Staff>();
            foreach (Staff x in a)
            {
                Cls_Staff x1 = new Cls_Staff();
                x1.Address = x.staff_address;
                x1.Id_staff = x.staff_id;
                x1.Mail = x.staff_mail;
                x1.Name = x.staff_name;
                x1.Phone = x.staff_phoneNo;
                x1.Status_staff = x.staff_status;
                x1.Birtday = x.staff_birthdate;
                if (x.staff_gender.Equals("female") == true)
                {
                    x1.Gender = "Nữ";
                }
                else
                {
                    x1.Gender = "Nam";
                }
                list_staff_inactive.Add(x1);
            }

            return list_staff_inactive;
        }
        public void SubmitChange_DataGridview_active(Cls_Staff a)
        {
            if (a.Status_staff == false)
            {
                Staff staff = DB.Staffs.Where(x => x.staff_id.Equals(a.Id_staff) == true).Where(x => x.staff_status == true).SingleOrDefault();
                staff.staff_status = a.Status_staff;
            }
            else if (a.Status_staff == true)
            {
                Staff staff = DB.Staffs.Where(x => x.staff_id.Equals(a.Id_staff) == true).Where(x => x.staff_status == false).SingleOrDefault();
                staff.staff_status = a.Status_staff;
            }

            DB.SubmitChanges();
        }

        public Cls_Staff Get_staff(string id)
        {
            Cls_Staff a = new Cls_Staff();
            Staff b = DB.Staffs.Where(x => x.staff_id.Equals(id) == true).SingleOrDefault();
            a.Id_staff = b.staff_id;
            a.Mail = b.staff_mail;
            a.Address = b.staff_address;
            a.Name = b.staff_name;
            a.Phone = b.staff_phoneNo;
            a.Status_staff = b.staff_status;
            if (b.staff_gender.Trim().Equals("female") == true)
            {
                a.Gender = "Nữ";
            }
            else if (b.staff_gender.Trim().Equals("male") == true){
                a.Gender = "Nam";
            }
            a.Birtday = b.staff_birthdate;

            return a;
        }

        public List<Cls_Staff> Search_by_id_staff(string id, bool status)
        {
            List<Cls_Staff> list_result = new List<Cls_Staff>();
            if (status == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           where a.staff_id.Contains(id.Trim()) == true &&
                                                 a.staff_status == true
                                           select a
                                       ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }

            }
            else if (status == false)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           where a.staff_id.Contains(id.Trim()) == true &&
                                                 a.staff_status == false
                                           select a
                                       ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    b.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    list_result.Add(b);
                }
            }

            return list_result;

        }

        public List<Cls_Staff> Search_by_name_staff(string name, bool status)
        {
            List<Cls_Staff> list_result = new List<Cls_Staff>();
            if (status == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           where a.staff_name.Contains(name) == true && a.staff_status == true
                                           select a
                                        ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            else if (status == false)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           where a.staff_id.Contains(name) == true && a.staff_status == false
                                           select a
                                        ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    b.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    list_result.Add(b);
                }
            }


            return list_result;
        }

        public List<Cls_Staff> Search_by_id_department(string id, bool status)
        {
            List<Cls_Staff> list_result = new List<Cls_Staff>();
            if (status == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Contains(id.Trim()) == true
                                                && a.staff_status == true
                                           select a
                                         ).ToList<Staff>();

                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = b.Birtday;
                    list_result.Add(b);
                }
            }
            else if (status == false)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Contains(id.Trim()) == true
                                                && a.staff_status == false
                                           select a
                                         ).ToList<Staff>();

                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            return list_result;
        }
        public List<Cls_Staff> Search_by_name_department(string name, bool status)
        {

            List<Cls_Staff> list_result = new List<Cls_Staff>();
            if (status == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_name.Contains(name) == true && a.staff_status == true
                                           select a
                                         ).ToList<Staff>();

                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            else if (status == false)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Contains(name) == true && a.staff_status == false
                                           select a
                                        ).ToList<Staff>();

                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            return list_result;
        }

        public List<Cls_Staff> Get_list_staff_by_Id_department(string id)
        {
            List<Cls_Staff> list_stf = new List<Cls_Staff>();
            IEnumerable<Staff> l_stf = (from a in DB.Staffs
                                        join b in DB.Staff_Contracts
                                        on a.staff_id equals b.staff_id
                                        join c in DB.Contracts
                                        on b.contract_id equals c.contract_id
                                        join d in DB.Departments
                                        on c.dept_id equals d.dept_id
                                        where d.dept_id.Trim().Equals(id) == true
                                        select a
                                        ).ToList<Staff>();
            foreach (Staff a in l_stf)
            {
                Cls_Staff b = new Cls_Staff();
                b.Address = a.staff_address;
                b.Id_staff = a.staff_id;
                b.Mail = a.staff_mail;
                b.Name = a.staff_name;
                b.Phone = a.staff_phoneNo;
                b.Status_staff = a.staff_status;
                if (a.staff_gender.Equals("female") == true)
                {
                    b.Gender = "Nữ";
                }
                else
                {
                    b.Gender = "Nam";
                }
                // b.Gender = a.staff_gender;
                b.Birtday = a.staff_birthdate;
                list_stf.Add(b);
            }

            return list_stf;
        }

        public List<Cls_Staff> Search_staff(string id_DPM, string conten_tsearch, string option_search)
        {
            List<Cls_Staff> list_result = new List<Cls_Staff>();

            if (option_search.ToLower().Equals("mã số nhân viên") == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Equals(id_DPM.Trim().ToLower()) == true
                                           && a.staff_id.Contains(conten_tsearch.Trim().ToLower()) == true
                                           select a
                                       ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            else if (option_search.ToLower().Equals("tên nhân viên") == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Equals(id_DPM.Trim().ToLower()) == true
                                           && a.staff_name.Contains(conten_tsearch.Trim().ToLower()) == true
                                           select a
                                      ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }
            else if (option_search.ToLower().Equals("địa chỉ") == true)
            {
                IEnumerable<Staff> l_ct = (from a in DB.Staffs
                                           join b in DB.Staff_Contracts
                                           on a.staff_id equals b.staff_id
                                           join c in DB.Contracts
                                           on b.contract_id equals c.contract_id
                                           join d in DB.Departments
                                           on c.dept_id equals d.dept_id
                                           where d.dept_id.Equals(id_DPM.Trim().ToLower()) == true
                                           && a.staff_address.Contains(conten_tsearch.Trim().ToLower()) == true
                                           select a
                                      ).ToList<Staff>();
                foreach (Staff a in l_ct)
                {
                    Cls_Staff b = new Cls_Staff();
                    b.Address = a.staff_address;
                    b.Id_staff = a.staff_id;
                    b.Mail = a.staff_mail;
                    b.Name = a.staff_name;
                    b.Phone = a.staff_phoneNo;
                    b.Status_staff = a.staff_status;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        b.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        b.Gender = "Nam";
                    }
                    b.Birtday = a.staff_birthdate;
                    list_result.Add(b);
                }
            }

            return list_result;
        }

        public int genaration_id_new_staff()
        {
            int id = 0;
            int id_temp = 0;
            IEnumerable<Staff> l_id = (from a in DB.Staffs
                                       select a).ToList<Staff>();
            foreach (Staff a in l_id)
            {
                id_temp = int.Parse(a.staff_id);
            }
            id = ++id_temp;
            return id;

        }

        public bool InsertOnSubmitChange_nhanvien(Cls_Staff innit_staff)
        {
            try
            {
                Staff nstaff = new Staff();
                nstaff.staff_id = innit_staff.Id_staff;
                nstaff.staff_name = innit_staff.Name;
                nstaff.staff_mail = innit_staff.Mail;
                nstaff.staff_gender = innit_staff.Gender;
                nstaff.staff_phoneNo = innit_staff.Phone;
                nstaff.staff_status = innit_staff.Status_staff;
                nstaff.staff_birthdate = innit_staff.Birtday;
                nstaff.staff_address = innit_staff.Address;
                DB.Staffs.InsertOnSubmit(nstaff);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                //throw;
            }
            return false;
        }

        public bool InsertOnsubmitChange_staff_contract(Cls_StaffContract cls_staffcontract)
        {
            try
            {
                Staff_Contract st_ct = new Staff_Contract();
                st_ct.contract_id = cls_staffcontract.Id_contract;
                st_ct.staff_id = cls_staffcontract.Id_staff;
                DB.Staff_Contracts.InsertOnSubmit(st_ct);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                //throw;
            }
            return false;
        }

        public bool DeleteOnSubmitChange_staff(string id_staff_del)
        {
            Staff del = DB.Staffs.Where(x => x.staff_id.Equals(id_staff_del.Trim()) == true).FirstOrDefault();
            if (del != null)
            {
                try
                {
                    DB.Staffs.DeleteOnSubmit(del);
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            return false;
        }

        public bool DeleteOnSubmitChange_staff_contract(string id_contract_del, string id_staff_del)
        {
            Staff_Contract del = DB.Staff_Contracts.Where(x => x.contract_id.Equals(id_contract_del.Trim()) == true).Where(x => x.staff_id.Equals(id_staff_del.Trim()) == true).FirstOrDefault();
            if (del != null)
            {
                try
                {
                    DB.Staff_Contracts.DeleteOnSubmit(del);
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                    //  throw;
                }
            }
            return false;
        }


        public bool UpdateOnSubmitChange_staff(Cls_Staff innit_staff)
        {
            Staff upd = DB.Staffs.Where(x => x.staff_id.Equals(innit_staff.Id_staff.Trim()) == true).FirstOrDefault();
            if (upd != null)
            {
                try
                {

                    upd.staff_name = innit_staff.Name;
                    upd.staff_mail = innit_staff.Mail;
                    upd.staff_phoneNo = innit_staff.Phone;
                    upd.staff_address = innit_staff.Address;
                    upd.staff_gender = innit_staff.Gender;
                    upd.staff_birthdate = innit_staff.Birtday;
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                    //throw;
                }
            }

            return false;
        }

        public List<Cls_Staff> result_staff(string option, string content)
        {
            //{ "lựa chọn", "mã số nhân viên", "tên nhân viên", "địa chỉ email", "địa chỉ", "ngày sinh", "số điện thoại" };
            List<Cls_Staff> result = new List<Cls_Staff>();
            if(option.Equals("mã số nhân viên") == true)
            {
                IEnumerable<Staff> rs = DB.Staffs.Where(x => x.staff_id.Contains(content) == true);
                foreach(Staff a in rs)
                {
                    Cls_Staff st = new Cls_Staff();
                    st.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        st.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        st.Gender = "Nam";
                    }
                    st.Id_staff = a.staff_id;
                    st.Name = a.staff_name;
                    st.Phone = a.staff_phoneNo;
                    st.Mail = a.staff_mail;
                    st.Address = a.staff_address;
                    st.Status_staff = a.staff_status;
                    result.Add(st);
                    
                }
            }
            else if (option.Equals("tên nhân viên") == true)
            {
                IEnumerable<Staff> rs = DB.Staffs.Where(x => x.staff_name.Contains(content) == true);
                foreach (Staff a in rs)
                {
                    Cls_Staff st = new Cls_Staff();
                    st.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        st.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        st.Gender = "Nam";
                    }
                    st.Id_staff = a.staff_id;
                    st.Name = a.staff_name;
                    st.Phone = a.staff_phoneNo;
                    st.Mail = a.staff_mail;
                    st.Address = a.staff_address;
                    st.Status_staff = a.staff_status;
                    result.Add(st);

                }
            }
            else if (option.Equals("số điện thoại") == true)
            {
                IEnumerable<Staff> rs = DB.Staffs.Where(x => x.staff_phoneNo.Contains(content) == true);
                foreach (Staff a in rs)
                {
                    Cls_Staff st = new Cls_Staff();
                    st.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        st.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        st.Gender = "Nam";
                    }
                    st.Id_staff = a.staff_id;
                    st.Name = a.staff_name;
                    st.Phone = a.staff_phoneNo;
                    st.Mail = a.staff_mail;
                    st.Address = a.staff_address;
                    st.Status_staff = a.staff_status;
                    result.Add(st);

                }
            }
            else if (option.Equals("địa chỉ email") == true)
            {
                IEnumerable<Staff> rs = DB.Staffs.Where(x => x.staff_mail.Contains(content) == true);
                foreach (Staff a in rs)
                {
                    Cls_Staff st = new Cls_Staff();
                    st.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        st.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        st.Gender = "Nam";
                    }
                    st.Id_staff = a.staff_id;
                    st.Name = a.staff_name;
                    st.Phone = a.staff_phoneNo;
                    st.Mail = a.staff_mail;
                    st.Address = a.staff_address;
                    st.Status_staff = a.staff_status;
                    result.Add(st);

                }
            }
            else if (option.Equals("địa chỉ") == true)
            {
                IEnumerable<Staff> rs = DB.Staffs.Where(x => x.staff_address.Contains(content) == true);
                foreach (Staff a in rs)
                {
                    Cls_Staff st = new Cls_Staff();
                    st.Birtday = a.staff_birthdate;
                    if (a.staff_gender.Trim().Equals("female") == true)
                    {
                        st.Gender = "Nữ";
                    }
                    else if (a.staff_gender.Trim().Equals("male") == true)
                    {
                        st.Gender = "Nam";
                    }
                    st.Id_staff = a.staff_id;
                    st.Name = a.staff_name;
                    st.Phone = a.staff_phoneNo;
                    st.Mail = a.staff_mail;
                    st.Address = a.staff_address;
                    st.Status_staff = a.staff_status;
                    result.Add(st);

                }
            }
           
         

            return result;
        }

    }
}
