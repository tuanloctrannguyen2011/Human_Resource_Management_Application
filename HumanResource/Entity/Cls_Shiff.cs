using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Shiff
    {
        private string id_shift, shiff_time;

        public string Id_shift { get => id_shift; set => id_shift = value; }
        public string Shiff_time { get => shiff_time; set => shiff_time = value; }


        public Cls_Shiff()
        {

        }
        public Cls_Shiff(string ID_S, string ID_Stime)
        {
            this.Id_shift = ID_S;
            this.Shiff_time = ID_Stime;
        }
    }
}
