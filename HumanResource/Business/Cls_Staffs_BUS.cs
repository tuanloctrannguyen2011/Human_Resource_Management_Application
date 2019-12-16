using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Business
{
    public class Cls_Staffs_BUS
    {
        Cls_Staffs_DAL cls_staffs_DAL1;
        public Cls_Staffs_BUS()
        {
            cls_staffs_DAL1 = new Cls_Staffs_DAL();
        }
        public List<Cls_Staff> Get_list_staff_BUS()
        {
            return cls_staffs_DAL1.Get_list_staff();
        }
        public List<Cls_Staff> Get_list_staffs_Inactive_BUS(string id_curent)
        {
            return cls_staffs_DAL1.Get_list_staffs_Inactive(id_curent);
        }
        public List<Cls_Staff> Get_list_staffs_Active_BUS(string id_curent)
        {
            return cls_staffs_DAL1.Get_list_staffs_Active(id_curent);
        }
        public void SubmitChange_DataGridview__active_BUS(Cls_Staff a)
        {
            cls_staffs_DAL1.SubmitChange_DataGridview_active(a);
        }
        public Cls_Staff Get_staff_BUS(string id)
        {
            return cls_staffs_DAL1.Get_staff(id);
        }

        public bool Check_before_search_BUS(string option, string content_search)
        {
            if (option != null)
            {
                if (content_search != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public List<Cls_Staff> Search_staff_BUS(string option, string content_search, bool status)
        {
            List<Cls_Staff> list_staff = new List<Cls_Staff>();
            bool check = Check_before_search_BUS(option, content_search);
            if (check == true)
            {

                if (option.Equals("Tên Phòng ban") == true)
                {

                    list_staff = cls_staffs_DAL1.Search_by_name_department(content_search, status);


                }
                else if (option.Equals("Mã số phòng ban") == true)
                {
                    list_staff = cls_staffs_DAL1.Search_by_id_department(content_search, status);
                }
                else if (option.Equals("Tên nhân viên") == true)
                {
                    list_staff = cls_staffs_DAL1.Search_by_name_staff(content_search, status);
                }
                else if (option.Equals("Mã số nhân viên") == true)
                {
                    list_staff = cls_staffs_DAL1.Search_by_id_staff(content_search, status);
                }

            }
            return list_staff;
        }

        public bool Check_after_search_BUS(List<Cls_Staff> list_result)
        {
            if (list_result.Count > 0)
            {
                return true;
            }
            return false;

        }
        public List<Cls_Staff> Get_list_staff_by_Id_department_BUS(string id)
        {
            return cls_staffs_DAL1.Get_list_staff_by_Id_department(id);
        }
        /// <summary>
        /// tìm kiếm một nhân viên của bất kì thuộc phòng ban hiện tại
        /// </summary>
        /// <param name="mã số của phòng ban hiện tại"></param>
        /// <param name=" nội dung tìm kiếm bất kì "></param>
        /// <param name="tiêu chí tìm kiếm "></param>
        /// <returns></returns>
        public List<Cls_Staff> Search_staff(string id_DPM, string conten_tsearch, string option_search)
        {
            return cls_staffs_DAL1.Search_staff(id_DPM, conten_tsearch, option_search);
        }


        public string genaration_id_new_staff_BUS()
        {

            string id = "";
            int check = cls_staffs_DAL1.genaration_id_new_staff();
            int d = check.ToString().Length;

            if (d == 1)
            {
                id = "000000000" + check.ToString();

            }
            if (d == 2)
            {
                id = "00000000" + check.ToString();

            }
            if (d == 3)
            {
                id = "0000000" + check.ToString();

            }
            if (d == 4)
            {
                id = "000000" + check.ToString();

            }
            if (d == 5)
            {
                id = "00000" + check.ToString();

            }
            if (d == 6)
            {
                id = "0000" + check.ToString();

            }
            if (d == 7)
            {
                id = "000" + check.ToString();

            }
            if (d == 8)
            {
                id = "00" + check.ToString();

            }
            if (d == 9)
            {
                id = "0" + check.ToString();

            }
            if (d > 10)
            {
                id = "";
            }
            return id;
        }

        public bool InsertOnSubmitChange_nhanvien_BUS(Cls_Staff innit_staff)
        {
            if (innit_staff.Id_staff != null || innit_staff.Name != null || innit_staff.Phone != null || innit_staff.Mail != null || innit_staff.Gender != null || innit_staff.Address != null || innit_staff.Birtday != null)
            {
                if (innit_staff.Id_staff.Trim().Equals("") == false || innit_staff.Name.Trim().Equals("") == false || innit_staff.Phone.Trim().Equals("") == false || innit_staff.Mail.Trim().Equals("") == false || innit_staff.Gender.Trim().Equals("") == false || innit_staff.Address.Trim().Equals("") == false)
                {
                    return cls_staffs_DAL1.InsertOnSubmitChange_nhanvien(innit_staff);
                }
            }
            return false;
        }

        public bool InsertOnsubmitChange_staff_contract_BUS(Cls_StaffContract cls_staffcontract)
        {
            return cls_staffs_DAL1.InsertOnsubmitChange_staff_contract(cls_staffcontract);
        }

        public bool DeleteOnSubmitChange_staff(string id_staff_del)
        {

            return cls_staffs_DAL1.DeleteOnSubmitChange_staff(id_staff_del);
        }

        public bool DeleteOnSubmitChange_staff_contract_BUS(string id_contract_del, string id_staff_del)
        {
            return cls_staffs_DAL1.DeleteOnSubmitChange_staff_contract(id_contract_del, id_staff_del);
        }

        public bool UpdateOnSubmitChange_staff_BUS(Cls_Staff innit_staff)
        {
            return cls_staffs_DAL1.UpdateOnSubmitChange_staff(innit_staff);
        }

        public List<Cls_Staff> result_staff_BUS(string option, string content)
        {
            return cls_staffs_DAL1.result_staff(option,content);
        }

        public List<Cls_Staff> Get_list_staff_load_form_BUS(string id_curent)
        {
            return cls_staffs_DAL1.Get_list_staff_load_form(id_curent);
        }
    }
}
