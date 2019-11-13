using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using DevOne.Security.Cryptography.BCrypt;

namespace Business
{
    public class Cls_Department_BUS
    {
        Cls_Department_DAL cls_department_DAL1;
        Cls_Staffs_BUS cls_staff_BUS1;
        public Cls_Department_BUS()
        {
            cls_department_DAL1 = new Cls_Department_DAL();
            cls_staff_BUS1 = new Cls_Staffs_BUS();
        }
        public Cls_Department Get_department_BUS(string id)
        {
            return cls_department_DAL1.Get_department(id);
        }
        public List<Cls_Department> Get_list_department_BUS()
        {
            return cls_department_DAL1.Get_list_department();
        }
        public bool Check_before_search(string option_search, string content_search)
        {
            if(option_search.Equals("")!=true)
            {
                if (content_search.Equals("") != true)
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
        public List<Cls_Department> Search_department_BUS(string content_search)
        {
            return cls_department_DAL1.Search_department(content_search);
        }
        public bool Check_affter_search(List<Cls_Department> list_result)
        {
            int count = list_result.Count;
            if (count > 0)
            {
                return true;

            }
            return false;
        }
        public string id_department_generation_BUS()
        {
            string id = "";
            double check=cls_department_DAL1.id_department_generation();
            double d = check.ToString().Length;
   
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
       
        public bool Check_exist_id_BUS(List<Cls_Department> l_dp,string id_check)
        {
          
            foreach (Cls_Department a in l_dp)
            {
                if(a.Id_dp.Equals(id_check) == true)
                {
                    return false;
                }
            }
            return true;
        }
        public bool Check_exitst_name_BUS(List<Cls_Department> l_dp, string name_depart)
        {
            foreach (Cls_Department a in l_dp)
            {
                if (a.Name_dp.Trim().ToLower().Equals(name_depart.Trim().ToLower()) == true)
                {
                    return false;
                }
            }
            return true;
        }

        public bool InsertOnSubmitChange_department_BUS(Cls_Department dpm)
        {
            return cls_department_DAL1.InsertOnSubmitChange_department(dpm);
        }
        public bool Update_information_department_BUS(Cls_Department dpm)
        {
            return cls_department_DAL1.Update_information_department(dpm);
        }

        public bool Check_empty_department_BUS(string id_dpm_del)
        {
            int total_staff_in_dpm = cls_staff_BUS1.Get_list_staff_by_Id_department_BUS(id_dpm_del).Count;
            if (total_staff_in_dpm > 0)
            {
                return false;
            }
            
            return true;
        }

        public bool Delete_department_BUS(Cls_Department dpm)
        {
            return cls_department_DAL1.Delete_department(dpm);
        }
    }
}
