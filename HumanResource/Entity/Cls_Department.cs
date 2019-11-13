using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Department
    {
        private string id_dp, name_dp;

     
        public string Id_dp { get => id_dp; set => id_dp = value; }
        public string Name_dp { get => name_dp; set => name_dp = value; }
        public Cls_Department()
        {

        }
        public Cls_Department(string ID_DP, string NAME_DP)
        {
            this.Id_dp = ID_DP;
            this.Name_dp = NAME_DP;
        }
    }
}
