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
    public class Cls_JobTitle_BUS
    {
        Cls_JobTitle_DAL cls_jobtitle_DAL1; 
        public Cls_JobTitle_BUS()
        {
            cls_jobtitle_DAL1 = new Cls_JobTitle_DAL();
        }
        public Cls_JobTitle Get_jobtitle_BUS(string id)
        {
            return cls_jobtitle_DAL1.Get_jobtitle(id);
        }

        public List<Cls_JobTitle> Get_list_job_title_BUS()
        {
            return cls_jobtitle_DAL1.Get_list_job_title();
        }


        public List<Cls_JobTitle> Get_All_jobTitle_BUS()
        {
            return cls_jobtitle_DAL1.Get_All_jobtitle();
        }

        public bool Delete_job_BUS(string id)
        {
            return cls_jobtitle_DAL1.Delete_job_DAL(id);
        }

        public bool them_job_BUS(Cls_JobTitle job)
        {
            return cls_jobtitle_DAL1.them_job_DAL(job);
        }

        public bool sua_job_BUS(Cls_JobTitle job)
        {
            return cls_jobtitle_DAL1.sua_job_DAL(job);
        }

        public string genaration_id_new_jobtitle_BUS()
        {

            string id = "";
            int check = cls_jobtitle_DAL1.genaration_id_new_jobtitle();
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

        public bool Check_Jobtitle_Allow_Modifile_BUS(string id_job_md)
        {
            return cls_jobtitle_DAL1.Check_Jobtitle_Allow_Modifile(id_job_md);
        }

        public List<Cls_JobTitle> Search_jobtitle_BUS(string content)
        {
            return cls_jobtitle_DAL1.Search_jobtitle(content);
        }

    }
}
