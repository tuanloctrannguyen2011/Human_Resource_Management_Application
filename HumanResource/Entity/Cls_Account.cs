using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Account
    {
        private string id_acc, password, role_name;


        public string Id_acc { get => id_acc; set => id_acc = value; }
        public string Password { get => password; set => password = value; }
        public string Role_name { get => role_name; set => role_name = value; }

        public Cls_Account()
        {

        }
        public Cls_Account(string ID_ACC, string PAS, string R_NAME)
        {
            this.Id_acc = ID_ACC;
            this.Password = PAS;
            this.Role_name = R_NAME;
        }
    }
}
