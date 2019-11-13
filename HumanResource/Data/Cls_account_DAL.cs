using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_account_DAL
    {

       // Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_account_DAL()
        {
            // DB = connect.Get_datacontext();
            DB = new DBDataContext();
        }
        public bool Check_ID(string id)
        {
            Account acc1 = (from a in DB.Accounts
                                         where a.acc_id == id
                                         select a).SingleOrDefault();
            if (acc1!=null)
            {
                return true;
            }
            return false;
        }
        public bool Check_PASS(string id, string pass)
        {
            Account  acc1 = (from a in DB.Accounts
                              where a.password == pass
                              where a.acc_id==id
                              select a).SingleOrDefault();
            if (acc1!=null)
            {
                return true;
            }
            return false;
        }
        public string Get_PASS_by_id(string id)
        {
            string s = "";
            Account acc1 = (from a in DB.Accounts
                            where a.acc_id == id
                            select a).SingleOrDefault();
            if (acc1 != null)
            {
                s = acc1.password;
            }
            return s;
        }

        public Cls_Account Get_information_dn(string id, string pass)
        {
            
            IEnumerable<Account> acc1 = (from a in DB.Accounts
                                         where a.acc_id == id && a.password == pass
                                         select a).AsEnumerable();
            Cls_Account b = new Cls_Account();
            foreach (Account a in acc1)
            {
                b.Id_acc = a.acc_id;
                b.Password = a.password;
                b.Role_name = a.role_name;
            }
            return b;

        }
        public List<Cls_Account> Get_List_Acc(string id_curent)
        {
            List<Cls_Account> List_Acc = new List<Cls_Account>();
            IEnumerable<Account> a = DB.Accounts.Where(x=>x.acc_id.Equals(id_curent.Trim().ToLower()) ==false).AsEnumerable();
            foreach(Account b in a)
            {
                Cls_Account n = new Cls_Account();
                n.Id_acc = b.acc_id;
                n.Password = b.password;
                n.Role_name = b.role_name;
                List_Acc.Add(n);
            }
            return List_Acc;
        }

        public List<Cls_Account> Acc( string id_ac)
        {
            List<Cls_Account> List_Acc = new List<Cls_Account>();
            IEnumerable<Account> a = (from b in DB.Accounts
                                      where b.acc_id.Equals(id_ac) == true
                                      select b);
            foreach (Account b in a)
            {
                Cls_Account n = new Cls_Account();
                n.Id_acc = b.acc_id;
                n.Password = b.password;
                n.Role_name = b.role_name;
                List_Acc.Add(n);
            }
            return List_Acc;
        }


        public List<Cls_Account> Get_QuyenHan_to_ThongTinTK()
        {

            List<Cls_Account> List_tk1 = new List<Cls_Account>();
            IEnumerable<Account> tk1 = DB.Accounts.AsEnumerable();
            foreach (Account a in tk1)
            {
                Cls_Account tk = new Cls_Account();
                tk.Id_acc = a.acc_id;
                tk.Password = a.password;
                tk.Role_name = a.role_name;
                List_tk1.Add(tk);
            }
            return List_tk1;
        }
        public int UpdateOnSubmitChange_quyenhan(string id,string quyenhan)
        {
            Account a = DB.Accounts.Single(x => x.acc_id == id);
            if (a != null)
            {
                a.role_name = quyenhan.Trim();
                DB.SubmitChanges();
            }
            return 1;  
        }

        public List<Cls_Account> Search_follow_name(string name)
        {

            List<Cls_Account> reslut_s = new List<Cls_Account>();
            IQueryable<Account> acc1 = (from a in DB.Staffs
                                        join b in DB.Accounts
                                        on a.staff_id equals b.acc_id
                                        where a.staff_name.Contains(name) == true
                                        select b
                                      );
            foreach (Account a in acc1)
            {
                Cls_Account a1 = new Cls_Account();
                a1.Id_acc = a.acc_id;
                a1.Password = a.password;
                a1.Role_name = a.role_name;
                reslut_s.Add(a1);
            }
            return reslut_s;

        }

        public List<Cls_Account> Search_follow_id(string id)
        {

            List<Cls_Account> reslut_s = new List<Cls_Account>();
            IQueryable<Account> acc1 = (from a in DB.Staffs
                                        join b in DB.Accounts
                                        on a.staff_id equals b.acc_id
                                        where b.acc_id.Contains(id) == true
                                        select b
                                      );
            foreach (Account a in acc1)
            {
                Cls_Account a1 = new Cls_Account();
                a1.Id_acc = a.acc_id;
                a1.Password = a.password;
                a1.Role_name = a.role_name;
                reslut_s.Add(a1);
            }
            return reslut_s;

        }

        public bool Check_acc_exists(string id)
        {
            Account ck = (from a in DB.Accounts
                          join b in DB.Staffs
                          on a.acc_id equals b.staff_id
                          where b.staff_status==false && a.acc_id.Equals(id.Trim())==true
                          && b.staff_id.Equals(id.Trim())==true
                          select a).SingleOrDefault();
            if (ck != null)
            {
                return false;
            }
            return true;
        }

        public bool Change_Pass(string id,string pass)
        {
            Account acc = DB.Accounts.Where(x => x.acc_id.Equals(id) == true).SingleOrDefault();
            if (acc == null)
            {
                return false;
            }
            try
            {
                acc.password = pass;
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                //throw;
            }
            return false;
        }

        public bool insertonsubmit_change_account(Cls_Account acc)
        {
            try
            {
                Account ac = new Account();
                ac.acc_id = acc.Id_acc;
                ac.password = acc.Password;
                ac.role_name = acc.Role_name;
                DB.Accounts.InsertOnSubmit(ac);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                //throw;
            }
            return false;
        }

        public Cls_Account Get_account_by_id(string id)
        {
            Account ac = DB.Accounts.Where(x => x.acc_id.Equals(id.Trim())==true).FirstOrDefault();
            Cls_Account acc1 = new Cls_Account();
            ac.acc_id = acc1.Id_acc;
            ac.role_name = acc1.Role_name;
            return acc1;

        }
    }

}
