using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_JobTitle_DAL
    {
        // Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_JobTitle_DAL()
        {
            // DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }
        public Cls_JobTitle Get_jobtitle(string id)
        {
            Cls_JobTitle jb = new Cls_JobTitle();
            JobTitle jb1 = (from a in DB.JobTitles
                            join b in DB.Contracts
                            on a.job_id equals b.job_id
                            join c in DB.Staff_Contracts
                            on b.contract_id equals c.contract_id
                            join d in DB.Staffs
                            on c.staff_id equals d.staff_id
                            where d.staff_id.Equals(id) == true
                            select a).SingleOrDefault();

            jb.Id_job = jb1.job_id;
            jb.Name_job = jb1.job_name;
            jb.Des_job = jb1.job_desc;
            return jb;
        }

        public List<Cls_JobTitle> Get_list_job_title()
        {
            IEnumerable<JobTitle> l_jb = DB.JobTitles;
            List<Cls_JobTitle> list_job = new List<Cls_JobTitle>();
            foreach (JobTitle a in l_jb)
            {
                Cls_JobTitle jb = new Cls_JobTitle();
                jb.Des_job = a.job_desc;
                jb.Id_job = a.job_id;
                jb.Name_job = a.job_name;
                list_job.Add(jb);
            }
            return list_job;
        }


        public List<Cls_JobTitle> Get_All_jobtitle()
        {

            List<Cls_JobTitle> list = new List<Cls_JobTitle>();

            List<JobTitle> job = (from a in DB.JobTitles
                                  select a).ToList<JobTitle>();


            foreach (JobTitle item in job)
            {
                list.Add(new Cls_JobTitle(item.job_id, item.job_name, item.job_desc));
            }

            return list;
        }


        public bool Delete_job_DAL(string id)
        {
            JobTitle item = DB.JobTitles.Where(x => x.job_id.Trim().Equals(id.Trim())).FirstOrDefault();
            if (item == null)
            {
                return false;
            }
            try
            {
                DB.JobTitles.DeleteOnSubmit(item);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool them_job_DAL(Cls_JobTitle job)
        {
            if (job == null)
            {
                return false;
            }
            DB.JobTitles.InsertOnSubmit(new JobTitle() { job_desc = job.Des_job, job_id = job.Id_job, job_name = job.Name_job });
            try
            {
                DB.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool sua_job_DAL(Cls_JobTitle job)
        {
            if (job == null)
            {
                return false;
            }
            JobTitle job1 = DB.JobTitles.Where(x => x.job_id.Trim().Equals(job.Id_job.Trim())).FirstOrDefault();
            if (job1 == null)
            {
                return false;
            }

            job1.job_name = job.Name_job;
            job1.job_desc = job.Des_job;
            try
            {
                DB.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int genaration_id_new_jobtitle()
        {
            int id = 0;
            int id_temp = 0;
            IEnumerable<JobTitle> l_id = (from a in DB.JobTitles
                                          select a).ToList<JobTitle>();
            foreach (JobTitle a in l_id)
            {
                id_temp = int.Parse(a.job_id);
            }
            id = ++id_temp;
            return id;

        }

        public bool Check_Jobtitle_Allow_Modifile(string id_job_md)
        {
            JobTitle jb = (from a in DB.JobTitles
                           join b in DB.Contracts
                           on a.job_id equals b.job_id
                           join c in DB.Staff_Contracts
                           on b.contract_id equals c.contract_id
                           join d in DB.Staffs
                           on c.staff_id equals d.staff_id
                           where a.job_id.Trim().Equals(id_job_md.Trim()) == true
                           select a).FirstOrDefault();
            return true ? (jb == null) : false;
        }

        public List<Cls_JobTitle> Search_jobtitle(string content)
        {
            List<Cls_JobTitle> l_jb = new List<Cls_JobTitle>();
            List<JobTitle> resul1 = (from a in DB.JobTitles
                                     where
                                     a.job_id.Trim().ToLower().Contains(content.Trim().ToLower()) == true
                                     ||
                                     a.job_id.Trim().ToLower().Contains(content.Trim().ToLower()) == true
                                     select a

                                     ).ToList<JobTitle>();

            if (resul1 != null)
            {
                foreach (JobTitle a in resul1)
                {
                    Cls_JobTitle jb = new Cls_JobTitle();
                    jb.Des_job = a.job_desc;
                    jb.Id_job = a.job_id;
                    jb.Name_job = a.job_name;
                    l_jb.Add(jb);
                }
            }
            return l_jb;
        }
    }
}
