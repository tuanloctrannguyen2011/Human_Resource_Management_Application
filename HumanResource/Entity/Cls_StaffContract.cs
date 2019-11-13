using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_StaffContract
    {
        private string id_staff, id_contract;

        public string Id_staff { get => id_staff; set => id_staff = value; }
        public string Id_contract { get => id_contract; set => id_contract = value; }

        public Cls_StaffContract()
        {

        }

        public Cls_StaffContract(string ID_ST, string ID_CT)
        {
            this.Id_contract = ID_ST;
            this.Id_contract = ID_CT;
        }
    }
}
