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
    public class Cls_Shiffs_BUS
    {
        Cls_Shiffs_DAL cls_shiffs_DAL1;
        public Cls_Shiffs_BUS()
        {
            cls_shiffs_DAL1 = new Cls_Shiffs_DAL();
        }
        public Cls_Shiff Get_shiff_BUS(string id)
        {
            return cls_shiffs_DAL1.Get_shiff(id);
        }

        public List<Cls_Shiff> Get_list_shiff_BUS()
        {
            return cls_shiffs_DAL1.Get_list_shiff();
        }
    }
}
