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
    public class Cls_Contract_BUS
    {
        Cls_Contracts_DAL cls_contract_DAL1;
        public Cls_Contract_BUS()
        {
            cls_contract_DAL1 = new Cls_Contracts_DAL();
        }
        public Cls_Contract Get_contract_BUS(string id)
        {
            return cls_contract_DAL1.Get_contract(id);
        }
        public void Submit_date_modifine_BUS(DateTime? dt, string id)
        {
            cls_contract_DAL1.Submit_date_modifine(dt, id);
        }

        public string genaration_id_new_contract_BUS()
        {

            string id = "";
            int check = cls_contract_DAL1.genaration_id_new_contract();
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

        public bool InsertOnSubmit_Change_contract_BUS(Cls_Contract contract)
        {
            if (contract.Id_contract != null || contract.Id_department != null || contract.Id_job != null || contract.Id_shiff != null || contract.Salary == 0 || contract.Start_date != null)
            {
                if (contract.Id_contract.Trim().Equals("") != true || contract.Id_department.Trim().Equals("") != true || contract.Id_job.Trim().Equals("") != true || contract.Id_shiff.Trim().Equals("") != true || contract.Salary == 0 || contract.Start_date != null)
                {
                    return cls_contract_DAL1.InsertOnSubmit_Change_contract(contract);
                }
            }


            return false;

        }

        public bool UpdateOnSubmitchange_contract_BUS(Cls_Contract contract)
        {
            if (contract.Id_contract != null || contract.Id_department != null || contract.Id_job != null || contract.Id_shiff != null || contract.Salary == 0 || contract.Start_date != null)
            {
                if (contract.Id_contract.Trim().Equals("") != true || contract.Id_department.Trim().Equals("") != true || contract.Id_job.Trim().Equals("") != true || contract.Id_shiff.Trim().Equals("") != true || contract.Salary == 0 || contract.Start_date != null)
                {
                    return cls_contract_DAL1.UpdateOnSubmitchange_contract(contract);
                }
            }
            return false;
        }

        public bool DeleteOnsubmitChange_contract_BUS(string id_contract_del)
        {
            return cls_contract_DAL1.DeleteOnsubmitChange_contract(id_contract_del);
        }
    }
}
