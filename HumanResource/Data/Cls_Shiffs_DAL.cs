using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Shiffs_DAL
    {
        //Cls_Ketnoi connect = new Cls_Ketnoi();
        DBDataContext DB;
        public Cls_Shiffs_DAL()
        {
            DB = new DBDataContext();
           // DB = connect.Get_datacontext();
        }
        public Cls_Shiff Get_shiff(string id)
        {
            Cls_Shiff sh = new Cls_Shiff();
            Shift sh1 = (from a in DB.Shifts
                         join b in DB.Contracts
                         on a.shift_id equals b.shift_id
                         join c in DB.Staff_Contracts
                         on b.contract_id equals c.contract_id
                         join d in DB.Staffs 
                         on c.staff_id equals d.staff_id
                         where d.staff_id.Equals(id)==true
                         select a).SingleOrDefault();
            sh.Id_shift = sh1.shift_id;
            sh.Shiff_time = sh1.shift_time;
            
            return sh;
        }

        public List<Cls_Shiff> Get_list_shiff()
        {
            IEnumerable<Shift> l_shiff = DB.Shifts;
            List<Cls_Shiff> list_shiff = new List<Cls_Shiff>();
            foreach(Shift a in l_shiff)
            {
                Cls_Shiff sh = new Cls_Shiff();
                sh.Id_shift = a.shift_id;
                sh.Shiff_time = a.shift_time;
                list_shiff.Add(sh);
            }
            return list_shiff;
        }
    }
}
