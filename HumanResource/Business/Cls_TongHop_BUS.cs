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

    public class Cls_TongHop_BUS
    {
        Cls_TongHop_DAL cls_tonghop_DAL1;
        public Cls_TongHop_BUS()
        {
            cls_tonghop_DAL1 = new Cls_TongHop_DAL();
        }
        //public List<object> Get_ThongTin_TongHop_BUS(string ma_tk_check)
        //{
        //    return cls_tonghop_DAL1.Get_ThongTin_TongHop(ma_tk_check);
        //}
        public List<Cls_Department> Get_list_dpm_BUS(string Id_acc)
        {
            return cls_tonghop_DAL1.Get_list_dpm(Id_acc);
        }
        public List<Cls_JobTitle> Get_list_job_BUS(string Id_acc)
        {
            return cls_tonghop_DAL1.Get_list_job(Id_acc);
        }
        public List<Cls_Staff> Get_list_staff_BUS(string Id_acc)
        {
            return cls_tonghop_DAL1.Get_list_staff(Id_acc);
        }
    }

}
