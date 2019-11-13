using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_TongHop_DAL
    {
       // Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_TongHop_DAL()
        {
            // DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }


        #region //lấy tất cả  thông tin của tài khoản
        /*
        public List<object> Get_ThongTin_TongHop(string ma_tk_check)
        {
      
            List<Cls_TongHop> List_tt = new List<Cls_TongHop>() { };
            //var x = (from a in DB.Accounts
            //         join b in DB.Staffs
            //         on a.acc_id equals b.staff_id
            //         join c in DB.Staff_Contracts
            //         on b.staff_id equals c.staff_id
            //         join d in DB.Contracts
            //         on c.contract_id equals d.contract_id
            //         join e in DB.Departments
            //         on d.dept_id equals e.dept_id
            //         join f in DB.JobTitles
            //         on d.job_id equals f.job_id
            //         join g in DB.Shifts
            //         on d.shift_id equals g.shift_id
            //         join h in DB.Evaluations
            //         on b.staff_id equals h.staff_id
            //         where a.acc_id.Equals(ma_tk_check.Trim()) == true
            //         select new Cls_TongHop
            //         {

            //             Acc = new Cls_Account() { Id_acc = a.acc_id, Password = a.password, Role_name = a.role_name },

            //             Stf = new Cls_Staff() { Id_staff = b.staff_id, Name = b.staff_name, Address = b.staff_address, Mail = b.staff_mail, Phone = b.staff_phoneNo, Status_staff = b.staff_status },

            //             Stfct = new Cls_StaffContract() { Id_contract = c.contract_id, Id_staff = c.staff_id },

            //             Ct = new Cls_Contract() { Id_contract = d.contract_id, Contract_name = d.contract_name, End_date = (DateTime)d.end_date, Id_department = d.dept_id, Id_job = d.job_id, Id_shiff = d.shift_id, Salary = d.salary, Start_date = (DateTime)d.begin_date },

            //             Dptm = new Cls_Department() { Id_dp = e.dept_id, Name_dp = e.dept_name },

            //             Jbtt = new Cls_JobTitle() { Id_job = f.job_id, Name_job = f.job_name, Des_job = f.job_desc },

            //             Shf = new Cls_Shiff() { Id_shift = g.shift_id, Shiff_time = g.shift_time },

            //             Evel = new Cls_Eveluate() { Id_eva = h.eva_id, Id_staff = h.staff_id, Eva_date = (DateTime)h.eva_date, Eva_desc = h.eva_desc, Eva_type = h.eva_type }


            //             #region// láy đối tượng tổng hợp
            //             //Acc = {Id_acc=a.acc_id,Password=a.password,Role_name=a.role_name },
            //             //Stf = {Id_staff=b.staff_id,Name=b.staff_name,Address=b.staff_address, Mail=b.staff_mail, Phone=b.staff_phoneNo, Status_staff=b.staff_status},
            //             //Stfct= { Id_contract=c.contract_id, Id_staff=c.staff_id },
            //             //Ct= { Id_contract=d.contract_id, Contract_name=d.contract_name, End_date=(DateTime)d.end_date, Id_department=d.dept_id, Id_job=d.job_id, Id_shiff=d.shift_id, Salary=d.salary, Start_date=d.begin_date},
            //             //Dptm = { Id_dp = e.dept_id, Name_dp = e.dept_name },
            //             //Jbtt = { Id_job = f.job_id, Name_job = f.job_name, Des_job = f.job_desc },
            //             //Shf = { Id_shift = g.shift_id, Shiff_time = g.shift_time },
            //             //Evel = { Id_eva = h.eva_id, Id_staff = h.staff_id, Eva_date = (DateTime)h.eva_date, Eva_desc = h.eva_desc, Eva_type = h.eva_type }
            //             #endregion
            //         }).ToList<Cls_TongHop>();

            //foreach (var y in x)
            //{
            //    Cls_TongHop TH = new Cls_TongHop();
            //    TH.Acc = y.Acc;
            //    TH.Ct = y.Ct;
            //    TH.Dptm = y.Dptm;
            //    TH.Evel = y.Evel;
            //    TH.Jbtt = y.Jbtt;
            //    TH.Shf = y.Shf;
            //    TH.Stf = y.Stf;
            //    TH.Stfct = y.Stfct;
            //    List_tt.Add(TH);
            //}

            //return List_tt;


            var x = (from a in DB.Accounts
                     join b in DB.Staffs
                     on a.acc_id.Trim() equals b.staff_id.Trim()
                     join c in DB.Staff_Contracts
                     on b.staff_id.Trim() equals c.staff_id.Trim()
                     join d in DB.Contracts
                     on c.contract_id.Trim() equals d.contract_id.Trim()
                     join e in DB.Departments
                     on d.dept_id.Trim() equals e.dept_id.Trim()
                     join f in DB.JobTitles
                     on d.job_id.Trim() equals f.job_id.Trim()
                     join g in DB.Shifts
                     on d.shift_id.Trim() equals g.shift_id.Trim()
                     join h in DB.Evaluations
                     on b.staff_id.Trim() equals h.staff_id.Trim()
                     where a.acc_id.Trim().Equals(ma_tk_check.Trim()) == true
                     select new
                     {

                         Id_acc = a.acc_id, Password = a.password, Role_name = a.role_name,

                         Id_staff = b.staff_id, Name = b.staff_name, Address = b.staff_address, Mail = b.staff_mail, Phone = b.staff_phoneNo, Status_staff = b.staff_status,

                     }
                     ).ToList<object>();

            return x;
        }
        */

        #endregion



        public List<Cls_Department> Get_list_dpm(string Id_acc)
        {
            List<Cls_Department> Ldpm = new List<Cls_Department>();
            IQueryable<Department> a = (from b in DB.Departments
                                        join c in DB.Contracts
                                        on b.dept_id equals c.dept_id
                                        join d in DB.Staff_Contracts
                                        on c.contract_id equals d.contract_id
                                        join e in DB.Staffs
                                        on d.staff_id equals e.staff_id
                                        join f in DB.Accounts
                                        on e.staff_id equals f.acc_id
                                        where f.acc_id.Equals(Id_acc) == true
                                        select b);
            foreach (Department x in a)
            {
                Cls_Department x1 = new Cls_Department();
                x1.Id_dp = x.dept_id;
                x1.Name_dp = x.dept_name;
                Ldpm.Add(x1);
            }
            return Ldpm;
        }

        public List<Cls_JobTitle> Get_list_job(string Id_acc)
        {
            List<Cls_JobTitle> Ljbtt = new List<Cls_JobTitle>();
            IQueryable<JobTitle> a = (from b in DB.JobTitles
                                      join c in DB.Contracts
                                      on b.job_id equals c.job_id
                                      join d in DB.Staff_Contracts
                                      on c.contract_id equals d.contract_id
                                      join e in DB.Staffs
                                      on d.staff_id equals e.staff_id
                                      join f in DB.Accounts
                                      on e.staff_id equals f.acc_id
                                      where f.acc_id.Equals(Id_acc) == true
                                      select b);
            foreach (JobTitle x in a)
            {
                Cls_JobTitle x1 = new Cls_JobTitle();
                x1.Id_job = x.job_id;
                x1.Name_job = x.job_name;
                Ljbtt.Add(x1);
            }
            return Ljbtt;
        }
        public List<Cls_Staff> Get_list_staff(string Id_acc)
        {
            List<Cls_Staff> Lstf = new List<Cls_Staff>();
            IEnumerable<Staff> a = (from b in DB.Staffs
                                    join c in DB.Staff_Contracts
                                    on b.staff_id equals c.staff_id
                                    join d in DB.Accounts
                                    on b.staff_id equals d.acc_id

                                    where d.acc_id.Equals(Id_acc.Trim())
                                    select b);
            foreach (var x in a)
            {
                Cls_Staff y = new Cls_Staff();

                y.Address = x.staff_address;
                y.Id_staff = x.staff_id;
                y.Mail = x.staff_mail;
                y.Name = x.staff_name;
                y.Phone = x.staff_phoneNo;
                y.Status_staff = x.staff_status;
                y.Birtday = x.staff_birthdate;
                if (x.staff_gender.Trim().ToLower().Equals("female") == true)
                {
                    y.Gender = "Nữ";
                }
                else if (x.staff_gender.Trim().ToLower().Equals("male") == true)
                {
                    y.Gender = "Nam";
                }
                Lstf.Add(y);
            }
            return Lstf;
        }




    }
}
