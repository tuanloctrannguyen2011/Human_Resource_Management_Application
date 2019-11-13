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
    public class Cls_account_BUS
    {
        Cls_account_DAL Cls_account_DAL1;

        public Cls_account_BUS()
        {
            Cls_account_DAL1 = new Cls_account_DAL();

        }
        public bool Check_ID_DAL(string id)
        {
            return Cls_account_DAL1.Check_ID(id);
        }
        public bool Check_PASS_DAL(string id, string pass)
        {
            return Cls_account_DAL1.Check_PASS(id, pass);
        }

        public Cls_Account Get_information_dn_DAL(string id, string pass)
        {
            return Cls_account_DAL1.Get_information_dn(id, pass);
        }
        public List<Cls_Account> Get_List_Acc_BUS(string id_curent)
        {
            return Cls_account_DAL1.Get_List_Acc(id_curent);
        }
        public List<Cls_Account> Get_QuyenHan_to_ThongTinTK_BUS()
        {
            return Cls_account_DAL1.Get_QuyenHan_to_ThongTinTK();
        }
        public int UpdateOnSubmitChange_quyenhan_BUS(string id, string quyenhan)
        {
            if (Cls_account_DAL1.UpdateOnSubmitChange_quyenhan(id, quyenhan) == 1)
                return 1;
            return 0;
        }


        public List<Cls_Account> Search_follow_name_BUS(string name)
        {
            return Cls_account_DAL1.Search_follow_name(name);
        }
        public List<Cls_Account> Search_follow_id_BUS(string id)
        {
            return Cls_account_DAL1.Search_follow_id(id);
        }
        public bool Check_Timkiem(string data_check)
        {
            List<Cls_Account> chek_name = this.Search_follow_name_BUS(data_check);
            List<Cls_Account> chek_id = this.Search_follow_id_BUS(data_check);
            if (chek_name.Count > 0 || chek_id.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool Check_acc_exists_BUS(string id)
        {
            return Cls_account_DAL1.Check_acc_exists(id);
        }

        public bool Check_Change_Pass(string id, string old_pass, string new_pass, string conf_pass)
        {
            bool check_old_pw = Check_PASS_DAL(id, Cls_validate_login.HashPassword(old_pass));
            bool check_newPW = false;
            if (check_old_pw == true)
            {
                if (new_pass.Equals(conf_pass) == true)
                {
                    check_newPW = true;
                }
                if (check_newPW == true)
                {
                    return true;
                }

            }
            return false;

        }

        public bool Change_Pass(string id, string pass)
        {
            return Cls_account_DAL1.Change_Pass(id, pass);
        }

        public bool insertonsubmit_change_account_BUS(Cls_Account acc)
        {
            return Cls_account_DAL1.insertonsubmit_change_account(acc);
        }
        public Cls_Account Get_account_by_id_BUS(string id)
        {
            return Cls_account_DAL1.Get_account_by_id(id);
        }



        /// <summary>
        /// mode=0 tăng, =1 giảm
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<Cls_Account> Get_List_Acc_Affter_Sort_By_Id_BUS(List<Cls_Account> datasource, int mode)
        {
            return mode == 0 ? (from d in datasource
                                orderby d.Id_acc ascending
                                select d
                ).ToList<Cls_Account>()
                :
                (from d in datasource
                 orderby d.Id_acc descending
                 select d
                ).ToList<Cls_Account>()
                ;

        }
        /// <summary>
        /// mode=0 tăng, =1 giảm
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<Cls_Account> Get_List_Acc_Affter_Sort_By_Role_BUS(List<Cls_Account> datasource, int mode)
        {
            return mode == 0 ? (from d in datasource
                                orderby d.Role_name ascending
                                select d
               ).ToList<Cls_Account>()
               :
               (from d in datasource
                orderby d.Role_name descending
                select d
               ).ToList<Cls_Account>()
               ;
        }

        /// <summary>
        /// lấy danh sách account theo tiêu chí (criteria)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="id_current"></param>
        /// <returns></returns>
        public List<Cls_Account> Get_List_Acc_Affter_Fill(string criteria, string id_current)
        {
            return (from g in Get_List_Acc_BUS(id_current)
                    where g.Role_name.Trim().Equals(criteria)
                    select g).ToList<Cls_Account>();
        }

        public string Get_PASS_by_id_BUS(string id)
        {
            return Cls_account_DAL1.Get_PASS_by_id(id);
        }
    }
}
