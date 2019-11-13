using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_JobTitle
    {
        private string id_job, name_job, des_job;

        public string Id_job { get => id_job; set => id_job = value; }
        public string Name_job { get => name_job; set => name_job = value; }
        public string Des_job { get => des_job; set => des_job = value; }

        public Cls_JobTitle()
        {

        }
        public Cls_JobTitle(string ID_JOB, string NAME_JOB,string DES_JOB)
        {
            this.Id_job = ID_JOB;
            this.Name_job = NAME_JOB;
            this.Des_job = DES_JOB;
        }
    }
}
