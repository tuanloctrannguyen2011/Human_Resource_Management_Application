using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Contracts_DAL
    {
        //Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_Contracts_DAL()
        {
            // DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }
        public Cls_Contract Get_contract(string id)
        {
            Cls_Contract ct = new Cls_Contract();
            Contract ct1 = (from a in DB.Contracts
                            join b in DB.Staff_Contracts
                            on a.contract_id equals b.contract_id
                            join c in DB.Staffs
                            on b.staff_id equals c.staff_id
                            where c.staff_id.Equals(id)==true
                            select a).SingleOrDefault();
            ct.Contract_name = ct1.contract_name;
            ct.Id_contract = ct1.contract_id;
            ct.Id_department = ct1.dept_id;
            ct.Id_job = ct1.job_id;
            ct.Id_shiff = ct1.shift_id;
            ct.End_date = ct1.end_date;
            ct.Salary = ct1.salary;
            ct.Start_date = ct1.begin_date;
            return ct;
        } 
       public void Submit_date_modifine(DateTime? dt, string id)
        {
            Contract ct1 = (from a in DB.Contracts
                            join b in DB.Staff_Contracts
                            on a.contract_id equals b.contract_id
                            join c in DB.Staffs
                            on b.staff_id equals c.staff_id
                            where c.staff_id.Equals(id)==true
                            select a).SingleOrDefault();
            //ct1.end_date = (dt == null) ? (DateTime)System.Data.SqlTypes.SqlDateTime.Null : dt;
            DateTime? dt_test = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
            dt_test = null;
           ct1.end_date = (dt == null) ? dt_test : dt;
            DB.SubmitChanges();
        }

        public int genaration_id_new_contract()
        {
            int id = 0;
            int id_temp = 0;
            IEnumerable<Contract> l_id = (from a in DB.Contracts
                                       select a).ToList<Contract>();
            foreach (Contract a in l_id)
            {
                id_temp = int.Parse(a.contract_id);
            }
            id = ++id_temp;
            return id;

        }

        public bool InsertOnSubmit_Change_contract(Cls_Contract contract)
        {

            try
            {
                Contract a = new Contract();
                a.contract_id = contract.Id_contract;
                a.contract_name = contract.Contract_name;
                a.dept_id = contract.Id_department;
                a.job_id = contract.Id_job;
                a.shift_id = contract.Id_shiff;
                a.begin_date = contract.Start_date;
                a.salary = contract.Salary;
                DB.Contracts.InsertOnSubmit(a);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

               // throw;
            }
            return false;
        }

        public bool UpdateOnSubmitchange_contract(Cls_Contract contract)
        {
            Contract ct_upd = DB.Contracts.Where(x=>x.contract_id.Trim().Equals(contract.Id_contract.Trim())==true).FirstOrDefault();
            if (ct_upd != null)
            {
                try
                {
                    ct_upd.begin_date = contract.Start_date;
                    ct_upd.contract_id = contract.Id_contract;
                    ct_upd.contract_name = contract.Contract_name;
                    ct_upd.dept_id = contract.Id_department;
                    ct_upd.job_id = contract.Id_job;
                    ct_upd.shift_id = contract.Id_shiff;
                    ct_upd.salary = contract.Salary;
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
            
        public bool DeleteOnsubmitChange_contract(string id_contract_del)
        {
            Contract del = DB.Contracts.Where(x => x.contract_id.Equals(id_contract_del.Trim()) == true).FirstOrDefault();
            if (del != null)
            {
                try
                {
                    DB.Contracts.DeleteOnSubmit(del);
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                   // throw;
                }
            }
            return false;
        }

         
    }
}
