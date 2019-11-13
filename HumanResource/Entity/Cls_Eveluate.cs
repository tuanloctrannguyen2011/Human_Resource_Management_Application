using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_Eveluate
    {
        private string id_eva, eva_type, id_staff;
        private string eva_desc;
        private DateTime? eva_date;

        public string Id_eva { get => id_eva; set => id_eva = value; }
        public string Eva_type { get => eva_type; set => eva_type = value; }
        public string Id_staff { get => id_staff; set => id_staff = value; }
        public string Eva_desc { get => eva_desc; set => eva_desc = value; }
        public DateTime? Eva_date { get => eva_date; set => eva_date = value; }

        public Cls_Eveluate()
        {

        }
        public Cls_Eveluate(string ID_EVA, string TYPE_EVA, string ID_STAFF, string EVA_DESC, DateTime EVA_DATE)
        {
            this.Id_eva = ID_EVA;
            this.Id_staff = ID_STAFF;
            this.Eva_type = TYPE_EVA;
            this.Eva_desc = EVA_DESC;
            this.Eva_date = EVA_DATE;
        }
    }
}
