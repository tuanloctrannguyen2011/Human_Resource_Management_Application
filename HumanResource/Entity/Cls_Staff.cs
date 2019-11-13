using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Staff
    {
        private string id_staff, phone, mail, address, name;
        private bool status_staff;
        private string gender;
        private DateTime birtday;
        public string Id_staff { get => id_staff; set => id_staff = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Birtday { get => birtday; set => birtday = value; }
        public string Address { get => address; set => address = value; }
        public bool Status_staff { get => status_staff; set => status_staff = value; }
      

        public Cls_Staff()
        {

        }
        public Cls_Staff(string ID_ST, string P, string M, string ADD, bool STATUS_ID, string NAME, string GENDER, DateTime BD)
        {
            this.Id_staff = ID_ST;
            this.Phone = P;
            this.Mail = M;
            this.Address = ADD;
            this.Status_staff = STATUS_ID;
            this.Name = NAME;
            this.Gender = GENDER;
            this.Birtday = BD;

        }

    }
}
