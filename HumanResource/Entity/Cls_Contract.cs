using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Contract
    {
        private string contract_name, id_contract, id_shiff, id_job, id_department;
        private DateTime start_date;
        private Nullable<DateTime> end_date;
        private int salary;

        public string Contract_name { get => contract_name; set => contract_name = value; }
        public string Id_contract { get => id_contract; set => id_contract = value; }
        public string Id_shiff { get => id_shiff; set => id_shiff = value; }
        public string Id_job { get => id_job; set => id_job = value; }
        public string Id_department { get => id_department; set => id_department = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public Nullable<DateTime> End_date { get => end_date; set => end_date = value; }
        public int Salary { get => salary; set => salary = value; }

        public Cls_Contract()
        {

        }
        public Cls_Contract( string CT_N, string ID_C, string ID_SH,  string ID_J, string ID_DP, DateTime S_DATE, Nullable<DateTime> E_DATE, int SA_L)
        {
            this.Id_contract = ID_C;
            this.Contract_name = CT_N;
            this.Id_shiff = ID_SH;
            this.Id_job = ID_J;
            this.Id_department = ID_DP;
            this.Start_date = S_DATE;
            this.End_date = E_DATE;
            this.Salary = SA_L;
        }
    }
}
