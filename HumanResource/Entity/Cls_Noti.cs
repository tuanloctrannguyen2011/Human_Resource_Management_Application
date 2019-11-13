using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;
namespace Entity
{
    public class Cls_Noti
    {
        private char id_noti;
        private string desc_noti;

        public char Id_noti { get => id_noti; set => id_noti = value; }
        public string Desc_noti { get => desc_noti; set => desc_noti = value; }
        public Cls_Noti()
        {

        }
        public Cls_Noti(char ID_No, string DESC_NOTI)
        {
            this.Id_noti = ID_No;
            this.Desc_noti = DESC_NOTI;
        }
    }
}
