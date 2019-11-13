using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Department_DAL
    {
        //Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_Department_DAL()
        {
            //DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }
       public Cls_Department Get_department(string id)
        {
            Cls_Department dp = new Cls_Department();
            Department dp1 = (
                from a in DB.Departments
                join b in DB.Contracts
                on a.dept_id equals b.dept_id
                join c in DB.Staff_Contracts
                on b.contract_id equals c.contract_id
                join d in DB.Staffs
                on c.staff_id equals d.staff_id
                where (d.staff_id.Equals(id)==true)
                select a ).SingleOrDefault();
            dp.Id_dp = dp1.dept_id;
            dp.Name_dp = dp1.dept_name;
            return dp;
        }

       public List<Cls_Department> Get_list_department()
        {
            List<Cls_Department> list_department = new List<Cls_Department>();
            IEnumerable<Department> l_dp = DB.Departments.ToList<Department>();
            foreach(Department a in l_dp)
            {
                Cls_Department b = new Cls_Department();
                b.Id_dp = a.dept_id;
                b.Name_dp = a.dept_name;
                list_department.Add(b);
            }
            return list_department;
        }
       public List<Cls_Department> Search_department(string content_search)
        {
            List<Cls_Department> list_result = new List<Cls_Department>();
            IEnumerable<Department> l_dp = (from x in DB.Departments
                                            where x.dept_id.Contains(content_search)==true ||                                  x.dept_name.Contains(content_search)==true
                                            select x).ToList<Department>();
            foreach(Department a in l_dp)
            {
                Cls_Department a1 = new Cls_Department();
                a1.Id_dp = a.dept_id;
                a1.Name_dp = a.dept_name;
                list_result.Add(a1);
            }

            return list_result;
        }

        
        public double id_department_generation()
        {
            //string new_id_department = "";
            double id = 0;
            double id_temp = 0;
            IEnumerable<Department> l_id = (from a in DB.Departments
                                            //where a.dept_id.Max
                                            select a).ToList<Department>();
            foreach (Department a in l_id)
            {
                id_temp = double.Parse(a.dept_id);
            }
            id = ++id_temp;
            return id;
        }
        public bool InsertOnSubmitChange_department(Cls_Department dpm)
        {

            try
            {
                Department dp_new = new Department();
                dp_new.dept_id = dpm.Id_dp;
                dp_new.dept_name = dpm.Name_dp;
                DB.Departments.InsertOnSubmit(dp_new);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }

            //return false;
        }

        public bool Update_information_department(Cls_Department dpm)
        {
            Department dpm1 = (from a in DB.Departments
                               where a.dept_id.Trim().Equals(dpm.Id_dp.Trim()) == true
                               select a).SingleOrDefault();
            if (dpm1 != null)
            {
                try
                {
                    dpm1.dept_id = dpm.Id_dp;
                    dpm1.dept_name = dpm.Name_dp;
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                    
                }
            }
            return false;

        }

        public bool Delete_department(Cls_Department dpm)
        {
            Department dpm_del = DB.Departments.Where(x => x.dept_id.Trim().Equals(dpm.Id_dp.Trim()) == true).SingleOrDefault();
            if (dpm_del != null)
            {
                try
                {
                    DB.Departments.DeleteOnSubmit(dpm_del);
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                   
                }
            }
            return false;
        }
    }
}
